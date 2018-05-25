using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	public static GameManager instance_d;

    [Header("Prefabs Objects")]
	public GameObject bullet;
	public GameObject ship1;
	public GameObject ship2;
    public GameObject MissilPrefab;

    [Header("Spawn Points")]
    public GameObject middle_instance;
    public GameObject left_instance;
    public GameObject right_instance;
    public GameObject EnemySpawnPoint1;
	public GameObject EnemySpawnPoint2;
    public GameObject MissilSpawnPoint;

    [Header("Value Variables")]
	public int x;
	public int y;
	public int ship_speed_x;
	public int DelayTimeSpawn;
	public int score;
	public bool canSpawn = true;

    public GameObject bombaEffect;
    public AudioClip level_up;
    public Text score_txt;

    private AudioSource aud;
    


	void Start (){

		instance_d = this;
        aud = GetComponent<AudioSource>();

	}

	IEnumerator delaySpawn (){

		yield return new WaitForSeconds (3);
		canSpawn = true;
	}



	// =====================================================================================================================================================================

	void FixedUpdate() {

		score_txt.text = score.ToString();

        SpeedChanger();

		DelayTimeSpawn = Random.Range (0,DelayTimeSpawn);

		if (DelayTimeSpawn >= 0 && DelayTimeSpawn <= 2 && canSpawn == true) {

			EnemySpawn ();
            MissilSpawn();
		}



		// === SHOOTING SCRIPT =============================================================================================================================================

		if (Input.GetButtonDown("middle")){

           
                Instantiate(bullet, middle_instance.transform.position, transform.rotation);
                y = 10;
                x = 0;
            

		}

		if (Input.GetButtonDown("left")){
            
                Instantiate(bullet, left_instance.transform.position, transform.rotation);
                y = 10;
                x = 15;
            

		}

		if (Input.GetButtonDown("right")){

           
                Instantiate(bullet, right_instance.transform.position, transform.rotation);
                y = 10;
                x = -15;
            

		}

		// ==================================================================================================================================================================

	}


	// ======================================================================================================================================================================
	


    public void MissilSpawn()
    {

        int MissilRandom = Random.Range(1, 100);

        if (MissilRandom > 0 && MissilRandom < 10) {

            Instantiate(MissilPrefab, MissilSpawnPoint.transform.position, transform.rotation);

        }


    }



	public void EnemySpawn (){

		int typeOfShip = Random.Range(1,100);
		int SpawnPonint = Random.Range (1, 100);




		if (typeOfShip > 50 && SpawnPonint > 50) {

			Instantiate (ship1, EnemySpawnPoint1.transform.position, transform.rotation);
			ship_speed_x = -3;
			canSpawn = false;
			StartCoroutine ("delaySpawn");

		}



		if (typeOfShip < 50 && SpawnPonint < 50) {

			Instantiate (ship2, EnemySpawnPoint2.transform.position, transform.rotation);
			ship_speed_x = 3;
			canSpawn = false;
			StartCoroutine ("delaySpawn");

		}


	}

    public void SpeedChanger()
    {
        if (score > 1000)
        {

            Time.timeScale = 1.2f;
            
        }

        if (score > 1500)
        {
            Time.timeScale = 1.5f;
            
        }

        if (score > 30000)
        {
            Time.timeScale = 1.8f;
           
        }

        if (score > 35000)
        {
            Time.timeScale = 2f;
            
        }
    }

   




}
