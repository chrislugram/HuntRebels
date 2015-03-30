using UnityEngine;
using System.Collections;

public class EnemyTower : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	public enum STATE_TOWER{
		WAITING = 0,
		SHOOT	= 1,
		RELOAD	= 2,
	}
	#endregion
	
	#region FIELDS
	public STATE_TOWER						stateTower = STATE_TOWER.WAITING;
	public float							reloadTime = 1;
	public DetectorFOV						detector;
	public EnemyUI							enemyUI;

	protected Spawner						weapon;
	protected Transform						towerTransform;
	protected Transform						characterTransform;
	protected EnemyTowerAnimationController	animationController;
	protected Health						healthEnemy;

	protected float 						currentReloadTime = 0;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void Awake(){
		detector.onDetectElement += HandleonDetectElement;
		detector.onNothingDetected += HandleonNothingDetected;
		
		weapon = GetComponent<Spawner> ();
		animationController = GetComponent<EnemyTowerAnimationController> ();
		healthEnemy = GetComponent<Health> ();
		healthEnemy.onDeath += HandleonDeath;
		healthEnemy.onReciveDamage += HandleonReciveDamage;

		enemyUI.UpdateEnemyUI (1);
	}

	void OnDestroy(){
		detector.onDetectElement -= HandleonDetectElement;
		detector = null;

		weapon = null;

		animationController = null;
	}

	void Update(){
		if (stateTower == STATE_TOWER.WAITING) {
			SearchCharacter ();

			if (characterTransform != null) {
				stateTower = STATE_TOWER.RELOAD;
			}
		} else if (stateTower == STATE_TOWER.RELOAD) {
			if (characterTransform == null) {
				stateTower = STATE_TOWER.WAITING;
				return;
			}

			LookAtCharacter ();

			if (currentReloadTime < reloadTime) {
				currentReloadTime += Time.deltaTime;
			} else {
				stateTower = STATE_TOWER.SHOOT;
				return;
			}
		} else if (stateTower == STATE_TOWER.SHOOT) {
			currentReloadTime = 0;
			weapon.SpawnElement(animationController.headTower.forward);
			stateTower = STATE_TOWER.WAITING;
		}

	}
	#endregion
	
	#region METHODS_CUSTOM
	protected virtual void SearchCharacter(){
		animationController.Search ();
	}

	protected virtual void LookAtCharacter(){
		animationController.LookAt (characterTransform);
	}
	#endregion
	
	#region EVENTS
	protected void HandleonReciveDamage (float percHealth){
		enemyUI.UpdateEnemyUI (percHealth);
	}

	protected void HandleonDeath (){
		GameManager.EnemyDestroyed ();
		Destroy (this.gameObject);
	}

	protected void HandleonDetectElement (GameObject obj){
		if (characterTransform == null) {
			characterTransform = obj.transform;
		}
	}

	protected void HandleonNothingDetected (){
		characterTransform = null;
	}
	#endregion
}
