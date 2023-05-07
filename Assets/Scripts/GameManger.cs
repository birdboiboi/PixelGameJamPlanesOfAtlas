using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Yarn.Unity;
using static Unity.VisualScripting.Member;

public class GameManger : MonoBehaviour
{
    [SerializeField]
    static public int gameState = 0;
    [SerializeField]
    static public int playerHealth = 100;
    [SerializeField]
    static public int playerMaxHealth = 100;
    [SerializeField]
    static public bool isPaused = false;

    public string[] SceneNames;
    public AudioClip[] musics;

    [SerializeField]
    public AudioSource asorce;

    public Fly player;
    public TextMeshProUGUI health;
    public Enemy boss;
    public int winScreen;
    public int loseScreen;


    private void Start()
    {
<<<<<<< HEAD

        switch (gameState)
=======
        if (gameState == 1 && !isPaused)
>>>>>>> af03e04a066e3eb109f397dbf1e1d8d0c7b132b6
        {
            case 0:
                asorce = GetComponent<AudioSource>();
                asorce.clip = musics[0];
                asorce.Play();
                break;
            case 1:
                asorce.clip = musics[1];
                asorce.Play();
                break;
            case 2:
                if (!isPaused)
                {
                    StartCoroutine(delayGamePlay());
                    player.health = playerHealth;

                }
                break;
            case 4:
                asorce.clip = musics[2];
                asorce.Play();
                break;
            case 5:
                asorce.clip = musics[2];
                asorce.Play();
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckRestart();
        CheckExit();
<<<<<<< HEAD
        Debug.Log(gameState);
=======
>>>>>>> af03e04a066e3eb109f397dbf1e1d8d0c7b132b6
        switch (gameState)
        {
            case 2:
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

<<<<<<< HEAD
            case 1:
=======
            case 2:
>>>>>>> af03e04a066e3eb109f397dbf1e1d8d0c7b132b6

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


    public void OpenScene(int scene)
    {
        gameState = scene;
        SceneManager.LoadScene(SceneNames[scene]);
    }

    [YarnCommand("OpenScene")]
    public void YarnOpenScene(int scene)
    {
        OpenScene(scene);
    }
    private void CheckRestart()
    {
        if (Input.GetKey(KeyCode.R))
        {
            playerHealth = playerMaxHealth;
<<<<<<< HEAD
            if (gameState == 2)
=======
            if (gameState == 1)
>>>>>>> af03e04a066e3eb109f397dbf1e1d8d0c7b132b6
            {
                player.anim.SetBool("Intro Scene", true);
            }
            else
            {
                gameState = 2;
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
