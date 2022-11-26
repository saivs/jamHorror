using System;

public interface IPlayer
{
    Item Item { get; }

    event Action OnDied;

    void Kill();
}