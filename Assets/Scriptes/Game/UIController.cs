using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text EnergyUI;
	public Text ScoreUI;
	public Text CoordsUI;
	public Text CoinsUI;
	public Image FirstWeaponUI;
	public Image SecondWeaponUI;
	public GameObject FireUI;
	public GameObject HitUI;
	public Slider POVSlider;
	public PlayerController Player;
	public GameController Game;
	public Camera cam;
	public GameObject GameoverUI;
	public GameObject InGameUI;

	void Start(){
		POVSlider.value = cam.orthographicSize;
		Renew ();
	}

	public void Renew(){
		EnergyUI.text =Player.Energy.ToString ();
		ScoreUI.text = Game.PlayerMoves.ToString ();
		//CoordsUI.text = (Player.X-8).ToString()+","+(Player.Y-8).ToString();
		CoinsUI.text = Player.Coins.ToString();
	}

	public void SetPOV(){
		cam.orthographicSize = POVSlider.value;
	}

	public void SetFireUI(bool IsFire){
		if(Player.Inventory.AllWeapons [Player.Inventory.FirstWeaponIndex])
		   FirstWeaponUI.sprite = Player.Inventory.AllWeapons [Player.Inventory.FirstWeaponIndex].GetComponent<SpriteRenderer> ().sprite;
		if(Player.Inventory.AllWeapons [Player.Inventory.SecondWeaponIndex])
		   SecondWeaponUI.sprite = Player.Inventory.AllWeapons [Player.Inventory.SecondWeaponIndex].GetComponent<SpriteRenderer> ().sprite;
		if (IsFire) {
			FireUI.SetActive (true);
			HitUI.SetActive (false);
		} else {
			HitUI.SetActive (true);
			FireUI.SetActive (false);
		}
		Player.DirChange = false;
		
	}

	public void GameOver(){
		GameoverUI.SetActive (true);
		InGameUI.SetActive (false);
	}
}
