using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Switch : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Material colour;
    private bool pressed = false;

    [SerializeField] GameObject[] toActivate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!pressed)
        {
            colour.color = new Color(1, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject == player) && !pressed)
        {
            pressed = true;
            transform.position -= new Vector3(0, 0.09f, 0);
            colour.color = new Color(0, 1, 0);

            foreach (GameObject toActivateObj in toActivate)
            {
                toActivateObj.SetActive(true);
            }
        }
    }
}
