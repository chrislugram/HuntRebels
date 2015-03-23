using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody> ().velocity = this.transform.forward.normalized*50;
	}
}
