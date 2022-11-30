using UnityEngine;

[CreateAssetMenu(menuName = "Configs/" + nameof(ScreamerConfig))]
public class ScreamerConfig : SingletonConfig
{
    public static ScreamerConfig Instance => _instance;
    private static ScreamerConfig _instance;

    public Sprite Ebaka;
    public Sprite Hall;

    public override void Initialize()
    {
        _instance = this;
    }
}