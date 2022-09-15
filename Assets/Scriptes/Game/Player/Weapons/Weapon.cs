using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public int Index;
	public bool IsFire;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			collider.GetComponent<PlayerInventory> ().SetWeapon (Index,IsFire);
			Destroy (gameObject);
		}
	}
}
