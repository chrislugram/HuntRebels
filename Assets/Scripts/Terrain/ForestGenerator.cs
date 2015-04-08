using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class ForestGenerator : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	public static readonly float	SCALE_GENERAL_GROUND = 10;
	#endregion
	
	#region FIELDS
	public float			sizeForest = 500;
	public int				sizeGround = 100;
	[SerializeField]
	public NoiseMesh		noiseMesh;	
	public float			sizeSlot = 10;
	public int				distanceDisable = 1;
	public float			distanceQuad = 1;
	public Transform		characterTransform;
	public GameObject		forestSlotPrefab;

	private GameObject[,]	forestSlots;
	private int				previousCellXCharacter;
	private int				previousCellZCharacter;
	private bool			generated = false;
	#endregion
	
	#region ACCESSORS
	public int InitForest{
		get { return (int)((-sizeForest/2)+(sizeSlot/2)); }
	}

	public int EndForest{
		get { return (int)((sizeForest/2)-(sizeSlot/2)); }
	}

	public int InitGround{
		get { return (int)(-sizeForest/2); }
	}
	
	public int EndGround{
		get { return (int)(sizeForest/2); }
	}

	public int ForestSlotLenght{
		get { return (int)(sizeForest/sizeSlot); }
	}
	#endregion
	
	#region METHODS_UNITY
	void Update(){
		//Codigo real, comprobando la posicion del Personaje
		if (generated && (characterTransform != null)) {
			int cellXCharacter = Mathf.Abs(Mathf.RoundToInt (InitForest - (characterTransform.position.x))); //  (((sizeSquad/2f)-parentForest.transform.position.x) / sizeSquad);
			cellXCharacter = cellXCharacter / (int)sizeSlot;
			
			int cellZCharacter = Mathf.Abs(Mathf.RoundToInt (InitForest - (characterTransform.position.z)));
			cellZCharacter = cellZCharacter / (int)sizeSlot;
			
			if ((cellXCharacter != previousCellXCharacter) || (cellZCharacter != previousCellZCharacter)){
				UpdateForest(cellXCharacter, cellZCharacter);
			}
		}
	}
	#endregion
	
	#region METHODS_CUSTOM
	public void CreateForest(){
		previousCellXCharacter = -1;
		previousCellZCharacter = -1;
		CreateGround ();
		GenerateForestSlots ();
		CreateCharacter();
		GenerateEnemies ();

		generated = true;
	}

	public void CreateGround(){
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

		//1.- Vertices
		Vector3[] vertices = new Vector3[ sizeGround * sizeGround ];
		for(int z = 0; z < sizeGround; z++){
			float zPos = ((float)z / (sizeGround - 1) - .5f)*sizeForest;
			for(int x = 0; x < sizeGround; x++){
				float xPos = ((float)x / (sizeGround - 1) - .5f)*sizeForest;
				vertices[ x + z * sizeGround ] = new Vector3( xPos, 0f, zPos );
			}
		}

		//2.- Normals
		Vector3[] normals = new Vector3[ vertices.Length ];
		for (int n = 0; n < normals.Length; n++) {
			normals [n] = Vector3.up;
		}

		//3.- UVs
		Vector2[] uvs = new Vector2[ vertices.Length ];
		for(int v = 0; v < sizeGround; v++){
			for(int u = 0; u < sizeGround; u++){
				uvs[ u + v * sizeGround ] = new Vector2( (float)u / (sizeGround - 1), (float)v / (sizeGround - 1) );
			}
		}

		//4.- Triangles
		int nbFaces = (sizeGround - 1) * (sizeGround - 1);
		int[] triangles = new int[ nbFaces * 6 ];
		int t = 0;
		for(int face = 0; face < nbFaces; face++ ){
			int i = face % (sizeGround - 1) + (face / (sizeGround - 1) * sizeGround);
			
			triangles[t++] = i + sizeGround;
			triangles[t++] = i + 1;
			triangles[t++] = i;
			
			triangles[t++] = i + sizeGround;	
			triangles[t++] = i + sizeGround + 1;
			triangles[t++] = i + 1; 
		}

		mesh.vertices = vertices;
		mesh.normals = normals;
		mesh.uv = uvs;
		mesh.triangles = triangles;
		
		mesh = noiseMesh.ApplyNoise (mesh);

		mesh.Optimize();
	}

	public void GenerateForestSlots(){	
		forestSlots = new GameObject[this.ForestSlotLenght, this.ForestSlotLenght];

		int iIndex = 0;

		for (int i = this.InitForest; i<=this.EndForest; i += (int)sizeSlot, iIndex++) {
			int jIndex = 0;

			for (int j = this.InitForest; j<=this.EndForest; j += (int)sizeSlot, jIndex++) {
				forestSlots[iIndex, jIndex] = CreateForestSlot(i, j);
				forestSlots[iIndex, jIndex].GetComponent<ForestSlot>().Init(iIndex, jIndex, (int)sizeSlot);
			}
		}
	}

	public void CreateCharacter(){
		characterTransform = GameManager.CreateCharacter ().transform;

		int indexX = UnityEngine.Random.Range (0, this.ForestSlotLenght);
		int indexZ = UnityEngine.Random.Range (0, this.ForestSlotLenght);

		characterTransform.position = forestSlots [indexX, indexZ].transform.position;
		forestSlots [indexX, indexZ].GetComponent<ForestSlot> ().SetCharacter ();
	}

	public void GenerateEnemies(){
		int totalEnemiesCreated = 0;
		while (totalEnemiesCreated < GameManager.CurrentGame.totalEnemies) {
			int indexX = UnityEngine.Random.Range (0, this.ForestSlotLenght);
			int indexZ = UnityEngine.Random.Range (0, this.ForestSlotLenght);

			if (!forestSlots[indexX, indexZ].GetComponent<ForestSlot>().HasEnemy && !forestSlots[indexX, indexZ].GetComponent<ForestSlot>().InitWithCharacter){
				forestSlots[indexX, indexZ].GetComponent<ForestSlot>().SetEnemy(GameManager.CreateEnemy());
				totalEnemiesCreated++;
			}
		}
	}

	private GameObject CreateForestSlot(int x, int z){
		GameObject forestSlotGO = (GameObject)Instantiate (forestSlotPrefab, new Vector3 (x, 0, z), Quaternion.identity);
		forestSlotGO.transform.parent = this.transform;

		return forestSlotGO;
	}

	public void UpdateForest(int newCellX, int newCellZ){
		//Debug.Log (" " + newCellX + ", " + newCellZ);
		for (int i=0; i<this.ForestSlotLenght; i++) {
			for(int j=0; j<this.ForestSlotLenght; j++){
				ForestSlot forestSlot = forestSlots[i, j].GetComponent<ForestSlot>();

				if (!forestSlot.HasEnemy && !forestSlot.InitWithCharacter){

					if (forestSlot.IsActivated && (forestSlot.DistanceOf (newCellX, newCellZ) > distanceDisable)){
						forestSlot.Off();
					}else if (forestSlot.DistanceOf (newCellX, newCellZ) <= distanceDisable){
						forestSlot.On();
					}else{
						forestSlot.Off();
					}
				}
			}
		}

		previousCellXCharacter = newCellX;
		previousCellZCharacter = newCellZ;
	}
	#endregion
	
	#region METHODS_EVENT
	#endregion
}
