using UnityEngine;

public class SlashLine : MonoBehaviour
{

    public GameObject trail;
    GameObject theTrail;
    Vector3 startPos;
    Plane planeObj;
    public Color LineColor;
    public float StrokeWidth;
    

    private void Start()
    {
        planeObj = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began||Input.GetMouseButtonDown(0))
        {
            trail.GetComponent<TrailRenderer>().startColor = LineColor; //set new color
            trail.GetComponent<TrailRenderer>().endColor = LineColor; //set new color
            trail.GetComponent<TrailRenderer>().widthMultiplier = StrokeWidth;

            //set the new start position.
            theTrail = (GameObject)Instantiate(trail,this.transform.position, Quaternion.identity);
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float _dis;
            if(planeObj.Raycast(mouseRay, out _dis))
            {
                startPos = mouseRay.GetPoint(_dis);
            }
        }

        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
        {
            //draw the line.
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float _dis;
            if (planeObj.Raycast(mouseRay, out _dis))
            {
               theTrail.transform.position = mouseRay.GetPoint(_dis);
                
            }
        }

    
    }

    
}
