using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public GameController Game;
	int X, Y, x, y;


	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			PlayerController Player = collider.GetComponent<PlayerController> ();
			Player.TakeCoin (1);
			Player.Game.World.CoinsCount--;
			Taken (Player);
		} 
	}

	void Taken(PlayerController Player){
		Player.Game.UIRenew ();
		Game.World.CoinsCount--;
		Game.World.Chunks [X, Y].Cells [x, y] = 0;
		Destroy (gameObject);
	}

	public void SetCoords(int setX,int setY,int setx,int sety){
		X = setX;
		Y = setY;
		x = setx;
		y = sety;
	}
}
