using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public GameObject[]			spawnElementsPrefab;
	public Vector2				rangeTimeSpawn;
	public Transform[]			spawnPoint;
	public bool					automatic;
	public event Action			onSpawnElement = delegate {};
	public event Action			onReady = delegate{};
	public event Action			onEnqueueElement = delegate {};


	protected bool				reloadSpawn = true;
	protected Queue<GameObject>	spawnElements = new Queue<GameObject>();
	protected int				totalSpawnerElementCreated = 0;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void FixedUpdate(){
		if (automatic){
			SpawnElement();
		}
	}
	#endregion
	
	#region METHODS_CUSTOM
	public virtual void SpawnElement(Vector3 direction = default(Vector3)){
		if (reloadSpawn){
			reloadSpawn = false;

			GameObject spawnElementGO = GetSpawnElement ();

			if (direction != Vector3.zero){
				spawnElementGO.transform.forward = direction;
			}

			SpawnElementAction (spawnElementGO);
			onSpawnElement();
		}
	}

	public virtual void AddSpawnElementToCache(GameObject spawnElementGO){
		spawnElements.Enqueue (spawnElementGO);
		onEnqueueElement ();
	}

	protected virtual void SpawnElementAction(GameObject spawnElementGO){
		spawnElementGO.GetComponent<SpawnElement>().Initialized (this);

		float randomTime = UnityEngine.Random.Range (rangeTimeSpawn.x, rangeTimeSpawn.y);
		Invoke ("Reload", randomTime);
	}

	protected void Reload(){
		reloadSpawn = true;

		onReady ();
	}

	protected virtual GameObject GetSpawnElement(){
		
		GameObject spawnElementInstance = null;

		Transform spawnPointSelected = spawnPoint [UnityEngine.Random.Range (0, spawnPoint.Length-1)];

		if (spawnElements.Count == 0){
			int randomElement = UnityEngine.Random.Range(0, spawnElementsPrefab.Length-1);

			spawnElementInstance = (GameObject)Instantiate(spawnElementsPrefab[randomElement], spawnPointSelected.position, Quaternion.identity);
			spawnElementInstance.name = spawnElementInstance.name+"_"+totalSpawnerElementCreated;
			totalSpawnerElementCreated++;
		}else{
			spawnElementInstance = spawnElements.Dequeue();
			if (spawnElementInstance != null && spawnPointSelected != null){
				spawnElementInstance.transform.position = spawnPointSelected.position;
				spawnElementInstance.transform.rotation = Quaternion.identity;
				spawnElementInstance.SetActive(true);
			}
		}
		
		return spawnElementInstance;
	}
	#endregion
}