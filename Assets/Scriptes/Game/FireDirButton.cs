using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDirButton : MonoBehaviour {

	public GameController Game;
	public GameObject DirUI;
	public float x;

	public void OnMouseUp(){
		Game.SetFireDir (x);
		Game.Player.Inventory.UseWeapon ();
		DirUI.SetActive (false);
	}
}
