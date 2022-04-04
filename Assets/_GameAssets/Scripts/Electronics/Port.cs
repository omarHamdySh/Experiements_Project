using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Electronics.Devices.Ports
{
    [CreateAssetMenu(fileName = "Electronics", menuName = "Port")]
    public class Port : ScriptableObject
    {
        public string portName;
        public List<Port> connectablePortsTo;
        public List<Port> connectablePortsFrom; //Not sure if the "connectablePortsFrom" connectors will be listed in each port.

        public List<Port> connectedPorts;
        
        public SpriteRenderer portSprite;

        public PortState currentPortState;
        public void ConnectToThisPort(Port portToConnect)
        {
            switch (currentPortState)
            {
                case PortState.IDLE_CONNECTABLE:
                    if (connectablePortsTo.Contains(portToConnect))
                    {
                        UpdatePortColor(PortState.CONNECTED);
                        connectedPorts.Add(portToConnect);
                        portToConnect.UpdatePortColor(PortState.CONNECTED);
                        portToConnect.connectedPorts.Add(this);
                    }
                    break;
            }
        }

        public void UpdatePortColor(PortState state)
        {
            currentPortState = state;
            switch (currentPortState)
            {
                case PortState.IDLE_CONNECTABLE:
                    portSprite.color = Color.yellow;
                    break;
                case PortState.IDLE_UNCONNECTABLE:
                    portSprite.color = Color.red;
                    break;
                case PortState.CONNECTED:
                    portSprite.color = Color.green;
                    break;
            }
        }
    }
}
