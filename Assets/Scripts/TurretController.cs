using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TurretController : NetworkBehaviour{
	public GameObject bulletPrefab1;
	public Transform bulletSpawn1, bulletSpawn2;
	GameObject target;
	float turnSpeed = 10.0f;
	float angleToTarget;
	Vector3 rotateToTarget;
	bool trackingTarget = false;
	bool firingOnTarget = false;
	void Start () {
		//InvokeRepeating ("CmdFireProton", 2.0f, 1.0f);
	}
	void Update(){
		
	}

	[Command]
	void CmdFireProton() {
			// Create the Bullet from the Bullet Prefab
			var bullet1 = (GameObject)Instantiate (
				             bulletPrefab1,
				             bulletSpawn1.position,
				             bulletSpawn1.rotation);
			var bullet2 = (GameObject)Instantiate (
				             bulletPrefab1,
				             bulletSpawn2.position,
				             bulletSpawn2.rotation);
			// Add velocity to the bullet
			bullet1.GetComponent<Rigidbody> ().velocity = bullet1.transform.forward * 10000;
			bullet2.GetComponent<Rigidbody> ().velocity = bullet2.transform.forward * 10000;

			NetworkServer.Spawn (bullet1);
			NetworkServer.Spawn (bullet2);
			// Destroy the bullet
			Destroy (bullet1, 5.0f);
			Destroy (bullet2, 5.0f);
	}
		
	void OnTriggerEnter(Collider other) {
		Debug.Log(other.gameObject + " has entered range.");
	}

	void OnTriggerStay(Collider other) {
		RotateToTarget (other);
	}

	void OnTriggerExit(Collider other) {
		Debug.Log(other.gameObject + " is no longer in range or was destroyed.");
	}

	float CalcDistanceToTarget (Collider other) {
		float distance = Vector3.Distance (other.gameObject.transform.position, gameObject.transform.position);
		return distance;
	}
	void RotateToTarget(Collider other){
    	Vector3 targetDir = other.gameObject.transform.position - transform.position;
        float step = 0.1f * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
		
	}
}