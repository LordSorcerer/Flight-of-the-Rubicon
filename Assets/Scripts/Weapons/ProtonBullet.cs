using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtonBullet : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var hull = hit.GetComponent<Hull>();
        if (hull  != null)
        {
            hull.TakeDamage(50);
        }
        Destroy(gameObject);
    }
}

