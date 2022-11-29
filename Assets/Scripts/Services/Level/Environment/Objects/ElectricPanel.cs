using System.Collections.Generic;
using UnityEngine;

public class ElectricPanel: MonoBehaviour
{
    [SerializeField] private Basement _basement;
    [SerializeField] private ElectricPanelConfig _config;
    [SerializeField] private List<ElectricPanelSwitcher> _switchers;

    private int _pressedSwitchersCount;

    private void Awake()
    {
        _pressedSwitchersCount = 0;

        for (int i = 0; i < _switchers.Count; i++)
        {
            int index = i;
            _switchers[i].OnPressed += () => OnSwitcherPressed(index);
        }
    }

    private void OnSwitcherPressed(int index)
    {
        if (_config.SwitcherIndexesToPress[_pressedSwitchersCount] == index)
        {
            _pressedSwitchersCount++;

            if (_pressedSwitchersCount == _switchers.Count)
            {
                Fix();
            }

            return;
        }

        Break();
    }

    private void Fix()
    {
        SoundConfig.Instance.ElectricPanelFix.PlayAtPoint(transform);

        _basement.TurnOnLight();
    }

    private void Break()
    {
        SoundConfig.Instance.ElectricPanelBreak.PlayAtPoint(transform);

        Player.Instance.Kill(DeathMessageConfig.Instance.ElectricPanel);
    }
}
