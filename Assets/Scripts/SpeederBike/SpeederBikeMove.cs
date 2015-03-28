using UnityEngine;
using System.Collections;

public class SpeederBikeMove : MonoBehaviour {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	public float 			acceleration = 1;
	public float 			accelerationRotation = 5;
	public float 			maxVelocity = 30;
	public float			maxAngleModelRotation = 10;
	public Transform		modelTransform;

	private Vector3			directionMove = Vector3.zero;
	private Rigidbody		rigidbodySB;
	private float			rotateAngle = 0;
	private Spawner			weapon;
	private DetectorFOV		detector;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void Awake(){
		rigidbodySB = this.GetComponent<Rigidbody> ();
		weapon = this.GetComponent<Spawner> ();
		detector = GetComponent<DetectorFOV> ();
		detector.onDetectElement += HandleonDetectElement;
	}

	void Update(){
		UpdateDirection ();
		UpdateSpeed ();
		UpdateModelRotation ();
	}

	void OnCollisionEnter(Collision collision){
		Destroy (this.gameObject);
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
		Gizmos.DrawRay(transform.position, direction);
		
	}
	#endregion
	
	#region METHODS_CUSTOM
	private void UpdateDirection(){
		directionMove = this.transform.forward;
		rotateAngle = 0;

		if (Input.GetKey (KeyCode.A)) {
			directionMove += -this.transform.right;
			rotateAngle = 1;
		} else if (Input.GetKey (KeyCode.D)) {
			directionMove += this.transform.right;
			rotateAngle = -1;
		}

		directionMove = directionMove.normalized;
	}

	private void UpdateModelRotation(){
		if (rotateAngle != 0) {
			modelTransform.localRotation = Quaternion.Lerp (modelTransform.localRotation, Quaternion.Euler (0, 0, maxAngleModelRotation * rotateAngle), Time.deltaTime * accelerationRotation);
		} else {
			modelTransform.localRotation = Quaternion.Lerp (modelTransform.localRotation, Quaternion.identity, Time.deltaTime * accelerationRotation);
		}
	}

	private void UpdateSpeed(){
		rigidbodySB.velocity = Vector3.Lerp (rigidbodySB.velocity, directionMove * maxVelocity, Time.deltaTime * acceleration);
		this.transform.LookAt (this.transform.position + rigidbodySB.velocity.normalized);
	}
	#endregion

	#region EVENTS
	private void HandleonDetectElement (GameObject obj){
		Vector3 direction = obj.transform.position - weapon.spawnPoint [0].position;
		weapon.SpawnElement (direction.normalized);
	}
	#endregion
}
