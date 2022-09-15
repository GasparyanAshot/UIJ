using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	public GameController Game;
	int X, Y, x, y;

	void Start(){
		Invoke ("DestroyTimer", 30);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			PlayerController Player = collider.GetComponent<PlayerController> ();
			Player.Energy += 5;
			Taken(Player);
		}
	}

	void Taken(PlayerController Player){
		Player.Game.UIRenew ();
		Game.World.EnergyParticles--;
		Game.World.Chunks [X, Y].Cells [x, y] = 0;
		Destroy (gameObject);
	}

	void DestroyTimer(){
		Game.World.EnergyParticles--;
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
