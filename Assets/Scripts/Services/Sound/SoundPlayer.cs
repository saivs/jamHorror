using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance => _instance;
    private static SoundPlayer _instance;

    [SerializeField] private AudioSource _source;
    [SerializeField] private SoundConfig _config;

    private void Awake()
    {
        _instance = this;
        _config.Initialize();
    }

    public void PlayGlobal(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }
}
