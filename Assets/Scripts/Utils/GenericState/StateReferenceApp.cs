using UnityEngine;
using System.Collections;

public class StateReferenceApp {
	#region STATIC_ENUM_CONSTANTS
	public static readonly string	INIT_MENU					= "InitMenuState";
	public static readonly string	MAIN_MENU					= "MainMenuState";
	public static readonly string	GAME						= "GameState";
	public static readonly string	END							= "EndState";

	public static readonly string	POPUP_ALERT					= "PopupErrorState";
	
	public enum TYPE_STATE{
		GAME						= 0,
		MAIN_MENU					= 1,
		INIT_MENU					= 2,
		END							= 3
	}

	public enum POPUP_TYPE_STATE{
		POPUP_ALERT					= 0,
	}
	#endregion
	
	#region FIELDS
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	#endregion
	
	#region METHODS_CUSTOM
	#endregion
}
