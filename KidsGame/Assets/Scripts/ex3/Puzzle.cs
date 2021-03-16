using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField]
    private Transform objectPlace;
    private Vector2 initialPos;
    private Vector2 mousePos;
    private float deltaX, deltaY;
    public static bool locked = false, moving;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (!locked)
    //    {
    //        if (moving)
    //        {
    //            Vector2 mousePos;
    //            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //            this.gameObject.transform.position = new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);
    //        }
    //    }

    //    //if (Input.touchCount > 0 && !locked)
    //    //{
    //    //    Touch touch = Input.GetTouch(0);
    //    //    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
    //    //    switch (touch.phase)
    //    //    {
    //    //        case TouchPhase.Began:
    //    //            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
    //    //            {
    //    //                deltaX = touchPos.x - transform.position.x;
    //    //                deltaY = touchPos.y - transform.position.y;
    //    //            }
    //    //            break;

    //    //        case TouchPhase.Moved:
    //    //            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
    //    //                transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
    //    //            break;

    //    //        case TouchPhase.Ended:
    //    //            if (Mathf.Abs(transform.position.x - objectPlace.position.x) <= 0.5f &&
    //    //                Mathf.Abs(transform.position.y - objectPlace.position.y) <= 0.5f)
    //    //            {
    //    //                transform.position = new Vector2(objectPlace.position.x, objectPlace.position.y);
    //    //                locked = true;
    //    //            }
    //    //            else
    //    //            {
    //    //                transform.position = new Vector2(initialPos.x, initialPos.y);
    //    //            }
    //    //            break;
    //    //    }
    //    //}
    //}

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Mouse is pressed down");
        if (!locked)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            deltaX = mousePos.x - transform.position.x;
            deltaY = mousePos.y - transform.position.y;
        }
    }

    public void OnMouseDrag()
    {
        if (!locked)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(initialPos.x, initialPos.y);
        }
    }

    public void OnMouseUp()
    {
        moving = false;
        if (Mathf.Abs(transform.position.x - objectPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - objectPlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(objectPlace.position.x, objectPlace.position.y);
            locked = true;
            //GameObject.Find("GameControl").GetComponent<PauseMenuController>().IncreaseCount();
        }
        else
        {
            transform.position = new Vector2(initialPos.x, initialPos.y);
        }
    }
}
