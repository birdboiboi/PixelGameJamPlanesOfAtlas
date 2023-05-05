using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManger : MonoBehaviour
{
    public Fly player;
    public TextMeshProUGUI health;


    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + player.health;
    }
}
