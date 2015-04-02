using UnityEngine;
using System.Collections;

public class SpeederBike : MonoBehaviour {
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
	private bool			runFlag = false;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_UNITY
	void Awake(){
		rigidbodySB = this.GetComponent<Rigidbody> ();
		weapon = this.GetComponent<Spawner> ();
		detector = GetComponent<DetectorFOV> ();
		detector.onDetectElement += HandleonDetectElement;

		runFlag = false;
	}

	void Update(){
		UpdateDirection ();
		if (runFlag) {
			UpdateSpeed ();
		}
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
	public void Run(){
		runFlag = true;
	}

	private void UpdateDirection(){
		Vector3 newDirectionMove = this.transform.forward;
		rotateAngle = 0;

		if (Input.GetKey (KeyCode.A)) {
			newDirectionMove += -this.transform.right;
			rotateAngle = 1;
		} else if (Input.GetKey (KeyCode.D)) {
			newDirectionMove += this.transform.right;
			rotateAngle = -1;
		}

		newDirectionMove = newDirectionMove.normalized;

		directionMove = Vector3.Lerp (directionMove, newDirectionMove, Time.deltaTime * accelerationRotation);

		this.transform.LookAt (this.transform.position + directionMove.normalized);

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
	}
	#endregion

	#region EVENTS
	private void HandleonDetectElement (GameObject obj){
		//Vector3 direction = obj.transform.position - weapon.spawnPoint [0].position;
		weapon.SpawnElement (this.transform.forward);
	}
	#endregion
}
