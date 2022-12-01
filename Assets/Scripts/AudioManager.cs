using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Image switch_off;
    [SerializeField] Image switch_on;

    private bool muted = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey("muted"))
        {
            if (PlayerPrefs.GetInt("muted") == 1)
            {
                muted = true;
                AudioListener.pause = true;
            }
        }
        updateButtonIcon();
    }

    public void switchMusic()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
            updateButtonIcon();
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
            updateButtonIcon();
        }
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    void updateButtonIcon()
    {
        if (muted)
        {
            switch_off.enabled = true;
            switch_on.enabled = false;
        }
        else
        {
            switch_off.enabled = false;
            switch_on.enabled = true;
        }
    }
}
