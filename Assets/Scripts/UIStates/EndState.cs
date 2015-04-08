using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndState : StateApp {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public Text	textWinFail;
	public Text textTime;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	#endregion
	
	#region METHODS_CUSTOM
	public override void Activate (){
		base.Activate ();

		if (GameManager.WinGame) {
			textWinFail.text = "YOU WIN";

			int maxMiliseconds = UserManager.GetBestTimeOf (GameManager.CurrentGame.totalEnemies);
			
			if (maxMiliseconds > GameManager.TimeGame) {
				UserManager.SetBestTimeOf(GameManager.CurrentGame.totalEnemies, GameManager.TimeGame);
			}
		} else {
			textWinFail.text = "YOU FAIL";
		}

		textTime.text = Util.MilisecondsInClockFormat (GameManager.TimeGame);
	}
	#endregion
	
	#region EVENTS
	public void OnRetryButtonAction(){
		GameManager.ResetStats ();
		rootApp.ChangeState (StateReferenceApp.TYPE_STATE.GAME, AppScenes.SCENE_GAME);
	}

	public void OnChangeLevelButtonAction(){
		rootApp.ChangeState (StateReferenceApp.TYPE_STATE.MAIN_MENU, AppScenes.SCENE_MAIN_MENU);
	}
	#endregion
}
