using UnityEngine;

public class SelfDisable : MonoBehaviour
{
   public void TurnMeOff()
    {
        gameObject.SetActive(false);
    }
}
