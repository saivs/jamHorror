using UnityEngine;

public class Ebaka : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _bucketPivot;
    [SerializeField] private Item _pickableItem;

    private bool _blind;

    private void Awake()
    {
        _pickableItem.OnPicked += OnItemPicked;
    }

    public void Interact(IPlayer player)
    {
        if (player.Item is Bucket bucket)
        {
            PutOnBucket(bucket);
            player.ConsumeItem();
            return;
        }

        KillPlayer();
    }

    private void PutOnBucket(Bucket bucket)
    {
        _blind = true;
        Instantiate(bucket, _bucketPivot);
    }

    private void KillPlayer()
    {
        Player.Instance.Kill();
    }

    private void OnItemPicked()
    {
        if (!_blind)
        {
            KillPlayer();
        }
    }
}
