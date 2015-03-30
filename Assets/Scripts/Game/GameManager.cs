using UnityEngine;
using System.Collections;

public static class GameManager {
	#region STATIC_ENUM_CONSTANTS
	public static readonly string	PATH_ENEMY_PREFAB = "Game/Enemy/EnemyTower";
	public static readonly string	PATH_CHARACTER_PREFAB = "Game/Character/SpeederBike";
	#endregion
	
	#region FIELDS
	private static Game			currentGame;
	private static GameStats	currentGameStats;
	private static GameObject	enemyPrefab;
	private static GameObject	characterGO;
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

	public static GameObject Character{
		get{ return characterGO; }
	}
	#endregion
	
	#region METHODS_CUSTOM
	public static GameObject CreateCharacter(){
		if (characterGO == null){
			GameObject characterPrefab = (GameObject)Resources.Load(PATH_CHARACTER_PREFAB);
			characterGO = (GameObject) GameObject.Instantiate(characterPrefab);
		}
		
		return characterGO;
	}

	public static GameObject CreateEnemy(){
		if (enemyPrefab == null){
			enemyPrefab = (GameObject)Resources.Load(PATH_ENEMY_PREFAB);
		}

		return (GameObject) GameObject.Instantiate(enemyPrefab);
	}

	public static void EnemyDestroyed(){
		currentGameStats.totalEnemyDestroyed++;

		if (currentGameStats.totalEnemyDestroyed == currentGame.totalEnemies) {
			GameWin();
		}
	}

	private static void GameWin(){
		Debug.Log("Gana el jugador");
	}

	private static void GameFail(){
		Debug.Log("Pierde el jugador");
	}
	#endregion
	
	#region METHODS_EVENT
	#endregion
}
