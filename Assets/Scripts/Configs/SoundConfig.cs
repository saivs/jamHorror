using UnityEngine;

[CreateAssetMenu(menuName = "Configs/" + nameof(SoundConfig))]
public class SoundConfig : SingletonConfig
{
    public static SoundConfig Instance => _instance;
    private static SoundConfig _instance;

    public int WalkSoundInterval;

    [Header("Music")]
    public AudioClip MusicLevel;
    public AudioClip MusicBasement;
    public AudioClip MusicEbakaStanding;
    public AudioClip MusicEbakaDancing;

    [Header("Player")]
    public AudioClip PlayerWalk;
    public AudioClip PlayerDemonSpell;
    public AudioClip PlayerDeath;
    public AudioClip PlayerWin;

    [Header("Item")]
    public AudioClip ItemPick;
    public AudioClip ItemDrop;

    [Header("Electric Panel")]
    public AudioClip ElectricPanelPressButton;
    public AudioClip ElectricPanelFix;
    public AudioClip ElectricPanelBreak;

    [Header("Brush")]
    public AudioClip BrushPaint;
    public AudioClip BrushClear;

    [Header("Ebaka in room")]
    public AudioClip EbakaHit;

    [Header("Button")]
    public AudioClip ButtonPressGood;
    public AudioClip ButtonPressBad;

    [Header("Beer")]
    public AudioClip BeerDrink;

    [Header("Door")]
    public AudioClip DoorOpen;
    public AudioClip DoorCantOpen;

    [Header("Screamer")]
    public AudioClip Screamer;

    public override void Initialize()
    {
        _instance = this;
    }
}