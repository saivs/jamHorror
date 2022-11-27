using System;
using UnityEngine;

public class Item : MonoBehaviour, IPickable
{
    public event Action OnPicked;

    public void Pick()
    {
        OnPicked?.Invoke();
    }
}
