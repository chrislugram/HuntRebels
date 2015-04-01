using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : StateApp {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public Text	labelTimeInGame;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void Update(){
		if (GameManager.InGame) {
			labelTimeInGame.text = Util.MilisecondsInClockFormat (GameManager.Time);
		}
	}
	#endregion
	
	#region METHODS_CUSTOM
	#endregion
	
	#region EVENTS
	public void OnPauseButtonAction(){
		GameManager.Pause ();
	}
	#endregion
}
