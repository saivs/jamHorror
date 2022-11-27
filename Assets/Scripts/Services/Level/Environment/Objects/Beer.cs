using UnityEngine;

public class Beer : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.Instance.DrinkBeer();
        Destroy(gameObject);
    }
}
