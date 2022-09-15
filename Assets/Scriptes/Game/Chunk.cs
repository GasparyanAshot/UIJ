using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

	public int[,] Cells=new int[13,13];//0=datark 1=energy 2=coin 3=block 4=weapon
	public Weapon[] Weapons;


	void Start(){
		if (Random.Range (0, 2) == 1) {
			int i = Random.Range (1, Weapons.Length);
			while(PlayerPrefs.GetInt("Weapon"+i.ToString())!=1){
				i = Random.Range (0, Weapons.Length);
			}
				int x=Random.Range(0,13);
				int y=Random.Range(0,13);
			Cells [x, y] = 4;
			Instantiate (Weapons [i], transform.position + new Vector3 (x - 6, y - 6, 0) * 0.4f, Quaternion.identity);
	}
}
}
