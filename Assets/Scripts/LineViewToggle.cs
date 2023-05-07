using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class LineViewToggle : MonoBehaviour
{
    
    public GameObject[] lines;
    public SpriteRenderer[] busts;
    void Start()
    {
        SelectLineViews(0);
    }
    public void SelectLineViews(int selection)
    {
        
            Debug.Log("selection"+ selection+ "*********8");

            for (int i = 0; i < lines.Length; i++)
        {
            Debug.Log("i to i" + i + " " + (i == selection));
            lines[i].SetActive(i == selection);
            if(i == selection)
            {
                busts[i].color = Color.white;
            }
            else
            {
                busts[i].color = Color.grey;

            }

        }
    }
    

}
