using System.Collections.Generic;
using UnityEngine;

public class LevelController: MonoBehaviour 
{
    public static LevelController Instance => _instance;
    private static LevelController _instance;

    [SerializeField] private Player _player;
    [SerializeField] private List<SingletonConfig> _configs;

    private void Awake()
    {
        _instance = this;
        
        Subscribe();
        InitializeConfigs();

        MouseLookLock.ResetLock();
    }

    private void Subscribe()
    {
        _player.OnDied += Lose;
    }

    private void InitializeConfigs()
    {
        foreach (var config in _configs)
        {
            config.Initialize();
        }
    }

    public void Win()
    {
        UiController.Instance.ShowWin();
    }

    public void Lose(string message)
    {
        UiController.Instance.ShowLose(message);
    }
}
