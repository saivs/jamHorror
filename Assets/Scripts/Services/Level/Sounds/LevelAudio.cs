using UnityEngine;

namespace Assets.Scripts.Services.Level.Sounds
{
    public class LevelAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private void Start()
        {
            _audioSource.clip = SoundConfig.Instance.MusicLevel;
            _audioSource.Play();
        }
    }
}