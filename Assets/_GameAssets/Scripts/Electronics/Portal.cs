using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Electronics.Devices.Ports;

namespace Electronics.Devices
{
    public class Portal : MonoBehaviour
    {
        [SerializeField]private List<Port> _ports;
        public List<Port> Ports { get => _ports; set => _ports = value; }

        [ContextMenu("Fetch Ports")]
        public void FetchPorts()
        {
            Ports.Clear();
            foreach (var port in transform.GetComponentsInChildren<Port>())
            {
                Ports.Add(port);
            }
        }

        [ContextMenu("Clear Portal")]
        public void ClearPortal()
        {
            Ports.Clear();
        }
    }
}
