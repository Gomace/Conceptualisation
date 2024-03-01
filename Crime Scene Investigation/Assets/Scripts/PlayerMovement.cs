using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Global Global;
    
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    //public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private AudioSource footsteps;
    
    Vector3 velocity;
    private bool isGrounded;

    void Awake()
    {
        footsteps = transform.GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Global.Busy)
            return;
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        { 
            if (!footsteps.isPlaying)
                footsteps.Play();
        }
        else
            footsteps.Stop();

        /*if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }*/

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
