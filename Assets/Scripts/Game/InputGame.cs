using UnityEngine;
using System;
using System.Collections;
using Leap;

public class InputGame : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	public static readonly string	ROTATE_AXIS = "Horizontal";
	public static readonly float	ERROR_LEAP_MOTION_YAW_LEFT = -0.1f;
	public static readonly float	ERROR_LEAP_MOTION_YAW_RIGHT = 0.4f;
	public static readonly float	MAX_LEAP_MOTION_YAW = 1f;
	#endregion
	
	#region FIELDS
	public static event Action	onMoveToRight = delegate {};
	public static event Action	onMoveToLeft = delegate {};

	private static LeapRecorder leapRecorder = new LeapRecorder();
	private static Controller 	leapController = null;
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
		if (leapController == null) {
			leapController = new Controller();
		}

		if (leapController == null) {
			DetectKeyBoardEvents ();
		} else {
			Hand hand = leapController.Frame().Hands.Frontmost;

			float yawHand = hand.Direction.Yaw;

			//Debug.Log("yawHand: "+yawHand);
			if (yawHand < MAX_LEAP_MOTION_YAW){
				if (yawHand < ERROR_LEAP_MOTION_YAW_LEFT){
					onMoveToLeft ();
				}else if (yawHand > ERROR_LEAP_MOTION_YAW_RIGHT){
					onMoveToRight();
				}
			}
		}

		//Detect init run of Speederbike
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameManager.StartGame();
		}
	}
	#endregion
	
	#region EVENTS
	#endregion
}
