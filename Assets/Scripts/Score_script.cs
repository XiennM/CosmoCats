using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Score_script : MonoBehaviour
{
    //счетчик счета
    public int Score_counter = 0;
    //счетчик лучшего счета
    public static int High_score;

    public Text Score_txt;

    private void FixedUpdate()
    {
        Score_counter++;
        Score_txt.text = (Score_counter / 50).ToString();
        if (Score_counter > High_score)
        {
            High_score = (Score_counter / 50);
        }
    }

}
