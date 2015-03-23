using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GSRoot : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	public enum INIT_MODE{
		NONE 			= 0,
		CLEAR_ALL		= 1,
		CLEAR_PREVIOUS	= 2,
		STACK			= 3
	}
	#endregion
	
	#region FIELDS
	public static GSRoot												Instance;

	public StateApp														currentState;
	
	protected Dictionary<GSStateReference.TYPE_STATE, GSState>			states; 
	protected Stack<StateApp>											stackStates;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void Awake(){
		DontDestroyOnLoad (this.gameObject);

		states = new Dictionary<GSStateReference.TYPE_STATE, GSState> ();
		stackStates = new Stack<StateApp> ();
		
		GSRoot.Instance = this;
		
		//InitRootApp();
	}
	
	void OnDestroy(){
		GSRoot.Instance = null;

		states.Clear();
		states = null;

		stackStates.Clear ();
		stackStates = null;
	}
	#endregion
	
	#region METHODS_CUSTOM
	public virtual void AddState(GSStateReference.TYPE_STATE typeState, GSState state){
		if (!states.ContainsKey(typeState)){
			states.Add(typeState, state);
		}
	}

	public virtual void InitState(GSStateReference.TYPE_STATE typeState, INIT_MODE mode = INIT_MODE.NONE){
		if (mode == INIT_MODE.NONE) {
			states[typeState].Activate();
			//stackStates.
		}
	}
	#endregion
}
