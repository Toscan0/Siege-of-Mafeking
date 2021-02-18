using UnityEngine;

public class SelfDisable : MonoBehaviour
{
   public void TurnMeOff()
   {
        gameObject.SetActive(false);
   }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
