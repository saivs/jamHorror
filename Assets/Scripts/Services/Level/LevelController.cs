using UnityEngine;

public class LevelController: MonoBehaviour 
{
    public static LevelController Instance => _instance;
    private static LevelController _instance;

    [SerializeField] private Player _player;

    private void Awake()
    {
        _instance = this;
        
        Subscribe();

        MouseLookLock.ResetLock();
    }

    private void Subscribe()
    {
        _player.OnDied += Lose;
    }

    public void Win()
    {
        Debug.Log("Win");
    }

    public void Lose()
    {
        Debug.Log("Lose");
    }
}
