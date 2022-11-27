using System;
using UnityEngine;

public interface IPickable
{
    GameObject gameObject { get; }

    event Action OnPicked;

    void Pick();
}
