using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicsSwiping : MonoBehaviour
{
    public Image ComicsPage;
    public List<Sprite> Pages;
    public int PageNum;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;

            if (endTouchPos.x < startTouchPos.x) 
            {
                NextPage();
            }
            if (endTouchPos.x > startTouchPos.x) 
            {
                PreviousPage();
            }
        }
    }

    private void NextPage()
    {
        if (PageNum + 1 < Pages.Count) 
        {
            PageNum++;
        }
        ComicsPage.sprite = Pages[PageNum]; 
    }

    private void PreviousPage()
    {
        if (PageNum - 1 >= 0)
        {
            PageNum--;
        }
        ComicsPage.sprite = Pages[PageNum];
    }
}
