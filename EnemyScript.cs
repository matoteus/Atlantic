using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	private Rigidbody2D rg;
	private AudioSource aud;
	private SpriteRenderer sprt;
	private Animator anim;

	public AudioClip hit;


	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Bullet") {

			anim.SetTrigger ("Morreu");
			StartCoroutine ("waitForDestroy");
			aud.PlayOneShot (hit);
			GameManager.instance_d.score = GameManager.instance_d.score + 300;




		}


	}

	IEnumerator waitForDestroy (){

		yield return new WaitForSeconds (0.8f);
		Destroy (gameObject);
	}




	// Use this for initialization
	void Start () {

		aud = GetComponent<AudioSource> ();
		rg = GetComponent<Rigidbody2D> ();
		sprt = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();

		rg.velocity = new Vector3 (GameManager.instance_d.ship_speed_x,0, 0);

		if (GameManager.instance_d.ship_speed_x < 0) {

			sprt.flipX = true;

		}
	}
	

}
