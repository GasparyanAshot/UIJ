using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector2 dir;
	public float lenght;
	Vector3 startPos;
	public float Speed;
	public float IsCollision;
	int Damage=1;
	public PlayerController Player;
	public int WeaponIndex;

	void Start(){
		startPos = transform.position;
	}

	void Update () {
		if (Mathf.Abs (startPos.x - transform.position.x) < lenght*0.4-0.2f && Mathf.Abs (startPos.y - transform.position.y) < lenght*0.4-0.2f) {
			transform.Translate (dir * Speed * Time.deltaTime);
		} else {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Enemy") {
			collider.GetComponent<Enemy> ().GetDamage (Damage);
			if (WeaponIndex == 4)
			Player.Energy +=(int)(Mathf.Sqrt ((transform.position.x - startPos.x) * (transform.position.x - startPos.x) + (transform.position.y - startPos.y) * (transform.position.y - startPos.y))/0.4f);
			Player.Game.UIRenew ();
		}
	}
}
