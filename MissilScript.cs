using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilScript : MonoBehaviour {

	private Rigidbody2D rg;
	private AudioSource aud;
	private Animator anim;
	public AudioClip hit;
    public AudioClip missil_sound;


    void Start()
    {

        aud = GetComponent<AudioSource>();
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rg.velocity = new Vector3(9, 0, 0);
        aud.PlayOneShot(missil_sound);

    }

    void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Bullet") {

            GameManager.instance_d.bombaEffect.SetActive(true);
            GameManager.instance_d.score = GameManager.instance_d.score + 500;
            aud.PlayOneShot(hit);
            StartCoroutine("waitForDestroy");


		}


	}

	IEnumerator waitForDestroy (){

		yield return new WaitForSeconds (0.8f);
        GameManager.instance_d.bombaEffect.SetActive(false);
        anim.SetBool("isDead", true);
        Destroy (gameObject);
	}





	
	

}
