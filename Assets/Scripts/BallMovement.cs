using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class BallMovement : MonoBehaviour
{
    // movement vars
    [SerializeField] float speed;
    private Rigidbody rigid;
    private Vector3 movementDirection = Vector3.zero;

    // jump vars
    [SerializeField] float jumpSpeed;
    [SerializeField] GameObject[] platforms;
    private bool grounded = true;
    private bool canDoubleJump = false;

    // Movement particles
    private ParticleSystem particleSystem;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = Vector3.zero;

        // moving
        if (Input.GetKey(KeyCode.W))
        {
            movementDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDirection += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementDirection += Vector3.left;
        }

        rigid.AddForce(movementDirection.normalized * speed, ForceMode.Impulse);

        // jump + double jump
        if (Input.GetKeyDown(KeyCode.Space) && (grounded | canDoubleJump))
        {
            rigid.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            if (grounded)
            {
                grounded = false;
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
            }
            else
            {
                canDoubleJump = false;
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (platforms.Contains(collision.gameObject))
        {
            grounded = true;
        }
    }
}
