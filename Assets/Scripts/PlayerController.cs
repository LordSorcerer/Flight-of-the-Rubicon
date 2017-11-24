using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{
	public GameObject sliderThrust;
	public GameObject bulletPrefab1, beamPrefab1;
	public Transform bulletSpawn1, bulletSpawn2, beamSpawn1;
	public Slider thrustTracker;

	int minThrustSpeed = -25, maxThrustSpeed = 100, thrustSpeed = 0;
	float turnSpeed = 50.0f, rollSpeed = 35.0f;

	void Update()
	{
		if (!isLocalPlayer) {
			return;
		}

		//Turning control

		var x = Input.GetAxis("Vertical") * Time.deltaTime * turnSpeed;
		var y = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
		var z = 0f;

		if (Input.GetKey (KeyCode.Q)) {
			z = Time.deltaTime * rollSpeed;
		} else if (Input.GetKey (KeyCode.E)) {
			z = Time.deltaTime * rollSpeed * -1;
		}
		transform.Rotate(x, y, z);

		//Thrust control
		if (Input.GetKeyDown(KeyCode.RightBracket) && thrustSpeed < maxThrustSpeed){
			thrustSpeed += 5;
		} else if (Input.GetKeyDown(KeyCode.LeftBracket) && thrustSpeed > minThrustSpeed){
			thrustSpeed -= 5;
		}
		transform.Translate (0, 0, thrustSpeed);
		thrustTracker.value = thrustSpeed;

		//Weapon control
		if (Input.GetKeyDown(KeyCode.Space)){
			CmdFireProton();
		} else if (Input.GetKeyDown(KeyCode.LeftControl)){
			//CmdFireFlux();
		}
			
	}

	[Command]
	void CmdFireProton()
	{
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
		bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * 10000;
		bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * 10000;

		NetworkServer.Spawn(bullet1);
		NetworkServer.Spawn(bullet2);
		// Destroy the bullet
		Destroy(bullet1, 5.0f);
		Destroy(bullet2, 5.0f);
	}

	void CmdFireFlux2()
	{
		// Create the beam from the beam Prefab
		var beam1 = (GameObject)Instantiate (
			beamPrefab1,
			beamSpawn1.position,
			beamSpawn1.rotation);
		// Add velocity to the beam
		beam1.GetComponent<Rigidbody>().velocity = beam1.transform.forward * 1000;

		NetworkServer.Spawn(beam1);
		// Destroy the beam
		Destroy(beam1, 1.0f);
	}

}