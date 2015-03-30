using UnityEngine;
using System;
using System.Collections;

public class InputGame : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	public static readonly string	ROTATE_AXIS = "Horizontal";
	#endregion
	
	#region FIELDS
	#endregion
	
	#region ACCESSORS
	public static bool MoveToRight(){
		return (Input.GetAxis (ROTATE_AXIS) > 0);
	}

	public static bool MoveToLeft(){
		return (Input.GetAxis (ROTATE_AXIS) < 0);
	}
	#endregion
	
	#region METHODS_UNITY
	#endregion
	
	#region METHODS_CUSTOM
	#endregion
	
	#region EVENTS
	#endregion
}
