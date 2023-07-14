using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBehaviour : MonoBehaviour
{
    [SerializeField] UserInterface uiScript;
    [SerializeField] AudioSource goalSound;
    public bool reachedGoal = false;

    private void OnCollisionEnter(Collision col)
    {
        if (uiScript.completed == true)
        {
            reachedGoal = true;
            StartCoroutine(WaitForMenu());
        }
    }

    private IEnumerator WaitForMenu()
    {
        uiScript.gameMusic.Stop();
        goalSound.Play(); //plays goal music track
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            if (uiScript.highscore1 > uiScript.currentTime || uiScript.highscore1 <= 0)
            {
                PlayerPrefs.SetFloat("highscore1", uiScript.currentTime); //sets new highscore
            }
        }

        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            if (uiScript.highscore2 > uiScript.currentTime || uiScript.highscore2 <= 0)
            {
                PlayerPrefs.SetFloat("highscore2", uiScript.currentTime); //sets new highscore
            }
        }

        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            if (uiScript.highscore3 > uiScript.currentTime || uiScript.highscore3 <= 0)
            {
                PlayerPrefs.SetFloat("highscore3", uiScript.currentTime); //sets new highscore
            }
        }

        yield return new WaitForSeconds(4.1f); //waits for music to finish playing
        SceneManager.LoadScene("Main Menu"); //loads main menu
    }
}
