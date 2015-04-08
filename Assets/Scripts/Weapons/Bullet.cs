using UnityEngine;
using System.Collections;

public class Bullet : SpawnElement {
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	#endregion
	
	#region ACCESSORS
	public float		bulletSpeed = 10;
	public int			damage = 1;
	public float		bulletDisabledTime = 5;

	private Rigidbody	bulletRigidbody;
	private float		currentDisabledTime = 0;
	#endregion
	
	#region METHODS_UNITY
	void Awake(){
		bulletRigidbody = this.GetComponent<Rigidbody> ();
	}

	void Update(){
		currentDisabledTime += Time.deltaTime;

		if (currentDisabledTime > bulletDisabledTime) {
			Desactive();
		}
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("Choco con..." + collision.gameObject.name);
		if (collision.gameObject.layer == AppLayers.LAYER_ENEMY || collision.gameObject.layer == AppLayers.LAYER_PC) {
			collision.gameObject.GetComponent<Health>().Damage(damage);
		}

		Desactive ();
	}
	#endregion
	
	#region METHODS_CUSTOM
	public override void Initialized (Spawner spawner){
		base.Initialized (spawner);

		bulletRigidbody.velocity = this.transform.forward * bulletSpeed;
		currentDisabledTime = 0;
	}
	#endregion

	#region METHODS_EVENT
	#endregion
}
