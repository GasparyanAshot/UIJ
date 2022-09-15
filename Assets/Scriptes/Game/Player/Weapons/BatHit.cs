using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatHit : MonoBehaviour {

	int Damage=2;
	int KillsCount=0;
	public PlayerController Player;

	void Start(){
		Invoke ("DestroyThis", 0.33f);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Enemy") {
			if(collider.GetComponent<Enemy> ().HP<=Damage)
				KillsCount++;
			collider.GetComponent<Enemy> ().GetDamage (Damage);
		}
	}

	void DestroyThis(){
		Player.MultiKill (KillsCount);
		Destroy (gameObject);
	}
}
