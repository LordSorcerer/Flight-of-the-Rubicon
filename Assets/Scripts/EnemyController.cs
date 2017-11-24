using UnityEngine;
using UnityEngine.Networking;

public class EnemyController : NetworkBehaviour
{
    void Update()
    {      
        transform.Rotate(0, 0, 0);
        transform.Translate(0, 0, 10);
    }
}