using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    private int count=0;
    public 
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (detectWin(SceneManager.GetActiveScene().buildIndex))
        {
            pauseMenu.SetActive(true);
        }
        //hideMenu(pauseMenu);
        //if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        //{
        //    pauseMenu.SetActive(false);
        //}
    }

    public void showMenu()
    {
       pauseMenu.SetActive(true);
    }

    //private void hideMenu(GameObject panel)
    //{
    //    if (Input.GetMouseButton(0) && panel.activeSelf &&
    //        !RectTransformUtility.RectangleContainsScreenPoint(
    //            panel.GetComponent<RectTransform>(),
    //            Input.mousePosition,
    //            Camera.main)
    //          || (Input.touchCount > 0 && panel.activeSelf &&
    //          !RectTransformUtility.RectangleContainsScreenPoint(
    //             panel.GetComponent<RectTransform>(),
    //            Input.GetTouch(0).position,
    //            Camera.main))
    //          )
    //    {
    //        panel.SetActive(false);
    //    }
    //}

    private bool detectWin (int index)
    {
        if (index == 1)
        {
            if (Circle.locked && Rectangle.locked && Star.locked && Triangle.locked) return true;
        }
        else if (index == 2)
        {
            if (Circle_Category.full1 && Circle_Category.full2
                && Oval_Category.full1 && Oval_Category.full2
                && Triangle_Category.full1 && Triangle_Category.full2) return true;
        }
        else if (index == 3)
        {
            if (count >= 10)
            {
                return true;
            }
        }
        return false;
    }

    public void IncreaseCount()
    {
        count++;
    }
}
