using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSkin : MonoBehaviour
{
    public int skinNumber;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {

    }
    public void SetSkinNumber1()
    {
        skinNumber = 1;
    }

    public void SetSkinNumber2()
    {
        skinNumber = 2;
    }

    public void SetSkinNumber3()
    {
        skinNumber = 3;
    }
}
