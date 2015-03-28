using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TestGenerator : MonoBehaviour {

	public GameObject 	prefab;
	public Transform[] 	pointsGenerator;
	public int			totalInstances = 256;
	public float		size;
	public bool			generate = false;

	// Update is called once per frame
	void Update () {
		if (generate){
			for(int index = 0; index<pointsGenerator.Length; index++){
				for (int i=0; i<totalInstances; i++){
					float _x = pointsGenerator[index].position.x + Random.Range(-(size/2f), (size/2f));
					float _z = pointsGenerator[index].position.z + Random.Range(-(size/2f), (size/2f));

					GameObject obj = (GameObject)Instantiate(prefab, new Vector3(_x, 0, _z), Quaternion.identity);
					obj.transform.parent = pointsGenerator[index];
				}
			}
			generate = false;
		}
	}
}
