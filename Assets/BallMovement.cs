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

    // jump vars
    [SerializeField] float jumpSpeed;
    [SerializeField] GameObject[] platforms;
    private bool grounded = true;
    private bool canDoubleJump = false;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // moving
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(Vector3.back * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector3.right * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector3.left * speed);
        }

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
