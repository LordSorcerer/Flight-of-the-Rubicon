using UnityEngine;

public class DobermanStats : MonoBehaviour 
{
    public const int maxHull = 150;
    public int currentHull = maxHull;

   public void TakeDamage(int amount)
    {
        currentHull -= amount;
        if (currentHull <= 0)
        {
            currentHull = 0;
            Debug.Log("Doberman Destroyed");
        }
    }
}
