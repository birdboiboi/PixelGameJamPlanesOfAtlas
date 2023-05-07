using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [SerializeField]
    static public int gameState = 1;
    [SerializeField]
    static public int playerHealth = 100;
    [SerializeField]
    static public int playerMaxHealth = 100;
    [SerializeField]
    static public bool isPaused = false;

    public string[] SceneNames;

    public Fly player;
    public TextMeshProUGUI health;
    public Enemy boss;
    public int winScreen;
    public int loseScreen;


    private void Start()
    {
        if (gameState == 1 && !isPaused)
        {
            player.health = playerHealth;
            StartCoroutine(delayGamePlay());
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckRestart();
        CheckExit();
        switch (gameState)
        {
            case 1:
                health.text = "Health: " + player.health + " " + boss.health;
                playerHealth = player.health;
                switch (boss.health)
                {
                    case <= 0:
                        player.anim.SetBool("Win", true);
                        health.text = "Enemy Defeated";
                        StartCoroutine(triggerEndScreen(player.anim.GetCurrentAnimatorStateInfo(0).length - .125f, winScreen));
                        break;

                }
                switch (player.health)
                {
                    case <= 0:
                        player.anim.Play("RaptureDieOut");
                        StartCoroutine(triggerEndScreen(player.anim.GetCurrentAnimatorStateInfo(0).length - .125f, loseScreen));
                        health.text = "Enemy Defeated";
                        break;

                }
                break;

            case 2:

                break;
        }

    }
    IEnumerator delayGamePlay()
    {
        yield return new WaitForSeconds(1);
        player.anim.SetBool("Intro Scene", false);
    }
    IEnumerator triggerEndScreen(float delay, int winlose)
    {

        yield return new WaitForSeconds(delay);
        gameState = winlose;
        SceneManager.LoadScene(SceneNames[winlose]);
    }
    private void CheckRestart()
    {
        if (Input.GetKey(KeyCode.R))
        {
            playerHealth = playerMaxHealth;
            if (gameState == 1)
            {
                player.anim.SetBool("Intro Scene", true);
            }
            else
            {
                gameState = 1;
            }
            SceneManager.LoadScene(SceneNames[1]);

        }
    }
    private void CheckExit() { 
    if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
