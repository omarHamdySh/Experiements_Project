using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRenderer;

    public LineRenderer LineRenderer { get => _lineRenderer; set => _lineRenderer = value; }
    private Transform[] _points;
    // Start is called before the first frame update
    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetupLine(Transform[] points) {
        LineRenderer.positionCount = points.Length;
        this._points = points;
    }

    void Update()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            LineRenderer.SetPosition(i, _points[i].position);
        }
    }
}
