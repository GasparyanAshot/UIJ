using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Player;
	float Speed =0.6f;
	float Distance;

	void Update(){
		if (Mathf.Sqrt ((Player.transform.position.x - transform.position.x) * (Player.transform.position.x - transform.position.x) + (Player.transform.position.y - transform.position.y) * (Player.transform.position.y - transform.position.y))>0.5f) {
			Vector3 dir = new Vector3 (Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y, 0) * 2;
			transform.Translate (dir * Speed * Time.deltaTime);
		}
	}
		
}
