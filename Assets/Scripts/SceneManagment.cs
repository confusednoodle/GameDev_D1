using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] GameObject player;

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
