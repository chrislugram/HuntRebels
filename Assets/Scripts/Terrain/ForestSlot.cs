using UnityEngine;
using System;
using System.Collections;

public class ForestSlot : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	[Serializable]
	public class ForestPrefab{
		public GameObject[]	treePrefabs;
		public GameObject[] particlePrefabs;

		public int			totalTrees;
		public int			totalParticles;
	}
	#endregion
	
	#region FIELDS
	[SerializeField]
	public ForestPrefab		forestPrefab;

	private GameObject 		instanceEnemy = null;
	private bool			activate = false;
	private int				cellX = -1;
	private int				cellZ = -1;
	private int				sizeSlot;

	private GameObject[]	treeDecorations;

	private bool			initWithCharacter = false;
	#endregion
	
	#region ACCESSORS
	public bool HasEnemy{
		get { return (instanceEnemy != null); }
	}

	public bool InitWithCharacter{
		get { return initWithCharacter; } 
	}

	public bool IsActivated{
		get{ return activate; }
	}
	#endregion
	
	#region METHODS_UNITY
	#endregion
	
	#region METHODS_CUSTOM
	public void SetCharacter(){
		initWithCharacter = true;
		activate = true;
	}

	public void SetEnemy(GameObject instance){
		instanceEnemy = instance;
		instanceEnemy.transform.position = this.transform.position;
		activate = true;
	}

	public void Init(int x, int z, int sizeSlot){
		SetIndexPosition (x, z);
		this.sizeSlot = sizeSlot;
		treeDecorations = new GameObject[0];
	}

	public int DistanceOf(int newCellX, int newCellZ){
		int distanceX = Mathf.Abs(cellX - newCellX);
		int distanceY = Mathf.Abs(cellZ - newCellZ);
		
		int distance = Mathf.Max (distanceX, distanceY);
		
		//Debug.Log ("Distance to " + this.name + ": " + distance);
		
		return distance;
	}

	public void On(){
		if (!activate) {
			if (treeDecorations.Length == 0) {
				CreateRandomTrees ();
			} else {
				for(int i=0; i<treeDecorations.Length; i++){
					treeDecorations[i].SetActive(true);
				}
			}

			activate = true;
		}
	}

	public void Off(){
		if (activate) {
			for(int i=0; i<treeDecorations.Length; i++){
				treeDecorations[i].SetActive(false);
			}

			activate = false;
		}
	}

	private void CreateRandomTrees(){
		treeDecorations = new GameObject[forestPrefab.totalTrees];
		
		for(int i=0; i<forestPrefab.totalTrees; i++){
			GameObject prefabSelected = forestPrefab.treePrefabs[UnityEngine.Random.Range(0, forestPrefab.treePrefabs.Length)];
			GameObject treeGO = (GameObject)Instantiate(
				prefabSelected, 
				new Vector3(this.transform.position.x + UnityEngine.Random.Range((float)(-sizeSlot/2f), (float)(sizeSlot/2f)), UnityEngine.Random.Range(-0.2f, -1.5f), this.transform.position.z + UnityEngine.Random.Range((float)(-sizeSlot/2f), (float)(sizeSlot/2f))),
				Quaternion.identity);
			treeGO.transform.parent = this.transform;
			treeDecorations[i] = treeGO;
		}

		//Debug.Log ("Identity: " + Quaternion.identity);
	}

	private void SetIndexPosition(int x, int z){
		this.name = "ForestSlot[" + x + "," + z + "]";
		cellX = x;
		cellZ = z;
	}				
	#endregion
	
	#region METHODS_EVENT
	#endregion
}
