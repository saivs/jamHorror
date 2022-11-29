using UnityEngine;

public static class SoundUtility
{
    public static void PlayAtPoint(this AudioClip clip, Transform transform)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    public static void PlayGlobal(this AudioClip clip)
    {
        SoundPlayer.Instance.PlayGlobal(clip);
    }
}
