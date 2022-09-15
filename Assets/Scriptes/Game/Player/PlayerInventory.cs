using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	[SerializeField] int WeaponIndex=1;
	public int FirstWeaponIndex=1;
	public int SecondWeaponIndex=0;
	bool IsFirstWeapon=true;
	public PlayerController Controller;
	public GameController Game;
	public WeaponsScriptes WeaponSC;
	public Weapon[] AllWeapons=new Weapon[10];


	public void UseWeapon(){
			WeaponSC.Invoke ("Weapon_"+WeaponIndex.ToString(),0f);
	}


	public void SetWeapon(int i,bool IsFire){

			WeaponIndex = i;
		if (FirstWeaponIndex == 0)
			FirstWeaponIndex = i;
		else if (SecondWeaponIndex == 0) {
			SecondWeaponIndex = i;
			IsFirstWeapon = false;
		}
		else {
				Vector3 DropPlace = new Vector3 (Random.Range (-1, 2), Random.Range (-1, 2), 0);
			while (DropPlace.x == 0 && DropPlace.y == 0 && Controller.World.CellPos((int)DropPlace.x,(int)DropPlace.y)!=0) {
					DropPlace = new Vector3 (Random.Range (-1, 2), Random.Range (-1, 2), 0);
				}
				if(IsFirstWeapon){
					Instantiate (AllWeapons [FirstWeaponIndex], Controller.transform.position+DropPlace*0.4f, Quaternion.identity);
					FirstWeaponIndex = i;
				    }
			    else{
					Instantiate (AllWeapons [SecondWeaponIndex], Controller.transform.position+DropPlace*0.4f, Quaternion.identity);
					SecondWeaponIndex=i;
				    }
					}
		Game.UI.SetFireUI (IsFire);
	}


	public void SwitchWeapon(bool isFirstWeapon){
			if (isFirstWeapon) {
				IsFirstWeapon = true;
				WeaponIndex = FirstWeaponIndex;
			} else {
				IsFirstWeapon = false;
				WeaponIndex = SecondWeaponIndex;
			}
			if (AllWeapons [WeaponIndex] != null)
				Game.UI.SetFireUI (AllWeapons [WeaponIndex].IsFire);
	}



}
