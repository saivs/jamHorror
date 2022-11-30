using UnityEngine;

public static class SoundUtility
{
    public static void PlayOneShotAtPoint(this AudioClip clip, Transform transform)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    public static void PlayOneShot(this AudioClip clip)
    {
        SoundPlayer.Instance.PlayOneShotGlobal(clip);
    }
}
