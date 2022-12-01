using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGameManager : MonoBehaviour
{
    public GameObject Player;

    public List<Sprite> Sprites;

    private Sprite playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = Sprites[PlayerPrefs.GetInt("RocketSkin")];

        Player.GetComponent<SpriteRenderer>().sprite = playerSprite;
    }

    
}
