using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Port", menuName = "Electronics/Port")]
public class PortSO : ScriptableObject
{
    [SerializeField] private string _portName;

    [SerializeField] private ConnectionRestrictionType _connectionRestriction;

    [SerializeField] private List<DeviceSO> _connectableDevices;
    [SerializeField] private List<PortalSO> _connectablePortals;
    [SerializeField] private List<PortSO> _connectablePorts;

    [SerializeField] private PortalSO _portal;
    [SerializeField] private DeviceSO _device;

    public string PortName { get => _portName; set => _portName = value; }
    public ConnectionRestrictionType ConnectionRestriction { get => _connectionRestriction; set => _connectionRestriction = value; }
    public List<DeviceSO> ConnectableDevices { get => _connectableDevices; set => _connectableDevices = value; }
    public List<PortalSO> ConnectablePortals { get => _connectablePortals; set => _connectablePortals = value; }
    public List<PortSO> ConnectablePorts { get => _connectablePorts; set => _connectablePorts = value; }
    public PortalSO Portal { get => _portal; set => _portal = value; }
    public DeviceSO Device { get => _device; set => _device = value; }
}
