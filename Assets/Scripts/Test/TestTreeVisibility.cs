using UnityEngine;
using System.Collections;

public class TestTreeVisibility : MonoBehaviour {

	private Renderer	myRenderer;

	void Awake(){
		myRenderer = this.GetComponent<Renderer> ();
	}

	void OnBecameVisible() {
		myRenderer.enabled = true;
	}
	
	void OnBecameInvisible() {
		myRenderer.enabled = false;
	}
}
