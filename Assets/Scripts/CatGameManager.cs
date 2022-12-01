using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGameManager : MonoBehaviour
{
    public GameObject Player;

    public List<Sprite> Sprites;

    private Sprite playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = Sprites[PlayerPrefs.GetInt("CatSkin")];

        Player.GetComponent<SpriteRenderer>().sprite = playerSprite;
    }

    
}
