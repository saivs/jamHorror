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
    }

    [ContextMenu("Test Pick Brush")]
    public void TestPickBrush()
    {
        var brush = FindObjectOfType<Brush>();
        //_player.EquipItem(brush);
    }

    [ContextMenu("Test Interact With Can")]
    public void TestInteractWithCan()
    {
        var can = FindObjectOfType<Can>();
        _player.InteractWithItem(can);
    }

    [ContextMenu("Test Interact With Button")]
    public void TestInteractWithButton()
    {
        var button = FindObjectOfType<QuestButton>();
        _player.InteractWithItem(button);
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
