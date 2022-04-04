using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Electronics.Devices.Ports
{
    public class Port : MonoBehaviour
    {
        [SerializeField] private PortSO _portSO;
        [SerializeField] private List<Port> _connectedPorts;

        [SerializeField] private SpriteRenderer _portSprite;

        [SerializeField] private PortState _currentPortState;

        public PortSO PortSO { get => _portSO; set => _portSO = value; }
        public List<Port> ConnectedPorts { get => _connectedPorts; set => _connectedPorts = value; }
        public SpriteRenderer PortSprite { get => _portSprite; set => _portSprite = value; }
        public PortState CurrentPortState { get => _currentPortState; set => _currentPortState = value; }

        public void ConnectToThisPort(Port portToConnect, PortSO portSOToConnect)
        {
            switch (CurrentPortState)
            {
                case PortState.IDLE_CONNECTABLE:
                    ConnectPort(portToConnect, portSOToConnect);

                    break;
                case PortState.IDLE_UNCONNECTABLE:
                    break;
                case PortState.CONNECTED:
                    //If disconnectable by connection trial we can handle this code here.
                    break;
            }
        }

        private void ConnectPort(Port portToConnect, PortSO portSOToConnect)
        {
            switch (portSOToConnect.ConnectionRestriction)
            {
                case ConnectionRestrictionType.Port:
                    if (PortSO.ConnectablePorts.Contains(portSOToConnect))
                        ApplyPortConnection(portToConnect);
                    break;
                case ConnectionRestrictionType.Portal:
                    if (PortSO.ConnectablePortals.Contains(portSOToConnect.Portal))
                        ApplyPortConnection(portToConnect);
                    break;
                case ConnectionRestrictionType.Device:
                    if (PortSO.ConnectableDevices.Contains(portSOToConnect.Device))
                        ApplyPortConnection(portToConnect);
                    break;
            }
        }

        private void ApplyPortConnection(Port portToConnect)
        {
            UpdatePortColor(PortState.CONNECTED);
            ConnectedPorts.Add(portToConnect);
            portToConnect.UpdatePortColor(PortState.CONNECTED);
            portToConnect.ConnectedPorts.Add(this);
        }

        public void UpdatePortColor(PortState state)
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
    }
}
