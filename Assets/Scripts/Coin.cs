using UnityEngine;

public class Coin : MonoBehaviour, IPicakble
{
    public void PickUp()
    {
        gameObject.SetActive(false);
    }
}
