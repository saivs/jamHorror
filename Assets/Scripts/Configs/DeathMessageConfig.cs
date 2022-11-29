using UnityEngine;

[CreateAssetMenu(menuName = "Configs/" + nameof(DeathMessageConfig))]
public class DeathMessageConfig : SingletonConfig
{
    public static DeathMessageConfig Instance => _instance;
    private static DeathMessageConfig _instance;

    public string TouchRedButton;
    public string EbakaHit;
    public string EbakaBrush;
    public string DarkBasement;
    public string ElectricPanel;
    public string DemonSpell;
    public string Beer;

    public override void Initialize()
    {
        _instance = this;
    }
}
