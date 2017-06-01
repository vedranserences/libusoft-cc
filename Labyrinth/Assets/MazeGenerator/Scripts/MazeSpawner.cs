using UnityEngine;
using System.Collections;

//<summary>
//Game object, that creates maze and instantiates it in scene
//</summary>
public class MazeSpawner : MonoBehaviour {
	public enum MazeGenerationAlgorithm{
		PureRecursive,
		RecursiveTree,
		RandomTree,
		OldestTree,
		RecursiveDivision,
	}

	public MazeGenerationAlgorithm Algorithm = MazeGenerationAlgorithm.PureRecursive;
	public bool FullRandom = false;
	public int RandomSeed = 12345;
	public GameObject Floor = null;
	public GameObject Wall = null;
	public GameObject Pillar = null;
	public int Rows = 5;
	public int Columns = 5;
	public float CellWidth = 5;
	public float CellHeight = 5;
	public bool AddGaps = true;
	public GameObject GoalPrefab = null;
	public int NumberOfTraps=5;

	private BasicMazeGenerator mMazeGenerator = null;

	void Start () {
		if (!FullRandom) {
			// Random.seed = RandomSeed;
			Random.InitState(RandomSeed);
		}
		switch (Algorithm) {
		case MazeGenerationAlgorithm.PureRecursive:
			mMazeGenerator = new RecursiveMazeGenerator (Rows, Columns);
			break;
		case MazeGenerationAlgorithm.RecursiveTree:
			mMazeGenerator = new RecursiveTreeMazeGenerator (Rows, Columns);
			break;
		case MazeGenerationAlgorithm.RandomTree:
			mMazeGenerator = new RandomTreeMazeGenerator (Rows, Columns);
			break;
		case MazeGenerationAlgorithm.OldestTree:
			mMazeGenerator = new OldestTreeMazeGenerator (Rows, Columns);
			break;
		case MazeGenerationAlgorithm.RecursiveDivision:
			mMazeGenerator = new DivisionMazeGenerator (Rows, Columns);
			break;
		}
		mMazeGenerator.GenerateMaze ();
		Vector2[] traps=new Vector2[NumberOfTraps];
		for(int i=0;i<NumberOfTraps;i++){
			int x=Random.Range(0,Columns);
			int y=Random.Range(0,Rows);
			while(mMazeGenerator.GetMazeCell(y,x).IsGoal || mMazeGenerator.GetMazeCell(y,x).IsStart || mMazeGenerator.GetMazeCell(y,x).IsEnd){
				x=Random.Range(0,Columns);
				y=Random.Range(0,Rows);
			}
			traps[i]=new Vector2(x,y);
		}
		

		for (int row = 0; row < Rows; row++) {
			for(int column = 0; column < Columns; column++){
				float x = column*(CellWidth+(AddGaps?0.2f:0));
				float z = row*(CellHeight+(AddGaps?0.2f:0));
				MazeCell cell = mMazeGenerator.GetMazeCell(row,column);
				GameObject tmp;
				tmp = Instantiate(Floor,new Vector3(x,0,z), Quaternion.Euler(0,0,0)) as GameObject;
				tmp.transform.localScale=new Vector3(CellHeight,0.1f,CellWidth);
				tmp.transform.parent = transform;

				if(cell.IsStart){
					tmp.GetComponent<Renderer>().material.color=Color.green;
				}
				if(cell.IsEnd){
					tmp.GetComponent<Renderer>().material.color=Color.black;
				}

				foreach(Vector2 v in traps){
					if((int)v.x==column && (int)v.y==row){
						tmp.GetComponent<Renderer>().material.color=Color.red;
					}
				}
				if(cell.WallRight){
					tmp = Instantiate(Wall,new Vector3(x+CellWidth/2,0,z)+Wall.transform.position,Quaternion.Euler(0,90,0)) as GameObject;// right
					tmp.transform.localScale = new Vector3(CellWidth/1.1f, CellHeight*2, 1.001f);
					tmp.transform.parent = transform;
				}
				if(cell.WallFront){
					tmp = Instantiate(Wall,new Vector3(x,0,z+CellHeight/2)+Wall.transform.position,Quaternion.Euler(0,0,0)) as GameObject;// front
					tmp.transform.localScale = new Vector3(CellWidth/1.1f, CellHeight*2, 1.001f);
					tmp.transform.parent = transform;
				}
				if(cell.WallLeft){
					tmp = Instantiate(Wall,new Vector3(x-CellWidth/2,0,z)+Wall.transform.position,Quaternion.Euler(0,270,0)) as GameObject;// left
					tmp.transform.localScale = new Vector3(CellWidth/1.1f, CellHeight*2, 1.001f);
					tmp.transform.parent = transform;
				}
				if(cell.WallBack){
					tmp = Instantiate(Wall,new Vector3(x,0,z-CellHeight/2)+Wall.transform.position,Quaternion.Euler(0,180,0)) as GameObject;// back
					tmp.transform.localScale = new Vector3(CellWidth/1.1f, CellHeight*2, 1.001f);
					tmp.transform.parent = transform;
				}
				if(cell.IsGoal && GoalPrefab != null){
					// tmp = Instantiate(GoalPrefab,new Vector3(x,1,z), Quaternion.Euler(0,0,0)) as GameObject;
					// tmp.transform.parent = transform;
					// Debug.Log("("+cell.x+","+cell.y+")="+cell.distance);
				}
				
			}
		}
		if(Pillar != null){
			for (int row = 0; row < Rows+1; row++) {
				for (int column = 0; column < Columns+1; column++) {
					float x = column*(CellWidth+(AddGaps?0.2f:0));
					float z = row*(CellHeight+(AddGaps?0.2f:0));
					GameObject tmp = Instantiate(Pillar,new Vector3(x-CellWidth/2,0,z-CellHeight/2),Quaternion.identity) as GameObject;
					tmp.transform.localScale = new Vector3(1, CellHeight*2, 1);
					tmp.transform.parent = transform;
				}
			}
		}
	}
}
