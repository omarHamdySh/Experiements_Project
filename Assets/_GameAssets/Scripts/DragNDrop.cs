using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    public bool isDraggable;
    public bool isDragging;
    Collider2D objectCollider;
    Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        isDraggable = false;
    }

    // Update is called once per frame
    void Update()
    {
        DragAndDrop();
        if (isDragging)
            FollowMousePosition();
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
        FollowMousePosition();
    }

    void DragAndDrop()
    {
         mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FollowMousePosition()
    {
        this.transform.position = mousePosition;
    }
}