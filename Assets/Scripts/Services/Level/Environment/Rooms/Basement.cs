using UnityEngine;

public class Basement: MonoBehaviour
{
    [SerializeField] private GameObject _light;
    
    private bool _lightIsOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            OnPlayerEntered();
        }
    }

    private void OnPlayerEntered()
    {
        if (!_lightIsOn)
        {
            Player.Instance.Kill(DeathMessageConfig.Instance.DarkBasement);
        }
    }

    public void TurnOnLight()
    {
        _lightIsOn = true;
        _light.SetActive(true);
    }
}
