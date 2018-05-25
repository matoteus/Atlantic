using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	private Rigidbody2D rg;
	private AudioSource aud;

	public AudioClip shoot;

	// Use this for initialization
	void Start () {

		aud = GetComponent<AudioSource> ();
		rg = GetComponent<Rigidbody2D> ();

		rg.velocity = new Vector3 (GameManager.instance_d.x ,GameManager.instance_d.y, 0);
		aud.PlayOneShot (shoot);
		
	}
	

}
