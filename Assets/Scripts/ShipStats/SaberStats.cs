using UnityEngine;

public class SaberStats : MonoBehaviour 
{
    public const int maxHull = 2500;
    public int currentHull = maxHull;

   public void TakeDamage(int amount)
    {
        currentHull -= amount;
        if (currentHull <= 0)
        {
            currentHull = 0;
            Debug.Log("Saber Destroyed");
        }
    }
}
