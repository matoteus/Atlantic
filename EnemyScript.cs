using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	
	
	// SCRIPT DAS NAVES INIMIGAS

	private Rigidbody2D rg; // COMPONENTE RIGIDBODY
	private AudioSource aud; // COMPONENTE DE AUDIO
	private SpriteRenderer sprt; // COMPONENTE DE SPRITE
	private Animator anim; // COMPONENTE DE ANIMATOR

	public AudioClip hit; // SOM DE DESTRUICAO


	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Bullet") { // VERIFICA SE A BALA ATINGIU A NAVE

			anim.SetTrigger ("Morreu"); // EXECUTA A ANIMAÇÃO DE MORTE
			StartCoroutine ("waitForDestroy"); // ESPERA ALGUNS SEGUNDOS ANTES DE DESTRUIUR O GAMEOBJECT
			aud.PlayOneShot (hit); // EXECUTA O SOM DE MORTE
			GameManager.instance_d.score = GameManager.instance_d.score + 300; // ADICIONA PONTUAÇÃO NO GAME MANAGER.

		}


	}

	IEnumerator waitForDestroy (){

		yield return new WaitForSeconds (0.8f); // ESPERA 0,8 SEGUNDOS ANTES DE DESTRUIR A NAVE ( PRA DAR TEMPO DE ACONTECER A ANIMAÇÃO DE MORTE E EXECUTAR O SOM)
		Destroy (gameObject); // DESTROI A NAVE
	}




	// Use this for initialization
	void Start () {
		
		// RECEBE OS COMPONENTES 
		
		aud = GetComponent<AudioSource> ();
		rg = GetComponent<Rigidbody2D> ();
		sprt = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();

		rg.velocity = new Vector3 (GameManager.instance_d.ship_speed_x,0, 0); // SETA A VELOCIDADE DA NAVE QUANDO ELA É INSTANCIADA

		if (GameManager.instance_d.ship_speed_x < 0) { // VERIFICA SE A NAVE ESTÁ ANDANDO PARA A DIREITA OU ESQUERDA E VIRA ELA DE ACORDO COM A DIREÇÃO.

			sprt.flipX = true; // ESPELHA A NAVE

		}
	}
	

}
