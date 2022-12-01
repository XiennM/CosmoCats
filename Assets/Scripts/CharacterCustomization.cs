using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CharacterCustomization : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public List<Sprite> skins;
    private int skinNumber;

    private void Start()
    {
        if (spriteRenderer.name.Contains("Cat"))
        {
            spriteRenderer.sprite = skins[PlayerPrefs.GetInt("CatSkin")];
        }
        else if (spriteRenderer.name.Contains("Rocket"))
        {
            spriteRenderer.sprite = skins[PlayerPrefs.GetInt("RocketSkin")];
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
    }

    public void SkinMinus()
    {
        skinNumber--;
        if (skinNumber == -1)
        {
            skinNumber = skins.Count - 1;
        }
        spriteRenderer.sprite = skins[skinNumber];
    }

    public void SaveRocketSkin()
    {
        PlayerPrefs.SetInt("RocketSkin", skinNumber);
        
    }

    public void SaveCatSkin()
    {
        PlayerPrefs.SetInt("CatSkin", skinNumber);

    }
}
