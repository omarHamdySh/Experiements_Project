using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Portal", menuName = "Electronics/Portal")]

public class PortalSO : ScriptableObject
{
    [SerializeField] private List<PortSO> _ports;
    public List<PortSO> Ports { get => _ports; set => _ports = value; }
}
