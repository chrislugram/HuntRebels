using UnityEngine;
using System.Collections;

public class EnemyTowerAnimationController : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public float		rotationSpeed = 5;
	public Transform	headTower;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	#endregion
	
	#region METHODS_CUSTOM
	public void Search(){
		Quaternion newRotation = Quaternion.Euler (0, headTower.rotation.eulerAngles.y+10, 0);

		headTower.rotation = Quaternion.Lerp (headTower.rotation, newRotation, Time.deltaTime * rotationSpeed);
	}
	
	public void LookAt(Transform target){
		Vector3 relativePos = target.position - headTower.position;
		Quaternion newRotation = Quaternion.LookRotation(relativePos);

		headTower.rotation = Quaternion.Lerp (headTower.rotation, newRotation, Time.deltaTime * rotationSpeed);
	}
	#endregion
	
	#region EVENTS
	#endregion
}
