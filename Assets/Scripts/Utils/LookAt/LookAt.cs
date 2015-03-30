using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public Transform	targetTransform;
	private Transform	lookAtTransform;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void Start(){
		lookAtTransform = this.transform;
	}

	void Update () {
		if (targetTransform != null) {
			lookAtTransform.LookAt(targetTransform.transform.position);
		}
	}
	#endregion
	
	#region METHODS_CUSTOM
	#endregion
	
	#region EVENTS
	#endregion
}
