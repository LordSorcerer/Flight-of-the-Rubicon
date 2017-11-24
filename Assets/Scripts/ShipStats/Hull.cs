using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Hull : MonoBehaviour 
{
    public const int maxHull = 2500;
    public int currentHull = maxHull;
    public RectTransform hullTracker;

   public void TakeDamage(int amount)
    {
        currentHull -= amount;
        if (currentHull <= 0)
        {
            currentHull = 0;
            Destroy(gameObject);
        }
		//hullTracker.sizeDelta = new Vector2(currentHull, hullTracker.sizeDelta.y);
    }


}
