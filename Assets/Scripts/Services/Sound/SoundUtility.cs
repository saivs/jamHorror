using UnityEngine;

public static class SoundUtility
{
    public static void PlayOneShotAtPoint(this AudioClip clip, Transform transform, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }

    public static void PlayOneShot(this AudioClip clip, float volume = 1f)
    {
        SoundPlayer.Instance.PlayOneShotGlobal(clip, volume);
    }
}
