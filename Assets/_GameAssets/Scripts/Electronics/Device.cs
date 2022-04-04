using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Electronics.Devices
{
    public class Device : MonoBehaviour
    {
        [SerializeField] private List<Portal> _portals;
        public List<Portal> Portals { get => _portals; set => _portals = value; }

        [ContextMenu("Initialize Device")]
        public void InitializeDevice()
        {
            Portals.Clear();
            foreach (var portal in transform.GetComponentsInChildren<Portal>())
            {
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

    }
}