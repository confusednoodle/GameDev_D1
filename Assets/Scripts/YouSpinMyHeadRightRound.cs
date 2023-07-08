using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouSpinMyHeadRightRound : MonoBehaviour
{
    public bool spinnn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spinnn)
        {
            transform.Rotate(10, 0, 10);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
