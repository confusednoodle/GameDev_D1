using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// THE SWITCH OBJECT IS INTENDED TO BE A STANDARD CUBE WITH THE RED MATERIAL
// ITS INTEDED TO BE 0.1 ABOVE THE PLATFORM IT'S IN
// YOU MIGHT WANNA ADD IT TO THE PLATFORMS LIST SO THAT YOU CAN JUMP ON THE SWITCH

public class Lvl3LeftMostSwitch : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform switchTrans;
    [SerializeField] Material colour;
    private bool pressed = false;

    // add switch specific vars here
    [SerializeField] GameObject toActivate;
    [SerializeField] GameObject midSwitch;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // keep colour red
        if (!pressed)
        {
            colour.color = new Color(1, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // what happens on first press
        if ((collision.gameObject == player) && !pressed)
        {
            pressed = true;
            // avoid y fighting
            switchTrans.position -= new Vector3(0, 0.09f, 0);
            colour.color = new Color(0, 1, 0);

            // add specific switch functionality here
            toActivate.SetActive(true);
            midSwitch.SetActive(true);
        }
    }
}