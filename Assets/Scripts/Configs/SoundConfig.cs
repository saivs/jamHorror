using UnityEngine;

[CreateAssetMenu(menuName = "Configs/" + nameof(SoundConfig))]
public class SoundConfig : ScriptableObject
{
    public static SoundConfig Instance => _instance;
    private static SoundConfig _instance;

    public AudioClip ItemPick;
    public AudioClip ItemDrop;

    public AudioClip ElectricPanelPressButton;
    public AudioClip ElectricPanelFix;
    public AudioClip ElectricPanelBreak;
    
    public AudioClip BrushPaint;
    public AudioClip BrushClear;

    public AudioClip EbakaHit;

    public AudioClip ButtonPressGood;
    public AudioClip ButtonPressBad;

    public AudioClip BeerDrink;
    public AudioClip BeerDrinkLast;

    public AudioClip DoorOpen;
    public AudioClip DoorCantOpen;

    public AudioClip Screamer;

    private void OnEnable()
    {
        _instance = this;
    }
}