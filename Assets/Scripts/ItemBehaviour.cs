using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);

    }
}
