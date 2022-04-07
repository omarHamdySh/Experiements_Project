using Electronics.Devices.Ports;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorSensor : MonoBehaviour
{
    [SerializeField] ConncetorDrawer drawer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (drawer.PortToConnectFrom)
        {
            if (drawer.PortToConnectFrom.gameObject != collision.gameObject)
            {
                drawer.PortToConnectTo = collision.gameObject.GetComponent<Port>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (drawer.PortToConnectTo)
        {
            if (drawer.PortToConnectTo.gameObject == collision.gameObject)
            {
                drawer.PortToConnectTo = null;
            }

        }
    }

}
