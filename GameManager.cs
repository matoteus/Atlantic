using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public static GameManager instance_d; // CRIA UMA INSTANCIA DA CLASSE TODA PARA QUE POSSA SER ACESSADA POR OUTRAS CLASSES

    [Header("Prefabs Objects")]
	
	public GameObject bullet;   // OBJETO DA BALA
	public GameObject ship1;    // OBJETO DA NAVE1
	public GameObject ship2;    // OBJETO DA NAVE2
    public GameObject MissilPrefab; // OBJETO DO MISSIL

    [Header("Spawn Points")]
	
    public GameObject middle_instance;      // OBJETO QUE SER COMO SPAWN POINT.
    public GameObject left_instance;        // OBJETO QUE SER COMO SPAWN POINT.
    public GameObject right_instance;       // OBJETO QUE SER COMO SPAWN POINT.
    public GameObject EnemySpawnPoint1;]    // OBJETO QUE SER COMO SPAWN POINT.
	public GameObject EnemySpawnPoint2; // OBJETO QUE SER COMO SPAWN POINT.
    public GameObject MissilSpawnPoint;     // OBJETO QUE SER COMO SPAWN POINT.

    [Header("Value Variables")]
	public int x;                // VALORES DE DIREÇÃO PARA A BALA EM X
	public int y;                // VALORES DE DIREÇÃO PARA A BALA EM Y
	public int ship_speed_x;     // VELOCIDADE DA NAVE
	public int DelayTimeSpawn;   // DELAY ENTRE O SPAWN DAS NAVES INIMIGAS
	public int score;            // PONTUAÇÃO
	public bool canSpawn = true;  // VERIFICA SE A NAVE PODE SPAWNAR.

    public GameObject bombaEffect;   // OBJETO DE EFFEITO DE EXPLOSÃO
    public AudioClip level_up;       // AUDIO DE QUANDO PASSA DE LVL
    public Text score_txt;           // TEXTO QUE RECEBE A VARIAVEL SCORE

    private AudioSource aud;         // COMPONENTE DE AUDIO
    
	// =================================================================================================================================

	void Start (){

	instance_d = this; // INSTANCIA A CLASSE
        aud = GetComponent<AudioSource>(); // RECEBE COMPONENTE

	}

	IEnumerator delaySpawn (){

		yield return new WaitForSeconds (3); // DELAY DE SPAWN DA NAVE
		canSpawn = true; // SETA O SPAWN PARA VERDADEIRO
	}



	// =====================================================================================================================================================================

	void FixedUpdate() {

		score_txt.text = score.ToString(); // ATUALIZA A PONTUAÇÃO 

        SpeedChanger(); // CHAMA A FUNÇÃO DE MUDANÇA DE VELOCIDADE DO JOGO QUE VAI DEPENDER DA PONTUAÇÃO

		DelayTimeSpawn = Random.Range (0,DelayTimeSpawn); // DEFINE UM NUMERO RANDOMICO 

		if (DelayTimeSpawn >= 0 && DelayTimeSpawn <= 2 && canSpawn == true) { // VERIFICA SE AS NAVES VÃO SPAWNAR DE ACORDO COM O VALOR, ISSO É NECESSARIO PARA MANTER O EQUILIBRIO, ALTERANDO A VARIAVEL DELAY TIME VOCÊ 
			                                                              // PODE DETERMINAR OS INTERVALOS ENTRE OS SPAWN PARA NÃO DEIXAR O JOGO TRAVADO COM NAVE SPAWNANDO TODA HORA.

			EnemySpawn (); // CHAMA A FUNÇÃO DE SPAWN DE INIMIGO
           		MissilSpawn(); // CHAMA A FUNÇÃO DE SPAWN DO MISSIL
		}



		// === SHOOTING SCRIPT =============================================================================================================================================

		if (Input.GetButtonDown("middle")){

           
                Instantiate(bullet, middle_instance.transform.position, transform.rotation); // INSTANCIA A BALA NO SPAWN POINT DO MEIO
                y = 10; // ESSE VALOR DEFINE A DIREÇÃO DA BALA, QUANDO A BALA É INSTANCIADA ELE RECEBE ESSAS CORDENADAS VAI NA DIREÇÃO.
                x = 0;  // COMO A BALA AQUI VAI PRA CIMA, SÓ TEM VALOR EM Y
            

		}

		if (Input.GetButtonDown("left")){
            
                Instantiate(bullet, left_instance.transform.position, transform.rotation); // INSTANCIA A BALA NO SPAWN POINT DA ESQUERDA
                y = 10; // AQUI A BALA PRECISA ANDAR NA DIAGONAL DA ESQUERDA PRA DIREITA, POR ISSO ELA RECEBE ESSES DOIS VALORES (CHECAR O SCRIPT BULLET.CS)
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

        int MissilRandom = Random.Range(1, 100); // UTILIZO UMA VARIAVEL RANDOM PARA DEIXA O SPAWN DO MISSIL EQUILIBRADO

        if (MissilRandom > 0 && MissilRandom < 10) { // A CHANCE DE SPAWN DESSE MISSIL TEM QUE SER MINIMA.

            Instantiate(MissilPrefab, MissilSpawnPoint.transform.position, transform.rotation); // INSTANCIA O MISSIL NO LOCAR DA VARIAVEL MISSIL SPAWN POINT

        }


    }



	public void EnemySpawn (){

		int typeOfShip = Random.Range(1,100); // AQUI EU DEFINO UM NUMERO RANDOMICO PARA SABER QUAL TIPO DE NAVE INSTANCIAR (JA QUE SÃO DOIS INIMIGOS)
		                                      // EXISTE 50% DE CHANCE DE CADA UM SER INSTANCIADO.
		
		int SpawnPonint = Random.Range (1, 100); // AQUI DOU 50% DE CHANCE DESSES INIMIGOS SEREM INSTANCIADOS DA DIREITA OU DA ESQUERDA.




		if (typeOfShip > 50 && SpawnPonint > 50) {

			Instantiate (ship1, EnemySpawnPoint1.transform.position, transform.rotation); // INSTANCIO A PRIMEIRA NAVE NO PONTO DA DIREIRA
			ship_speed_x = -3; // COMO ELA FOI INSTANCIADA NO PONTO DA DIREITA ELA PRECISA ANDAR PRA ESQUERDA, AI RECEBE O VALOR NEGATIVO
			canSpawn = false; // TORNO O SPAWN FALSO , PARA QUE ELA N INSTANCIE LOUCAMENTE
			StartCoroutine ("delaySpawn"); // E CHAMO O TEMPO DE ESPERA

		}



		if (typeOfShip < 50 && SpawnPonint < 50) {

			Instantiate (ship2, EnemySpawnPoint2.transform.position, transform.rotation);
			ship_speed_x = 3;
			canSpawn = false;
			StartCoroutine ("delaySpawn");

		}


	}

	
	// ESSA FUNÇÃO ABAIXO VERIFICA O SCORE DO JOGADOR E AUMENTA A VELOCIDADE DO JOGO DE ACORDO
	
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
