using UnityEngine;

namespace Assets.Scripts.Services.Level.Sounds
{
    public class WinAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private void Start()
        {
            _audioSource.clip = SoundConfig.Instance.MusicEbakaDancing;
            _audioSource.Play();
        }
    }
}