using UnityEngine;

public class Hall: MonoBehaviour
{
    private bool _wasActivated;

    private void OnTriggerEnter(Collider other)
    {
        if (_wasActivated)
        {
            return;
        }

        if (other.GetComponent<Player>())
        {
            Scream();
        }
    }

    private void Scream()
    {
        _wasActivated = true;

        SoundConfig.Instance.Screamer.PlayOneShot(2f);
        UiController.Instance.ShowScreamer(ScreamerConfig.Instance.Hall, 2f);
    }
}
