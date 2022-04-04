using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    bool isDraggable;
    bool isDragging;
    Collider2D objectCollider;
    Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        isDraggable = false;
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        DragAndDrop();
    }
    private void OnMouseDown()
    {
        isDraggable = true;
    }

    private void OnMouseExit()
    {
        isDraggable = false;
    }

    private void OnMouseDrag()
    {
        this.transform.position = mousePosition;
    }
    void DragAndDrop()
    {
         mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}