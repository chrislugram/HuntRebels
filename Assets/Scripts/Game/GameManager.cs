using UnityEngine;
using System.Collections;

public static class GameManager {
	#region STATIC_ENUM_CONSTANTS
	public static readonly string	PATH_ENEMY_PREFAB = "Game/Enemy/EnemyTower";
	#endregion
	
	#region FIELDS
	private static Game			currentGame;
	private static GameStats	currentGameStats;
	private static GameObject	enemyPrefab;
	#endregion
	
	#region ACCESSORS
	public static Game CurrentGame{
		get{
			if (currentGame == null){
				currentGame = new Game();
				currentGameStats = new GameStats();
			}
			return currentGame;
		}
	}
	#endregion
	
	#region METHODS_CUSTOM
	public static GameObject CreateEnemy(){
		if (enemyPrefab == null){
			enemyPrefab = (GameObject)Resources.Load(PATH_ENEMY_PREFAB);
		}

		return (GameObject) GameObject.Instantiate(enemyPrefab);
	}
	#endregion
	
	#region METHODS_EVENT
	#endregion
}
