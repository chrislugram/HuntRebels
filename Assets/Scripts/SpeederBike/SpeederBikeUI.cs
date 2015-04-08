using UnityEngine;
using System.Collections;

public class SpeederBikeUI : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public GameObject	arrowGO;

	private Transform	targetEnemy = null;
	private bool		noMorEnemies = false;
	private Vector3		vectorLookAt = Vector3.zero;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void Update(){
		if (targetEnemy == null && !noMorEnemies) {
			targetEnemy = GameManager.GetNearEnemy(arrowGO.transform.position);

			if (targetEnemy == null){
				noMorEnemies = true;
			}else{
				vectorLookAt = targetEnemy.position - arrowGO.transform.position;
				Debug.Log("Posicion enemigo: "+targetEnemy.position+", "+targetEnemy.gameObject.name);
			}
		}

		if (!noMorEnemies) {
			arrowGO.transform.LookAt(targetEnemy.position);
		}
	}
	#endregion
	
	#region METHODS_CUSTOM
	#endregion
	
	#region EVENTS
	#endregion
}
