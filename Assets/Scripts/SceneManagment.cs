using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] GameObject player;
    [SerializeField] UserInterface uiScript;

    // the value of this has to be determined in ball movement since it is on the ball
    public bool reachedGoal = false;

    private string current;

    // Start is called before the first frame update
    void Start()
    {
        current = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        // reset scene upon ball being lost to the void
        if (player.transform.position.y < min)
        {
            SceneManager.LoadScene(current);
        }

        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }
}

