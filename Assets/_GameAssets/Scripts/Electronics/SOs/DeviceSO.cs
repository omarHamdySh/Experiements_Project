using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Device", menuName = "Electronics/Device")]
public class DeviceSO : ScriptableObject
{
    [SerializeField] private List<PortalSO> _portals;
    public List<PortalSO> Portals { get => _portals; set => _portals = value; }
}
