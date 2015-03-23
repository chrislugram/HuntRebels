using UnityEngine;
using System.Collections;

public class EnemyRandomPoints : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public Transform	planeReference;
	[Range (0, 0.5f)]
	public float		innerEdge;
	[Range (0, 0.5f)]
	public float		outerEdge;
	[Range (1, 500)]
	public int			totalPoints;
	public GameObject	prefabPoint;

	private Transform[]	childs;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void Update(){
		if (Input.GetKeyDown (KeyCode.P)) {
			OnGameInitAction();
		}
	}
	#endregion
	
	#region METHODS_CUSTOM
	#endregion
	
	#region EVENTS
	public void OnGameInitAction(){
		childs = new Transform[totalPoints];

		for (int i = 0; i < totalPoints; i++) {
			Vector3 position = Vector3.zero;

			float absX = UnityEngine.Random.Range ((planeReference.localScale.x/2f) * innerEdge, (planeReference.localScale.x/2f) - ((planeReference.localScale.x/2f) * outerEdge));
			float absY = UnityEngine.Random.Range ((planeReference.localScale.y/2f) * innerEdge, (planeReference.localScale.y/2f) - ((planeReference.localScale.y/2f) * outerEdge));

			float signX = UnityEngine.Random.Range(-1f, 1f);
			float signY = UnityEngine.Random.Range(-1f, 1f);

			if (signX > 0){
				position.x = absX;
			}else{
				position.x = -absX;
			}

			if (signY > 0){
				position.z = absY;
			}else{
				position.z = -absY;
			}

			GameObject instantPoint = (GameObject)Instantiate(prefabPoint, position, Quaternion.identity);
			childs[i] = instantPoint.transform;
		}
	}
	#endregion
}
