using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HuntRebelsRoot : RootApp {
	#region STATIC_ENUM_CONSTANTS
	#endregion
		
	#region FIELDS
	#endregion
		
	#region ACCESSORS
	#endregion
		
	#region METHODS_UNITY
	#endregion
		
	#region METHODS_CUSTOM
	protected override void InitRootApp (){
		//Inicializo Sistemas
		TaskManager.Init ();
		//PlayerPrefs.DeleteAll ();
			
		//Inicializamos los estados
		states = new Dictionary<StateReferenceApp.TYPE_STATE, string> ();
		popupStates = new Dictionary<StateReferenceApp.POPUP_TYPE_STATE, string> ();
			
		//Añadimos los estados
		states.Add (StateReferenceApp.TYPE_STATE.INIT_MENU, StateReferenceApp.INIT_MENU);
		states.Add (StateReferenceApp.TYPE_STATE.MAIN_MENU, StateReferenceApp.MAIN_MENU);
		states.Add (StateReferenceApp.TYPE_STATE.GAME, StateReferenceApp.GAME);
		states.Add (StateReferenceApp.TYPE_STATE.END, StateReferenceApp.END);
		/*states.Add (StateReferenceApp.TYPE_STATE.CONFIGURE_STAGE_STATE, StateReferenceApp.CONFIGURE_STAGE_STATE);
		states.Add (StateReferenceApp.TYPE_STATE.GAME_STATE, StateReferenceApp.GAME_STATE);
		states.Add (StateReferenceApp.TYPE_STATE.WIN_GAME_STATE, StateReferenceApp.WIN_GAME_STATE);
		states.Add (StateReferenceApp.TYPE_STATE.FAIL_GAME_STATE, StateReferenceApp.FAIL_GAME_STATE);
		*/	
		//Añadimos los popup
		//popupStates.Add (StateReferenceApp.POPUP_TYPE_STATE.POPUP_ALERT, StateReferenceApp.POPUP_ALERT);
			
		//Cargo la primera escena
		ChangeState (currentTypeState, AppScenes.SCENE_MAIN_MENU);
	}
	#endregion
}
