using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saves : MonoBehaviour {

	public void SetCoin(int i){
		PlayerPrefs.SetInt ("CoinsCount",i);
	}
	public int GetCoin(){
		return PlayerPrefs.GetInt ("CoinsCount");
	}

	public void OpenWeapon(int i){
		PlayerPrefs.SetInt ("Weapon"+i.ToString(),1);
	}
	public bool GetIsOpendWeapon(int i){
		return PlayerPrefs.GetInt ("Weapon" + i.ToString ()) == 1;
	}
}
