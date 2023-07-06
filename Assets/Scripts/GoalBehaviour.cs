using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBehaviour : MonoBehaviour
{
    [SerializeField] UserInterface uiScript;
    [SerializeField] AudioSource goalSound;
    public bool reachedGoal = false;

    private void OnTriggerEnter(Collider col)
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
        if (uiScript.highscore > uiScript.currentTime)
        {
            PlayerPrefs.SetFloat("highscore", uiScript.currentTime); //sets new highscore
        }
        yield return new WaitForSeconds(4.1f); //waits for music to finish playing
        SceneManager.LoadScene("Main Menu"); //loads main menu
    }
}