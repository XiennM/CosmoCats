using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class Coin_manage : MonoBehaviour
{
    public Text coin_txt;

    // Start is called before the first frame update
    void Start()
    {
        coin_txt.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coin_txt.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
