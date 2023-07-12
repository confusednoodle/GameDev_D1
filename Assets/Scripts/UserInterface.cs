using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    //text objects
    [SerializeField] TMP_Text itemCountText;
    [SerializeField] TMP_Text currentTimeText;
    [SerializeField] TMP_Text highscoreText;

    //ui variables
    public int itemCount = 0;
    public float currentTime = 0.00f;
    public float highscore1 = 0.00f;
    public float highscore2 = 0.00f;
    public float highscore3 = 0.00f;
    public bool completed = false;
    [SerializeField] int maxItems;
    public int playerSkin;
    [SerializeField] Material skin1;
    [SerializeField] Material skin2;
    [SerializeField] Material skin3;
    [SerializeField] GameObject player;

    //access to other scripts
    [SerializeField] BallMovement playerScript;
    [SerializeField] GoalBehaviour goalScript;

    //music and sounds
    public AudioSource gameMusic;

    void Start()
    {
        playerSkin = PlayerPrefs.GetInt("skin");

        if (playerSkin == 1)
        {
            player.GetComponent<MeshRenderer>().material = skin1;
        }

        if (playerSkin == 2)
        {
            player.GetComponent<MeshRenderer>().material = skin2;
        }

        if (playerSkin == 3)
        {
            player.GetComponent<MeshRenderer>().material = skin3;
        }

        gameMusic.Play();
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            highscore1 = PlayerPrefs.GetFloat("highscore1");
            highscoreText.text = highscore1.ToString("0.00");
        }

        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            highscore2 = PlayerPrefs.GetFloat("highscore2");
            highscoreText.text = highscore2.ToString("0.00");
        }

        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            highscore3 = PlayerPrefs.GetFloat("highscore3");
            highscoreText.text = highscore3.ToString("0.00");
        }

        itemCountText.text = "Collected: " + itemCount.ToString() + "/" + maxItems.ToString(); //reset item count when restarting scene
        currentTimeText.text = "Time: " + currentTime.ToString(); //reset time when restarting scene
    }

    void Update()
    {
        if (itemCount == maxItems && completed == false)
        {
            itemCountText.color = new Color(0.00f, 1.00f, 0.1216f, 1.00f);
            completed = true;
        }

        itemCount = playerScript.itemCount;
        itemCountText.text = "Collected: " + itemCount.ToString() + "/" + maxItems.ToString();

        if (goalScript.reachedGoal == false)
        {
            currentTime += Time.deltaTime;
            currentTimeText.text = "Time: " + currentTime.ToString("0.00");
        }
    }
}
