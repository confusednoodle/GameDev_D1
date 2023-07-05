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
    [SerializeField] int maxItems;

    [SerializeField] BallMovement playerScript;

    void Start()
    {
        itemCountText.text = "Collected: " + itemCount.ToString() + "/" + maxItems.ToString(); //reset item count when restarting scene
        currentTimeText.text = "Time: " + currentTime.ToString(); //reset time when restarting scene
    }

    void Update()
    {
        if (itemCount == maxItems)
        {
            Debug.Log("color");
            itemCountText.color = new Color(127, 100, 100, 100);
        }

        itemCount = playerScript.itemCount;
        itemCountText.text = "Collected: " + itemCount.ToString() + "/" + maxItems.ToString(); 
        currentTime += Time.deltaTime;
        currentTimeText.text = "Time: " + currentTime.ToString("0.00");
    }
}
