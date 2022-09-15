using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

	const int WorldSize=15;//ashxari chunkeri qanak@ mi komi vra (anpayman kent)
	public int WorldHalfSize=8;//(worldsize+1)/2
	public Chunk[,] Chunks=new Chunk[WorldSize,WorldSize];
	public Chunk Chunk;
	public Chunk StartChunk;
	public PlayerController player;
	int ChunkUpdateRange=1;
	float ChunkSize=5.2f;//Chunki chap@

	int Xsteps;
	int Ysteps;
	int X;
	int Y;
	public Energy EnergyPrefab;
	public Coin CoinPrefab;
	public float MaxEnergyParticles=10;
	public float EnergyParticles=1;
	public int CoinsCount = 0;
	int CoinsMaxCount=10;

	void Start () {
		Chunks [WorldHalfSize,WorldHalfSize] = StartChunk;
	}

	void Update(){
		ChunkUpdate ();
	}

	void ChunkUpdate(){
		for (int x = -ChunkUpdateRange; x <= ChunkUpdateRange; x++) {
			for (int y = -ChunkUpdateRange; y <= ChunkUpdateRange; y++) {
				if (Chunks [player.X + x, player.Y + y] == null)
					NewChunk (player.X + x, player.Y + y);
				else if (!Chunks [player.X + x, player.Y + y].gameObject.activeSelf)
					Chunks [player.X + x, player.Y + y].gameObject.SetActive (true);
			}
		}
	}

	public void NewChunk(int x,int y){
		if (Chunks [x, y] == null) {
			Chunk newChunk = Instantiate (Chunk, new Vector3 ((x - WorldHalfSize) * ChunkSize, (y - WorldHalfSize) * ChunkSize), Quaternion.identity);
			Chunks [x, y] = newChunk;
		} else
			Chunks [x, y].gameObject.SetActive (true);
	}

	public void DeActivateChunks(int x,int y){
		if (x == 0) {
			for(int i=-ChunkUpdateRange;i<=ChunkUpdateRange;i++){
				Chunks [i+player.X, y*(ChunkUpdateRange+1) + player.Y].gameObject.SetActive (false);
			}
		} else {
			for(int i=-ChunkUpdateRange;i<=ChunkUpdateRange;i++){
				Chunks [x*(ChunkUpdateRange+1) + player.X, i+player.Y].gameObject.SetActive (false);
			}
		}
	}

	public void GenerationStep(){
		GenerateCoin ();
		GenerateEnergyParticle ();
	}

	void GenerateEnergyParticle(){
		if (EnergyParticles < MaxEnergyParticles) {
			int x = Random.Range (-6, 6);
			int y = Random.Range (-6, 6);
			while(CellPos(x,y)!=0){
				x = Random.Range (-6, 6);
				y = Random.Range (-6, 6);
			}
			EnergyParticles++;
			Energy NewEnergyParticle = Instantiate (EnergyPrefab, new Vector3 (player.transform.position.x + 0.4f * Random.Range (-6, 6), player.transform.position.y + 0.4f * Random.Range (-6, 6), 0), Quaternion.identity);
			NewEnergyParticle.Game = player.Game;
			NewEnergyParticle.SetCoords (X, Y, Xsteps, Ysteps);
			Chunks [X, Y].Cells [Xsteps, Ysteps] = 1;
		}
	}

	void GenerateCoin(){
		if (CoinsCount < CoinsMaxCount) {
			int x = Random.Range (-5, 5);
			int y = Random.Range (-5, 5);
			while(CellPos(x,y)!=0){
				x = Random.Range (-5, 5);
				y = Random.Range (-5, 5);
			}
			CoinsCount++;
			Coin NewCoin = Instantiate (CoinPrefab, new Vector3 (player.transform.position.x + 0.4f * Random.Range (-6, 6), player.transform.position.y + 0.4f * Random.Range (-6, 6), 0), Quaternion.identity);
			NewCoin.Game = player.Game;
			NewCoin.SetCoords (X, Y, Xsteps, Ysteps);
			Chunks [X, Y].Cells [Xsteps, Ysteps] = 2;
		}
	}

	public int CellPos(int x, int y){
		X = player.X;
		Y = player.Y;
		Xsteps = x;
		Ysteps = y;

		//Debug.Log (X.ToString () + "," + Y.ToString () + "," + Xsteps.ToString () + "," + Ysteps.ToString ());

		if ((Xsteps + player.xSteps) < 0) {
			Xsteps = (Xsteps + (int)player.xSteps) + 13;
			X--;
		} else if ((Xsteps + player.xSteps) > 12) {
			Xsteps = (Xsteps + (int)player.xSteps) - 13;
			X++;
		} else
			Xsteps += (int)player.xSteps;
		if ((Ysteps + player.ySteps) < 0) {
			Ysteps = (Ysteps + (int)player.ySteps) + 13;
			Y--;
		} else if ((Ysteps + player.ySteps) > 12) {
			Ysteps = (Ysteps + (int)player.ySteps) - 13;
			Y++;
		} else
			Ysteps += (int)player.ySteps;

		//Debug.Log (X.ToString () + "," + Y.ToString () + "," + Xsteps.ToString () + "," + Ysteps.ToString ());

		return Chunks [X, Y].Cells [Xsteps, Ysteps];


	}
}
