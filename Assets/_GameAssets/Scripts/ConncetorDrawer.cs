using Electronics.Devices.Ports;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConncetorDrawer : MonoBehaviour
{
    [SerializeField] LineController _connectorLine;
    [SerializeField] DragNDrop _dragNDropEndNode;
    [SerializeField] Transform[] _points;
    [SerializeField] Port _portToConnectFrom;
    [SerializeField] Port _portToConnectTo;

    [SerializeField] bool _isConnecting;

    [SerializeField] GameObject ConnectionPrefab;
    //[SerializeField] List<LineController> connections; //Next we need to have a logical class for the connection that contains connected ports and can be used to disconnect the ports.

    public Port PortToConnectFrom { get => _portToConnectFrom; set => _portToConnectFrom = value; }
    public Port PortToConnectTo { get => _portToConnectTo; set => _portToConnectTo = value; }
    public bool IsConnecting { get => _isConnecting; set => _isConnecting = value; }

    /// <summary>
    /// After each connection attempt we need to clear up the component before we proceed with another connection attempt.
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        _connectorLine.SetupLine(_points);
    }

    private void Update()
    {
        if (IsConnecting)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _points[1].transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (PortToConnectTo)
            {
                Debug.Log(PortToConnectTo.IsConnectionAttemptValiid(PortToConnectFrom) + " validation result.");
                applyPortsConncetion();
            }

            hideConncetor();
            IsConnecting = false;
        }
    }

    public void hideConncetor()
    {
        _isConnecting = false;
        _dragNDropEndNode.isDragging = false;
        foreach (var point in _points)
        {
            point.gameObject.SetActive(false);
        }
        _connectorLine.gameObject.SetActive(false);
        _portToConnectFrom = null;
        _portToConnectTo = null;
    }

    public void showConncetor()
    {
        _dragNDropEndNode.isDragging = true;
        _isConnecting = true;
        foreach (var point in _points)
        {
            point.gameObject.SetActive(true);
        }
        _connectorLine.gameObject.SetActive(true);
        _points[0].transform.position = _portToConnectFrom.transform.position;
    }

    public void applyPortsConncetion()
    {
        PortToConnectTo.ConnectToThisPort(PortToConnectFrom);
    }

    public void InstantiateConnector()
    {
        var connectionLine = Instantiate(ConnectionPrefab);
        LineController lineController = connectionLine.GetComponent<LineController>();
        Transform[] trans = new Transform[] { PortToConnectFrom.transform, PortToConnectTo.transform };
        lineController.SetupLine(trans);
        //connections.Add(lineController); //Add the connection logical class instance to centralized position.
        PortToConnectFrom.ConnectionsLines.Add(lineController);
        PortToConnectTo.ConnectionsLines.Add(lineController);
    }
}
