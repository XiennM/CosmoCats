using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl : MonoBehaviour
{
    public GameObject[] lvls = new GameObject[12];
    public bool[] lvls_logic = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false };
    System.Random random = new System.Random();
    public int lvl_pos = 12;

    private void Start()
    {
        InvokeRepeating("Spawn",1,1);
    }
    private void Update()
    {
        for (int i = 0; i < lvls.Length; i++)
        {
            if (lvls[i].GetComponent<Transform>().position.y >= transform.position.y - 12)
            {
                lvls_logic[i] = true;
                //lvls[i].GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                //lvls[i].GetComponent<SpriteRenderer>().color = Color.green;
                lvls_logic[i] = false;
            }
        }

    }

    public void Spawn()
    {
        int i = random.Next(12);

        if (!lvls_logic[i])
        {
            lvls[i].GetComponent<Transform>().position = new Vector3(0, lvl_pos, 0);
            lvl_pos += 6;
        }
    }
}
