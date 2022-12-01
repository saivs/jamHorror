using UnityEngine;

public class Ebaka : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _bucketPivot;
    [SerializeField] private Item _pickableItem;

    private bool _blind;

    private void Awake()
    {
        _pickableItem.OnPickedUp += OnItemPickedUp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            KillFromHit();
        }
    }

    public void Interact()
    {
        if (Player.Instance.Item is Bucket bucket)
        {
            PutOnBucket(bucket);
            Destroy(bucket.gameObject);
            return;
        }

        KillFromHit();
    }

    private void PutOnBucket(Bucket bucket)
    {
        _blind = true;
        var instancedBucket = Instantiate(bucket, _bucketPivot);
        instancedBucket.transform.localPosition = Vector3.zero;
        instancedBucket.transform.localScale = Vector3.one;
    }

    private void KillFromHit()
    {
        if (_blind)
        {
            return;
        }
        KillPlayer(DeathMessageConfig.Instance.EbakaHit);
    }

    private void KillFromBrush()
    {
        if (_blind)
        {
            return;
        }
        KillPlayer(DeathMessageConfig.Instance.EbakaBrush);
    }

    private void KillPlayer(string message)
    {
        SoundConfig.Instance.EbakaHit.PlayOneShotAtPoint(transform, 2f);
        UiController.Instance.ShowScreamer(ScreamerConfig.Instance.Ebaka, 2f);
        Player.Instance.Kill(message, 1.7f);
    }

    private void OnItemPickedUp()
    {
        KillFromBrush();
    }
}
