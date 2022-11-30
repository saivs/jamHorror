﻿using UnityEngine;

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

        KillPlayer(DeathMessageConfig.Instance.EbakaHit);
    }

    private void PutOnBucket(Bucket bucket)
    {
        _blind = true;
        var instancedBucket = Instantiate(bucket, _bucketPivot);
        instancedBucket.transform.localPosition = Vector3.zero;
    }

    private void KillPlayer(string message)
    {
        SoundConfig.Instance.EbakaHit.PlayOneShotAtPoint(transform);
        Player.Instance.Kill(message);
    }

    private void OnItemPickedUp()
    {
        if (!_blind)
        {
            KillPlayer(DeathMessageConfig.Instance.EbakaBrush);
        }
    }
}
