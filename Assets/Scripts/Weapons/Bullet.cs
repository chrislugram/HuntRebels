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

	private Rigidbody	bulletRigidbody;
	#endregion
	
	#region METHODS_UNITY
	void Awake(){
		bulletRigidbody = this.GetComponent<Rigidbody> ();
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.layer == AppLayers.LAYER_ENEMY) {
			collision.gameObject.GetComponent<Health>().Damage(damage);
		}

		Desactive ();
	}
	#endregion
	
	#region METHODS_CUSTOM
	public override void Initialized (Spawner spawner){
		base.Initialized (spawner);

		bulletRigidbody.velocity = this.transform.forward * bulletSpeed;
	}
	#endregion

	#region METHODS_EVENT
	#endregion
}
