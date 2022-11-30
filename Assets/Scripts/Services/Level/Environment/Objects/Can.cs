using UnityEngine;

public class Can : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (Player.Instance.Item is Brush brush)
        {
            brush.Paint();
            return;
        }
    }
}
