using UnityEngine;
using System.Collections;

public class InitState : StateApp {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	#endregion
	
	#region METHODS_CUSTOM
	#endregion

	#region EVENTS
	public void OnStartButtonAction(){
		rootApp.ChangeState (StateReferenceApp.TYPE_STATE.MAIN_MENU);
	}
	#endregion
}
