using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Enemy Enemy;
	public PlayerController Player;

	public void SpawnEnemy(int X,int Y,int xSteps,int ySteps){
		Enemy NewEnemy=Instantiate(Enemy,new Vector3((X-8)*5.2f+(xSteps-6)*0.4f,(Y-8)*5.2f+(ySteps-6)*0.4f,0),Quaternion.identity);
		NewEnemy.Movement.X = X;
		NewEnemy.Movement.Y = Y;
		NewEnemy.Movement.xSteps = xSteps;
		NewEnemy.Movement.ySteps = ySteps;
		Player.Game.NewEnemy (NewEnemy);
	}
}
