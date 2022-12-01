using UnityEngine;

namespace Assets.Scripts.Services.Level.Sounds
{
    public class EbakaAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private void Start()
        {
            _audioSource.clip = SoundConfig.Instance.MusicEbakaStanding;
            _audioSource.Play();
        }
    }
}