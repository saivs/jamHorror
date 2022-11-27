using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance => _instance;
    private static SoundPlayer _instance;

    [SerializeField] private AudioSource _source;

    private void Awake()
    {
        _instance = this;

    }
}
