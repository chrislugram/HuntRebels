using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : StateApp {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public Text				labelTimeInGame;
	public ForestGenerator	forestGenerator;
	public GameObject		alertGO;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void Update(){
		if (GameManager.InGame) {
			string value = Util.MilisecondsInClockFormat (GameManager.TimeGame);
			labelTimeInGame.text = value;
			alertGO.SetActive(false);
		}
	}
	#endregion
	
	#region METHODS_CUSTOM
	public override void Activate (){
		base.Activate ();

		Debug.Log("asdfaadfasfadsf");

		labelTimeInGame.text = "00:00";

		forestGenerator.CreateForest ();
	}
	#endregion
	
	#region EVENTS
	public void OnPauseButtonAction(){
		GameManager.Pause ();
	}

	public void OnBeginGameAction(){
		GameManager.StartGame ();
	}
	#endregion
}
