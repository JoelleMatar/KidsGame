using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oval_Category : MonoBehaviour
{
    [SerializeField]
    private Transform objectPlace1, objectPlace2;
    private Vector2 initialPos;
    private float deltaX1, deltaY1, deltaX2, deltaY2;
    public static bool full1, full2;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX1 = touchPos.x - transform.position.x;
                        deltaY1 = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX1, touchPos.y - deltaY1);
                    break;

                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - objectPlace1.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - objectPlace1.position.y) <= 0.5f &&
                        !full1)
                    {
                        transform.position = new Vector2(objectPlace1.position.x, objectPlace1.position.y);
                        full1 = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPos.x, initialPos.y);
                        full1 = false;
                    }
                    break;
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX2 = touchPos.x - transform.position.x;
                        deltaY2 = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX2, touchPos.y - deltaY2);
                    break;

                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - objectPlace2.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - objectPlace2.position.y) <= 0.5f &&
                        !full2)
                    {
                        transform.position = new Vector2(objectPlace2.position.x, objectPlace2.position.y);
                        full2 = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPos.x, initialPos.y);
                        full2 = false;
                    }
                    break;
            }
        }
    }
}
