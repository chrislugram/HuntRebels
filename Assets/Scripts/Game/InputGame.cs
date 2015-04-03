using UnityEngine;
using System;
using System.Collections;

public class InputGame : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	public static readonly string	ROTATE_AXIS = "Horizontal";
	#endregion
	
	#region FIELDS
	public static event Action	onMoveToRight = delegate {};
	public static event Action	onMoveToLeft = delegate {};
	#endregion
	
	#region ACCESSORS
	/*public static bool MoveToRight(){
		return (Input.GetAxis (ROTATE_AXIS) > 0);
	}

	public static bool MoveToLeft(){
		return (Input.GetAxis (ROTATE_AXIS) < 0);
	}
	*/
	#endregion
	
	#region METHODS_UNITY
	public void Update(){
		if (GameManager.InputMode == GameManager.INPUT_MODE.KEYBOARD) {
			DetectKeyBoardEvents ();
		} else if (GameManager.InputMode == GameManager.INPUT_MODE.LEAP_MOTION){
			DetectLeapMotionEvents();
		}
	}
	#endregion
	
	#region METHODS_CUSTOM
	public static void DetectKeyBoardEvents(){
		//Detect rotation in Speederbike
		if (Input.GetKey (KeyCode.A)) {
			onMoveToLeft ();
		} else if (Input.GetKey (KeyCode.D)) {
			onMoveToRight();
		}

		//Detect init run of Speederbike
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameManager.StartGame();
		}
	}

	public static void DetectLeapMotionEvents(){
	}
	#endregion
	
	#region EVENTS
	#endregion
}
