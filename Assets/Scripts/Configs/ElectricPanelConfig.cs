using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/" + nameof(ElectricPanelConfig))]
public class ElectricPanelConfig : ScriptableObject
{
    [Header("Switcher indexes start from 0 !!!")]
    public List<int> SwitcherIndexesToPress;
}
