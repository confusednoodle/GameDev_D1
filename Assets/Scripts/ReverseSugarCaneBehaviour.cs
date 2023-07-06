using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseSugarCaneBehaviour : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    void Update()
    {
        transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime));
    }
}
