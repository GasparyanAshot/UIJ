using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

	public WorldGenerator World;
	public GameController Game;
	public PlayerInventory Inventory;
	float PlayerSize=0.4f;//personaji chap@
	public int X;
	public int Y;
	float ChunkStepsCount=13;//inchqan qayla petq chunk@ ancnelu hamar =ChunkSize/PlayerSize
	public float xSteps;
	public float ySteps;
	float AutoSpeed=0.5f;//automat katarvox qayleri hachaxakanutyun@ 
	public bool Auto;
	public bool DirChange=false;
	public Vector2 dir=Vector2.zero;
	public Vector2 FireDir=Vector2.right;
	public GameObject FireDirUI;
	public float Energy=10;
	public int Coins;
	public Saves SavingController;

	void Awake () {
		X = World.WorldHalfSize;
		Y = World.WorldHalfSize;
		xSteps = (ChunkStepsCount - 1) / 2;
		ySteps = (ChunkStepsCount - 1) / 2;
		Coins = SavingController.GetCoin ();
	}


	public void Move(){
		if (!DirChange && World.CellPos((int)dir.x,(int)dir.y)!=3) {
			if (Energy > 0) {
				Energy--;
				transform.position += new Vector3 (dir.x * PlayerSize, dir.y * PlayerSize, 0);
				ySteps += dir.y;
				xSteps += dir.x;
				Game.PlayerMoved ();
				if (xSteps == ChunkStepsCount) {
					xSteps = 0;
					X++;
					World.NewChunk (X, Y);
					World.DeActivateChunks (-1, 0);
				}
				if (xSteps == -1) {
					xSteps = ChunkStepsCount - 1;
					X--;
					World.NewChunk (X, Y);
					World.DeActivateChunks (1, 0);
				}
				if (ySteps == ChunkStepsCount) {
					ySteps = 0;
					Y++;
					World.NewChunk (X, Y);
					World.DeActivateChunks (0, -1);
				}
				if (ySteps == -1) {
					ySteps = ChunkStepsCount - 1;
					Y--;
					World.NewChunk (X, Y);
					World.DeActivateChunks (0, 1);
				}
			} else {
				GameOver ();
			}
		}
	}

	/**public void CheckEnemies(int xMin ,int xMax ,int yMin ,int yMax){
		int i = 0;
		int KillsCount=0;
		foreach (EnemyMovment x in Game.Enemies.ToArray()){
			if (((13 * x.X + x.xSteps) - (13 * X + xSteps)) >= xMin && ((13 * x.X + x.xSteps) - (13 * X + xSteps)) <= xMax) {
				if (((13 * x.Y + x.ySteps) - (13 * Y + ySteps)) >= yMin &&	((13 * x.Y + x.ySteps) - (13 * Y + ySteps)) <= yMax) {
					Game.Enemies.RemoveAt (i);
					Destroy (x.gameObject);
					KillsCount++;
					continue;
				}		
			}
			i++;
		}
		if (KillsCount > 0)
			MultiKill (KillsCount);
	}**/

	/**public void CheckEnemies(Vector2[] arr){
		int i = 0;
		int KillsCount=0;
		foreach (EnemyMovment x in Game.Enemies.ToArray()) {
			bool Killed = false;
			for (int j = 0; j < arr.Length; j++) {
				if (arr [j].x == x.X * 13 + x.xSteps && arr [j].y == x.Y * 13 + x.ySteps) {
					Killed = true;
				}
			}
			if (Killed) {
				Game.Enemies.RemoveAt (i);
				Destroy (x.gameObject);
				KillsCount++;
				continue;
			}
			i++;
		}
		if (KillsCount > 0)
			MultiKill (KillsCount);
		TakeCoin (KillsCount);
	}**/

	public void MultiKill(int KillsCount){
		if (KillsCount == 2) 
				Energy += 2;
		if (KillsCount == 3)
				Energy += 4;
		if (KillsCount == 4) 
				Energy += 6;
		if (KillsCount >= 5)
				Energy += 10;

		Game.UIRenew ();
	}

	public void TakeCoin(int count){
		Coins+=count;
	    SavingController.SetCoin (Coins);
		Game.UIRenew ();
	}

	public void SetAuto(){
		if (Auto)
			Auto = false;
		else {
			Auto = true;
			AutoMove ();
		}
	}

	void AutoMove(){
		Move ();
		if (Auto) {
			Invoke ("AutoMove", AutoSpeed);
		}
	}
		
	public void SetDirChange(){
		if (DirChange) {
			DirChange = false;
			FireDirUI.SetActive (false);
		}
		else {
			DirChange = true;
			FireDirUI.SetActive (true);
		}
		
	}

	public void GameOver(){
		Game.GameOver ();
	}
}
