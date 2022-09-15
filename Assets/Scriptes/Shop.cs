using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public Text CoinsUI;
	public Saves SaveController;
	public int[] Prices=new int[5];

	void Start(){
		RenewUI ();
	}
		
	public void Buy(int i){
		if(!SaveController.GetIsOpendWeapon(i)){
			if (SaveController.GetCoin () >= Prices [i]) {
				SaveController.SetCoin (SaveController.GetCoin ()-Prices[i]);
				SaveController.OpenWeapon (i);
				RenewUI ();
			}
		}
	}

	void RenewUI(){
		CoinsUI.text =(SaveController.GetCoin().ToString());
	}
}
