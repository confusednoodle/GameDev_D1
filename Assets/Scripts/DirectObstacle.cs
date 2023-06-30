using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectObstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
