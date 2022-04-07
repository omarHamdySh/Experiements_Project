using Electronics.Devices.Ports;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Electronics.Devices
{
    public class Device : MonoBehaviour
    {
        [SerializeField] private List<Portal> _portals;
        [SerializeField] private DeviceSO _deviceSO;
        [SerializeField] private ConncetorDrawer conncetorDrawer;
        public List<Portal> Portals { get => _portals; set => _portals = value; }
        public DeviceSO DeviceSO { get => _deviceSO; set => _deviceSO = value; }
        public ConncetorDrawer ConncetorDrawer { get => conncetorDrawer; set => conncetorDrawer = value; }

        private void Awake()
        {
            InitializeDevice();
        }

        [ContextMenu("Initialize Device")]
        public void InitializeDevice()
        {
            Portals.Clear();
            foreach (var portal in transform.GetComponentsInChildren<Portal>())
            {
                portal.DeviceGameObject = this;
                Portals.Add(portal);
                portal.FetchPorts();
            }
        }

        [ContextMenu("Clear Device")]
        public void ClearDevice()
        {
            foreach (var portal in transform.GetComponentsInChildren<Portal>())
            {
                portal.ClearPortal();
            }
            Portals.Clear();
        }

        [ContextMenu("Fetch Portals")]
        public void FetchPortals()
        {
            Portals.Clear();
            foreach (var portal in transform.GetComponentsInChildren<Portal>())
            {
                portal.DeviceGameObject = this;
                Portals.Add(portal);
            }
        }

        [ContextMenu("Clear Portals")]
        public void ClearPortals()
        {
            foreach (var portal in transform.GetComponentsInChildren<Portal>())
            {
                portal.ClearPortal();
            }
        }

        public void AttemptToConncet(Port portFrom)
        {
            ConncetorDrawer.PortToConnectFrom = portFrom;
            ConncetorDrawer.showConncetor();
        }


    }
}