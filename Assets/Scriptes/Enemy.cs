using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int HP;
	public PlayerController player;
	public EnemyMovment Movement;
	public bool IsWalking;

	public void Step(){
			Movement.Move ();
	}


	public void GetDamage(int Damage){
		HP -= Damage;
		if (HP <= 0) {
			Destroy (gameObject);
		}
	}



	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			collider.GetComponent<PlayerController> ().GameOver ();
		}
	}
}
