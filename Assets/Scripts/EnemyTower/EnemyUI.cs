﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public Image	imageHealthFill;

	private LookAt	lookAtUI;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void Awake(){
		lookAtUI = GetComponent<LookAt> ();
		lookAtUI.targetTransform = GameManager.Character.transform;
	}
	#endregion
	
	#region METHODS_CUSTOM
	public void UpdateEnemyUI(float f){
		imageHealthFill.fillAmount = f;
	}
	#endregion
	
	#region EVENTS
	#endregion
}
