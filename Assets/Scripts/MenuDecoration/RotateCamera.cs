using UnityEngine;
using System.Collections;

public class RotateCamera: MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public float speedRotation = 1;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void Update(){
		this.transform.Rotate (0, speedRotation, 0);
	}
	#endregion
	
	#region METHODS_CUSTOM
	#endregion
	
	#region EVENTS
	#endregion
}
