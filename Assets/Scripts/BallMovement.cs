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
    private Vector3 inputDirection = Vector3.zero;

    // jump vars
    [SerializeField] float jumpSpeed;
    [SerializeField] GameObject[] platforms;
    private bool grounded = true;
    private bool canDoubleJump = false;

    // Movement particles
    [SerializeField] GameObject ParticleSystemContainer;
    private ParticleSystem dustParticles;
    private bool particlesPlaying = false;

    // god mode
    private bool god = false;
    [SerializeField] Transform ballTrans;

    // item count
    public int itemCount = 0;
    [SerializeField] AudioSource itemSound;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        dustParticles = ParticleSystemContainer.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystemContainer.transform.position = transform.position;
        inputDirection = Vector3.zero;

        // enable god mode
        if (Input.GetKeyDown(KeyCode.G) && !god)
        {
            god = true;
            rigid.isKinematic = true;
        }
        // disable god mode
        else if (Input.GetKeyDown(KeyCode.G) && god)
        {
            god = false;
            rigid.isKinematic = false;
        }

        // moving
        // if isKinematic, forces don't apply, so god mode has to have its own movement system
        if (god)
        {
            if (Input.GetKey(KeyCode.W))
            {
                ballTrans.position += Vector3.forward * speed * 50 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                ballTrans.position += Vector3.back * speed * 50 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                ballTrans.position += Vector3.right * speed * 50 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                ballTrans.position += Vector3.left * speed * 50 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                ballTrans.position += Vector3.down * speed * 50 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.E))
            {
                ballTrans.position += Vector3.up * speed * 50 * Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                inputDirection += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputDirection += Vector3.back;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputDirection += Vector3.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputDirection += Vector3.left;
            }
        }
        

        rigid.AddForce(inputDirection.normalized * speed, ForceMode.Impulse);

        if (grounded && inputDirection != Vector3.zero)
        {
            ParticleSystemContainer.transform.rotation = Quaternion.FromToRotation(dustParticles.shape.position, -inputDirection.normalized);

            if (!particlesPlaying)
            {
                dustParticles.Play();
                particlesPlaying = true;
            }
        }
        else
        {
            dustParticles.Stop();
            particlesPlaying = false;
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

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Item")
        {
            itemCount += 1;
            itemSound.Play();
            Debug.Log(itemCount.ToString());
        }
    }
}
