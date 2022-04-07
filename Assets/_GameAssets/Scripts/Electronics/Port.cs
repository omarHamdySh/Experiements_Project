using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Electronics.Devices.Ports
{
    public class Port : MonoBehaviour
    {
        [SerializeField] private Device _deviceGameObject;
        [SerializeField] private Portal _portalGameObject;
        [SerializeField] private PortSO _portSO;
        [SerializeField] private List<Port> _connectedPortsGameObjects;
        [SerializeField] private SpriteRenderer _portSprite;
        [SerializeField] private PortState _currentPortState;

        [SerializeField] private List<LineController> _connectionLines;


        public PortSO PortSO { get => _portSO; set => _portSO = value; }
        public List<Port> ConnectedPortsGameObjects { get => _connectedPortsGameObjects; set => _connectedPortsGameObjects = value; }
        public SpriteRenderer PortSprite { get => _portSprite; set => _portSprite = value; }
        public PortState CurrentPortState { get => _currentPortState; set => _currentPortState = value; }
        public Device DeviceGameObject { get => _deviceGameObject; set => _deviceGameObject = value; }
        public Portal PortalGameObject { get => _portalGameObject; set => _portalGameObject = value; }
        public List<LineController> ConnectionsLines { get => _connectionLines; set => _connectionLines = value; }

        public void ConnectToThisPort(Port portToConnect)
        {
            switch (CurrentPortState)
            {
                case PortState.IDLE_CONNECTABLE:
                    ConnectPort(portToConnect);
                    break;
                case PortState.IDLE_UNCONNECTABLE:
                    break;
                case PortState.CONNECTED:
                    //If disconnectable by connection trial we can handle this code here.
                    break;
            }
        }

        private void ConnectPort(Port portToConnect)
        {
            switch (this.PortSO.ConnectionRestriction)
            {
                case ConnectionRestrictionType.Port:
                    if (PortSO.ConnectablePorts.Contains(portToConnect.PortSO))
                        ApplyPortConnection(portToConnect);
                    break;
                case ConnectionRestrictionType.Portal:
                    if (PortSO.ConnectablePortals.Contains(portToConnect.PortalGameObject.PortalSO))
                        ApplyPortConnection(portToConnect);
                    break;
                case ConnectionRestrictionType.Device:
                    if (PortSO.ConnectableDevices.Contains(portToConnect.DeviceGameObject.DeviceSO))
                        ApplyPortConnection(portToConnect);
                    break;
                case ConnectionRestrictionType.Port_And_Portal:
                    break;
                case ConnectionRestrictionType.Port_And_Device:
                    if (PortSO.ConnectablePorts.Contains(portToConnect.PortSO) || PortSO.ConnectableDevices.Contains(portToConnect.DeviceGameObject.DeviceSO))
                        ApplyPortConnection(portToConnect);
                    break;
                case ConnectionRestrictionType.Portal_And_Device:
                    break;
                case ConnectionRestrictionType.Port_And_Portal_And_Device:
                    break;
            }
        }


        public bool IsConnectionAttemptValiid(Port portToConnect)
        {
            switch (this.PortSO.ConnectionRestriction)
            {
                case ConnectionRestrictionType.Port:
                    if (PortSO.ConnectablePorts.Contains(portToConnect.PortSO))
                        return true;
                    break;
                case ConnectionRestrictionType.Portal:
                    if (PortSO.ConnectablePortals.Contains(portToConnect.PortalGameObject.PortalSO))
                        return true;
                    break;
                case ConnectionRestrictionType.Device:
                    if (PortSO.ConnectableDevices.Contains(portToConnect.DeviceGameObject.DeviceSO))
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }

        private void ApplyPortConnection(Port portToConnect)
        {
            UpdatePortState(PortState.CONNECTED);
            ConnectedPortsGameObjects.Add(portToConnect);
            portToConnect.UpdatePortState(PortState.CONNECTED);
            portToConnect.ConnectedPortsGameObjects.Add(this);
            DeviceGameObject.ConncetorDrawer.InstantiateConnector();
        }

        public void UpdatePortState(PortState state)
        {
            CurrentPortState = state;
            switch (CurrentPortState)
            {
                case PortState.IDLE_CONNECTABLE:
                    PortSprite.color = Color.yellow;
                    break;
                case PortState.IDLE_UNCONNECTABLE:
                    PortSprite.color = Color.red;
                    break;
                case PortState.CONNECTED:
                    PortSprite.color = Color.green;
                    break;
            }
        }

        public void ClearPort()
        {
            ConnectedPortsGameObjects.Clear();
            UpdatePortState(PortState.IDLE_CONNECTABLE);
            DeviceGameObject = null;
            PortalGameObject = null;
        }

        private void OnMouseDown()
        {
            switch (CurrentPortState)
            {
                case PortState.IDLE_CONNECTABLE:
                    _deviceGameObject.AttemptToConncet(this);
                    break;
                case PortState.IDLE_UNCONNECTABLE:
                    break;
                case PortState.CONNECTED:
                    break;
            }
        }

    }
}
