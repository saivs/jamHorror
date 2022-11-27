using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (Player.Instance.Item is Key key)
        {
            Open();
            Destroy(key.gameObject);
            return;
        }

        CantOpen();
    }

    private void Open()
    {
        SoundConfig.Instance.DoorOpen.PlayAtPoint(transform);
        Debug.Log("Door Open!");
    }

    private void CantOpen()
    {
        SoundConfig.Instance.DoorCantOpen.PlayAtPoint(transform);
        Debug.Log("Door Closed!");
    }
}
