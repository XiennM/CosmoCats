using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public List<Sprite> skins;
    private int skinNumber;
    public Button buyButton;
    public Sprite _buy;
    public Sprite _equip;
    public Sprite _equiped;

    private void Start()
    {
        if (spriteRenderer.name.Contains("Cat"))
        {
            spriteRenderer.sprite = skins[PlayerPrefs.GetInt("CatSkin")];

            if (PlayerPrefs.GetInt("novy_kot" + "buy") == 0)
            {
                int price = 100;
                foreach (Sprite skin in skins)
                {
                    if ("novy_kot" == skin.name)
                    {
                        PlayerPrefs.SetInt("novy_kot" + "buy", 1);
                        PlayerPrefs.SetInt("novy_kot" + "equip", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(skin.name + "buy", 0);
                        PlayerPrefs.SetInt(skin.name + "price", price);
                        price += 50;
                    }
                }
            }
            if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "buy") == 0)
            {
                buyButton.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt(spriteRenderer.sprite.name + "price").ToString();
                buyButton.GetComponent<Image>().sprite = _buy;
            }
            else if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "equip") == 0)
            {
                buyButton.GetComponent<Image>().sprite = _equip;
                buyButton.GetComponentInChildren<Text>().text = "";
            }
            else
            {
                buyButton.GetComponent<Image>().sprite = _equiped;
                buyButton.GetComponentInChildren<Text>().text = "";
            }
        }
        else if (spriteRenderer.name.Contains("Rocket"))
        {
            spriteRenderer.sprite = skins[PlayerPrefs.GetInt("RocketSkin")];

            if (PlayerPrefs.GetInt("Rocket_0" + "buy") == 0)
            {
                int price = 100;
                foreach (Sprite skin in skins)
                {
                    if ("Rocket_0" == skin.name)
                    {
                        PlayerPrefs.SetInt("Rocket_0" + "buy", 1);
                        PlayerPrefs.SetInt("Rocket_0" + "equip", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(skin.name + "buy", 0);
                        PlayerPrefs.SetInt(skin.name + "price", price);
                        price += 50;
                    }
                }
            }

            if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "buy") == 0)
            {
                buyButton.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt(spriteRenderer.sprite.name + "price").ToString();
                buyButton.GetComponent<Image>().sprite = _buy;
            }
            else if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "equip") == 0)
            {
                buyButton.GetComponent<Image>().sprite = _equip;
                buyButton.GetComponentInChildren<Text>().text = "";
            }
            else
            {
                buyButton.GetComponent<Image>().sprite = _equiped;
                buyButton.GetComponentInChildren<Text>().text = "";
            }
        }
    }

    public void BuySkin()
    {
        if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "buy") == 0)
        {
            if (PlayerPrefs.GetInt("Coins") >= PlayerPrefs.GetInt(spriteRenderer.sprite.name + "price"))
            {
                buyButton.GetComponent<Image>().sprite = _equiped;
                buyButton.GetComponentInChildren<Text>().text = "";

                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - PlayerPrefs.GetInt(spriteRenderer.sprite.name + "price"));

                PlayerPrefs.SetInt(spriteRenderer.sprite.name + "buy", 1);

                foreach (Sprite skin in skins)
                {
                    if (spriteRenderer.sprite.name == skin.name)
                    {
                        PlayerPrefs.SetInt(spriteRenderer.sprite.name + "equip", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(skin.name + "equip", 0);
                    }
                }

                if (spriteRenderer.name.Contains("Cat"))
                {
                    PlayerPrefs.SetInt("CatSkin", skinNumber);
                }
                else if (spriteRenderer.name.Contains("Rocket"))
                {
                    PlayerPrefs.SetInt("RocketSkin", skinNumber);
                }
            }
        }
        else if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "buy") == 1)
        {
            buyButton.GetComponent<Image>().sprite = _equiped;
            buyButton.GetComponentInChildren<Text>().text = "";

            foreach (Sprite skin in skins)
            {
                if (spriteRenderer.sprite.name == skin.name)
                {
                    PlayerPrefs.SetInt(spriteRenderer.sprite.name + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(skin.name + "equip", 0);
                }
            }

            if (spriteRenderer.name.Contains("Cat"))
            {
                PlayerPrefs.SetInt("CatSkin", skinNumber);
            }
            else if (spriteRenderer.name.Contains("Rocket"))
            {
                PlayerPrefs.SetInt("RocketSkin", skinNumber);
            }
        }
    }

    public void SkinPlus()
    {
        skinNumber++;
        if (skinNumber == skins.Count)
        {
            skinNumber = 0;
        }
        spriteRenderer.sprite = skins[skinNumber];

        if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "buy") == 0)
        {
            buyButton.GetComponent<Image>().sprite = _buy;
            buyButton.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt(spriteRenderer.sprite.name + "price").ToString();
        }
        else if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "equip") == 0)
        {
            buyButton.GetComponent<Image>().sprite = _equip;
            buyButton.GetComponentInChildren<Text>().text = "";
        }
        else if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "equip") == 1)
        {
            buyButton.GetComponent<Image>().sprite = _equiped;
            buyButton.GetComponentInChildren<Text>().text = "";
        }
    }

    public void SkinMinus()
    {
        skinNumber--;
        if (skinNumber == -1)
        {
            skinNumber = skins.Count - 1;
        }
        spriteRenderer.sprite = skins[skinNumber];

        if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "buy") == 0)
        {
            buyButton.GetComponent<Image>().sprite = _buy;
            buyButton.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt(spriteRenderer.sprite.name + "price").ToString();
        }
        else if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "equip") == 0)
        {
            buyButton.GetComponent<Image>().sprite = _equip;
            buyButton.GetComponentInChildren<Text>().text = "";
        }
        else if (PlayerPrefs.GetInt(spriteRenderer.sprite.name + "equip") == 1)
        {
            buyButton.GetComponent<Image>().sprite = _equiped;
            buyButton.GetComponentInChildren<Text>().text = "";
        }
    }
}
