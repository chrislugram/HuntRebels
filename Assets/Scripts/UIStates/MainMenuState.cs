using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuState : StateApp {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public Text		labelTotalEnemies;
	public Text		labelMaxSpeed;
	public Text		labelBestTime;

	private Game	newGame;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	#endregion
	
	#region METHODS_CUSTOM
	public override void Activate (){
		base.Activate ();

		GameManager.InputMode = GameManager.INPUT_MODE.KEYBOARD;

		newGame = new Game ();

		int maxMiliSeconds = UserManager.GetBestTimeOf (newGame.totalEnemies);
		if (maxMiliSeconds == int.MaxValue) {
			labelBestTime.text = "--:--";
		} else {
			labelBestTime.text = Util.MilisecondsInClockFormat(maxMiliSeconds);
		}
	}
	#endregion
	
	#region EVENTS
	public void OnInputModeChange(int inputModeIndex){
		GameManager.InputMode = (GameManager.INPUT_MODE)inputModeIndex;
	}

	public void OnTotalEnemiesChange(Slider sliderTotalEnemies){
		newGame.totalEnemies = (int)sliderTotalEnemies.value;

		labelTotalEnemies.text = "" + newGame.totalEnemies;

		int maxMiliSeconds = UserManager.GetBestTimeOf (newGame.totalEnemies);
		if (maxMiliSeconds == int.MaxValue) {
			labelBestTime.text = "--:--";
		} else {
			labelBestTime.text = Util.MilisecondsInClockFormat(maxMiliSeconds);
		}
	}

	public void OnMaxSpeedChange(Slider sliderMaxSpeed){
		newGame.maxSpeed = (int)sliderMaxSpeed.value;
		labelMaxSpeed.text = "" + newGame.maxSpeed;
	}

	public void OnPlayButtonAction(){
		GameManager.SetGame (newGame);
		rootApp.ChangeState (StateReferenceApp.TYPE_STATE.GAME, AppScenes.SCENE_GAME);
	}
	#endregion
}
