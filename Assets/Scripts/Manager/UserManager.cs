using UnityEngine;
using System.Collections;

public static class UserManager {
	#region STATIC_ENUM_CONSTANTS
	public static readonly string PREFIX_PLAYER_PREF = "GAME_";
	#endregion
	
	#region FIELDS
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_CUSTOM
	public static int GetBestTimeOf(int totalEnemies){
		string keyPlayerPref = PREFIX_PLAYER_PREF + totalEnemies;

		if (PlayerPrefs.HasKey (keyPlayerPref)) {
			return PlayerPrefs.GetInt (keyPlayerPref);
		} else {
			return int.MaxValue;
		}
	}

	public static void SetBestTimeOf(int totalEnemies, int totalMiliseconds){
		string keyPlayerPref = PREFIX_PLAYER_PREF + totalEnemies;

		PlayerPrefs.SetInt (keyPlayerPref, totalMiliseconds);
		PlayerPrefs.Save ();
	}
	#endregion
	
	#region METHODS_EVENT
	#endregion
}
