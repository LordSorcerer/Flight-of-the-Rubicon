using UnityEngine;

public class StalwartStats : MonoBehaviour 
{
    public const int maxHull = 35000;
    public int currentHull = maxHull;

   public void TakeDamage(int amount)
    {
        currentHull -= amount;
        if (currentHull <= 0)
        {
            currentHull = 0;
            Debug.Log("Stalwart Destroyed");
        }
    }
}
