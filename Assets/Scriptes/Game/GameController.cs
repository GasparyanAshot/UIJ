using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public PlayerController Player;
	public WorldGenerator World;
	public EnemySpawner enemySpawner;
	//public List<EnemyMovment> Enemies=new List<EnemyMovment>();
	public List<Enemy> Enemies=new List<Enemy>();
	public float PlayerMoves=0;
	float MaxEnemyCount=5;
	public UIController UI;

	void Start(){
		for(int i=0;i<5;i++){
			EnemySpawn ();
			World.GenerationStep ();
		}
	}


	public void PlayerMoved () {
		PlayerMoves++;
		UIRenew ();
		World.GenerationStep ();
		EnemySpawn ();
		foreach (Enemy i in Enemies.ToArray()){
			if (i!=null)
					i.Step ();
			else
				Enemies.Remove(i);
		}
	}

	public void UIRenew(){
		UI.Renew ();
	}

	public void NewEnemy(Enemy newEnemy){
		Enemies.Add (newEnemy);
		newEnemy.player = Player;
	}

	void EnemySpawn(){
		if(Enemies.Count<MaxEnemyCount){
			int Xsteps = Random.Range (0, 12);
			int Ysteps = Random.Range (0, 12);
			int X = Random.Range (-1, 1);
			int Y = Random.Range (-1, 1);
			if(X==Player.X && Y==Player.Y){
				while (Mathf.Abs(Xsteps - Player.xSteps)<3 && Mathf.Abs(Ysteps-Player.ySteps)<3) {
					Xsteps = Random.Range (0, 12);
					Ysteps = Random.Range (0, 12);
				}
			}
			enemySpawner.SpawnEnemy(Player.X+X,Player.Y+Y,Xsteps,Ysteps);
		}
	}

	public void SetFireDir(float i){
		if (i == 1)
			Player.FireDir = new Vector2 (1, 0);
		if (i == 2)
			Player.FireDir = new Vector2 (1, -1);
		if (i == 3)
			Player.FireDir = new Vector2 (0, -1);
		if (i == 4)
			Player.FireDir = new Vector2 (-1, -1);
		if (i == 5)
			Player.FireDir = new Vector2 (-1, 0);
		if (i == 6)
			Player.FireDir = new Vector2 (-1, 1);
		if (i == 7)
			Player.FireDir = new Vector2 (0, 1);
		if (i == 8)
			Player.FireDir = new Vector2 (1, 1);
		Player.DirChange = false;
	}
		

	public void GameOver(){
		UI.GameOver ();
	}

	public void Restart(){
		SceneManager.LoadScene (1);
	}

	public void Menu(){
		SceneManager.LoadScene (0);
	}

}
