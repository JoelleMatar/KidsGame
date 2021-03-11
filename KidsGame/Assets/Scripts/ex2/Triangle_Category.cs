using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle_Category : MonoBehaviour
{
    [SerializeField]
    private Transform objectPlace1, objectPlace2;
    private Vector2 initialPos;
    private float deltaX, deltaY;
    public static bool full1 = false, full2 = false;

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
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    if (!full1 || !full2)
                    {
                        if (!full1 && Mathf.Abs(transform.position.x - objectPlace1.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - objectPlace1.position.y) <= 0.5f)
                        {
                            transform.position = new Vector2(objectPlace1.position.x, objectPlace1.position.y);
                            full1 = true;
                        }
                        else if (!full2 && Mathf.Abs(transform.position.x - objectPlace2.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - objectPlace2.position.y) <= 0.5f)
                        {
                            transform.position = new Vector2(objectPlace2.position.x, objectPlace2.position.y);
                            full2 = true;
                        }
                        else
                        {
                            transform.position = new Vector2(initialPos.x, initialPos.y);
                        }
                    }
                    else
                    {
                        transform.position = new Vector2(initialPos.x, initialPos.y);
                    }
                    break;
            }
        }
    }
}
