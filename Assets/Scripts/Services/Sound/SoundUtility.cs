using UnityEngine;

public static class SoundUtility
{
    public static void PlayAtPoint(this AudioClip clip, Transform transform)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
