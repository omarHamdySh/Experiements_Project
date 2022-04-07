using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Electronics.Devices.Ports;

namespace Electronics.Devices
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Device _deviceGameObject;
        [SerializeField] private List<Port> _portsGameObjects;
        [SerializeField] private PortalSO _portalSO;
        public List<Port> PortsGameObjects { get => _portsGameObjects; set => _portsGameObjects = value; }
        public Device DeviceGameObject { get => _deviceGameObject; set => _deviceGameObject = value; }
        public PortalSO PortalSO { get => _portalSO; set => _portalSO = value; }


        [ContextMenu("Fetch Ports")]
        public void FetchPorts()
        {
            PortsGameObjects.Clear();
            foreach (var port in transform.GetComponentsInChildren<Port>())
            {
                PortsGameObjects.Add(port);
                port.PortalGameObject = this;

                if (DeviceGameObject)
                    port.DeviceGameObject = this.DeviceGameObject;
            }
        }

        [ContextMenu("Clear Portal")]
        public void ClearPortal()
        {
            PortsGameObjects.Clear();
            DeviceGameObject = null;
        }
    }
}
