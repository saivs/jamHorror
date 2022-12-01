using UnityEngine;

public class DemonSpell : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        UiController.Instance.ShowDialog(DialogMessageConfig.Instance.DemonSpell, OnYes, OnNo);
    }

    private void OnYes()
    {
        SoundConfig.Instance.PlayerDemonSpell.PlayOneShotAtPoint(transform);
        Player.Instance.Kill(DeathMessageConfig.Instance.DemonSpell, 3f);
    }

    private void OnNo()
    {

    }
}
