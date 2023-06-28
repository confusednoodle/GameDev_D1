using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject ball;

    private Vector3 offset;
    private Transform ballPos;

    // Start is called before the first frame update
    void Start()
    {
        ballPos = ball.GetComponent<Transform>();
        offset = transform.position - ballPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ballPos.position.x + offset.x, transform.position.y, ballPos.position.z + offset.z);
    }
}
