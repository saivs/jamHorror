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
        Debug.Log("Door Open!");
    }

    private void CantOpen()
    {
        Debug.Log("Door Closed!");
    }
}
