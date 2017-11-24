using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxBeam : MonoBehaviour {

	LineRenderer line;
	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer>();
		line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftControl)) {
			StopCoroutine("FireFluxBeam");
			StartCoroutine("FireFluxBeam");
		}
	}
	
	IEnumerator FireFluxBeam (){
		while (Input.GetKey (KeyCode.LeftControl)) {
			line.enabled = true;
			yield return null;
		}
			line.enabled = false;
	}

	void OnCollisionEnter(Collision collision)
	{
		var hit = collision.gameObject;
		Debug.Log ("Collision detected");
		var hull = hit.GetComponent<Hull>();
		if (hull  != null)
		{
			hull.TakeDamage(50);
		}
	}
}
