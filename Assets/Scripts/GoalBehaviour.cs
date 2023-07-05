using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBehaviour : MonoBehaviour
{
    [SerializeField] UserInterface uiScript;
    [SerializeField] AudioSource goalSound;

    private void OnCollisionEnter(Collision col)
    {
        if (uiScript.completed == true)
        {
            StartCoroutine(WaitForMenu());
        }
    }

    private IEnumerator WaitForMenu()
    {
        goalSound.Play();
        yield return new WaitForSeconds(4.1f);
        SceneManager.LoadScene("Main Menu");
    }
}
