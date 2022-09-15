using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour {

	float size=0.4f;
	public Enemy Controller;
	public int X;
	public int Y;
	float ChunkStepsCount=13;//inchqan qayla petq chunk@ ancnelu hamar =ChunkSize/PlayerSize
	public float xSteps;
	public float ySteps;
	Vector2 dir=Vector2.zero;


	public void Move(){
		if (Mathf.Abs (transform.position.x - Controller.player.gameObject.transform.position.x) > Mathf.Abs (transform.position.y - Controller.player.gameObject.transform.position.y)) {
			dir = new Vector2 (Controller.player.gameObject.transform.position.x-transform.position.x , 0).normalized;
		} else {
			dir = new Vector2 (0, Controller.player.gameObject.transform.position.y-transform.position.y).normalized;
		}
		transform.position += new Vector3 (dir.x * size, dir.y * size, 0);
		ySteps += dir.y;
		xSteps += dir.x;
		if (xSteps == ChunkStepsCount) {
			xSteps = 0;
			X++;
		}
		if (xSteps == -1) {
			xSteps = ChunkStepsCount-1;
			X--;
		}
		if (ySteps == ChunkStepsCount) {
			ySteps = 0;
			Y++;
		}
		if (ySteps == -1) {
			ySteps = ChunkStepsCount-1;
			Y--;
		}
	}
		
}
