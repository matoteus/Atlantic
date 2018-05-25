using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	private Rigidbody2D rg; // RECEBE O COMPONENTE RIGIDBODY DA BALA
	private AudioSource aud; // RECEBE O COMPONENTE DE AUDIO

	public AudioClip shoot; // RECEBE O SOM DE TIRO

	// Use this for initialization
	void Start () {

		aud = GetComponent<AudioSource> ();
		rg = GetComponent<Rigidbody2D> ();

		rg.velocity = new Vector3 (GameManager.instance_d.x ,GameManager.instance_d.y, 0); // INSTANCIA A BALA DE ACORDO COM OS VALORES DO GAMEMANAGER
		aud.PlayOneShot (shoot); // EXECUTA O AUDIO DE TIRO 
		
	}
	

}
