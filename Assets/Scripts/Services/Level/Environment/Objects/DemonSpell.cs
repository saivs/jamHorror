using UnityEngine;

public class DemonSpell : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Player.Instance.Kill(DeathMessageConfig.Instance.DemonSpell);
    }
}
