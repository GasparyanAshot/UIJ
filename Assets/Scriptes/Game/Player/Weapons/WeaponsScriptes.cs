using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsScriptes : MonoBehaviour {

	public PlayerController Controller;
	public GameController Game;
	public Bullet BulletPrefab;
	public BatHit BatHitPrefab;
	Vector2[] arr;

	//Bat
	void Weapon_1(){
		if(Controller.Energy>=2){
	/**	arr = new Vector2[9];
		int i = 0;
		for (int x = -1; x < 2; x++) {
			for (int y = -1; y < 2; y++) {
				arr [i] = new Vector2 (Controller.X * 13 + Controller.xSteps + x, Controller.Y * 13 + Controller.ySteps + y);
				i++;
			}
		}**/

		BatHit NewBatHit = Instantiate (BatHitPrefab, Controller.transform.position, Quaternion.identity);
		NewBatHit.Player = Controller;

		Controller.Energy-=2;
		Game.UIRenew ();
		//Controller.CheckEnemies (arr);
		}
	}

	//Glock
	void Weapon_2(){
		if (Controller.Energy >= 1) {
			//arr = new Vector2[3];
			CreateBullet (Controller.FireDir, 3, 3, 2);
			/**for (int i = 0; i < 3; i++) {
				arr [i] = new Vector2 (Controller.X * 13 + Controller.xSteps, Controller.Y * 13 + Controller.ySteps) + Controller.FireDir * (i + 1);
			}**/
			Controller.Energy -= 1;
			Game.UIRenew ();
			//Controller.CheckEnemies (arr);
		}
	}

	//Shotgun
	void Weapon_3(){
		if (Controller.Energy >= 2) {
			//arr = new Vector2[6];
			Vector2 dirR, dirL;
			dirR = Controller.FireDir;
			dirL = Controller.FireDir;

			if (Mathf.Abs (dirL.x) == 0 && Mathf.Abs (dirL.y) != 0) {
				dirR.x++;
				dirL.x--;
			} else if (Mathf.Abs (dirL.x) != 0 && Mathf.Abs (dirL.y) == 0) {
				dirR.y++;
				dirL.y--;
			} else {
				dirR.x = 0;
				dirL.y = 0;
			}

			CreateBullet (Controller.FireDir, 2, 3, 3);
			CreateBullet (dirR, 2, 3, 3);
			CreateBullet (dirL, 2, 3, 3);

			/**for (int i = 0; i < 2; i++) {
				arr [i] = new Vector2 (Controller.X * 13 + Controller.xSteps, Controller.Y * 13 + Controller.ySteps) + Controller.FireDir * (i + 1);
			}
			for (int i = 0; i < 2; i++) {
				arr [i + 2] = new Vector2 (Controller.X * 13 + Controller.xSteps, Controller.Y * 13 + Controller.ySteps) + dirR * (i + 1);
			}
			for (int i = 0; i < 2; i++) {
				arr [i + 4] = new Vector2 (Controller.X * 13 + Controller.xSteps, Controller.Y * 13 + Controller.ySteps) + dirL * (i + 1);
			}**/
			Controller.Energy -= 2;
			Game.UIRenew ();
			//Controller.CheckEnemies (arr);
		}
	}

	//Snipe
	void Weapon_4(){
		if (Controller.Energy >= 5) {
			CreateBullet (Controller.FireDir, 10, 5, 4);
			Controller.Energy -= 5;
			Game.UIRenew ();
		}
	}


	void CreateBullet(Vector2 dir,float L,float S,int i){
		Bullet NewBullet = Instantiate (BulletPrefab, Controller.transform.position+0.2f*new Vector3(dir.x,dir.y,0), Quaternion.identity);
		NewBullet.dir = dir;
		NewBullet.lenght = L;
		NewBullet.Speed = S;
		NewBullet.WeaponIndex = i;
		NewBullet.Player = Controller;
	}
}
