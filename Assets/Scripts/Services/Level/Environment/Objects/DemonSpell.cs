using UnityEngine;

public class DemonSpell : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SoundConfig.Instance.PlayerDemonSpell.PlayOneShotAtPoint(transform);
        Player.Instance.Kill(DeathMessageConfig.Instance.DemonSpell);
    }
}
