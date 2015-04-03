using UnityEngine;
using System.Collections;

public static class GameManager {
	#region STATIC_ENUM_CONSTANTS
	public static readonly string	PATH_ENEMY_PREFAB = "Game/Enemy/EnemyTower";
	public static readonly string	PATH_CHARACTER_PREFAB = "Game/Character/SpeederBike";

	public enum INPUT_MODE{
		KEYBOARD = 0,
		LEAP_MOTION = 1
	}
	#endregion
	
	#region FIELDS
	private static Game				currentGame;
	private static GameStats		currentGameStats;
	private static GameObject		enemyPrefab;
	private static GameObject		characterGO;
	private static INPUT_MODE		inputMode;
	private static bool				pauseFlag;
	private static bool				inGameFlag;
	private static CoroutineTask	timeTask;
	#endregion
	
	#region ACCESSORS
	public static Game CurrentGame{
		get{
			if (currentGame == null){
				currentGame = new Game();
				currentGameStats = new GameStats();
				Console.Warning("GAME IN EDIT MODE...");
			}
			return currentGame;
		}
	}

	public static GameObject Character{
		get{ return characterGO; }
	}

	public static INPUT_MODE	InputMode{
		get{ return inputMode; }
		set{ inputMode = value; }
	}

	public static int	TimeGame{
		get{ return currentGameStats.timeGame; }
	}

	public static bool	InGame{
		get { return inGameFlag; }
	}
	#endregion
	
	#region METHODS_CUSTOM
	public static void SetGame(Game game){
		currentGame = game;
		currentGameStats = new GameStats ();
	}

	public static void StartGame(){
		if (characterGO.GetComponent<SpeederBike> ().Waiting) {
			characterGO.GetComponent<SpeederBike> ().Run (currentGame.maxSpeed);
			timeTask = TaskManager.Launch (TimeCounter ());
		}
	}

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

	public static void Pause(){
		if (pauseFlag) {
			pauseFlag = false;
			Time.timeScale = 1;
		} else {
			pauseFlag = true;
			Time.timeScale = 0;
		}
	}

	private static void GameWin(){
		Debug.Log("Gana el jugador");
		timeTask.Stop ();
	}

	private static void GameFail(){
		Debug.Log("Pierde el jugador");
		timeTask.Stop ();
	}

	private static IEnumerator TimeCounter(){
		while (true) {
			yield return new WaitForSeconds(0.1f);

			currentGameStats.timeGame += 100;
		}
	}
	#endregion
	
	#region METHODS_EVENT
	#endregion
}
