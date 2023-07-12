using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour
{
    //text objects
    [SerializeField] TMP_Text itemCountText;
    [SerializeField] TMP_Text currentTimeText;
    [SerializeField] TMP_Text highscoreText;

    //ui variables
    public int itemCount = 0;
    public float currentTime = 0.00f;
    public float highscore = 0.00f; //needs to be saved between scene loads
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
        Debug.Log(playerSkin);
        Debug.LogWarning(skin3);
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
        highscore = PlayerPrefs.GetFloat("highscore");
        highscoreText.text = highscore.ToString("0.00");
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

        if(goalScript.reachedGoal == false)
        {
            currentTime += Time.deltaTime;
            currentTimeText.text = "Time: " + currentTime.ToString("0.00");
        }
    }
}
