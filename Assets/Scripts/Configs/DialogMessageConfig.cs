using UnityEngine;

[CreateAssetMenu(menuName = "Configs/" + nameof(DialogMessageConfig))]
public class DialogMessageConfig : SingletonConfig
{
    public static DialogMessageConfig Instance => _instance;
    private static DialogMessageConfig _instance;

    public string DemonSpell;

    public override void Initialize()
    {
        _instance = this;
    }
}