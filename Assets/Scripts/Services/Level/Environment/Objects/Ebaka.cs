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

    public void Interact()
    {
        if (Player.Instance.Item is Bucket bucket)
        {
            PutOnBucket(bucket);
            Destroy(bucket.gameObject);
            return;
        }

        KillPlayer();
    }

    private void PutOnBucket(Bucket bucket)
    {
        _blind = true;
        var instancedBucket = Instantiate(bucket, _bucketPivot);
        instancedBucket.transform.localPosition = Vector3.zero;
    }

    private void KillPlayer()
    {
        SoundConfig.Instance.EbakaHit.PlayAtPoint(transform);
        Player.Instance.Kill();
    }

    private void OnItemPickedUp()
    {
        if (!_blind)
        {
            KillPlayer();
        }
    }
}
