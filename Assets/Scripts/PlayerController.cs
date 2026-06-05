using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5;
    private bool isGrounded;
    public float gravity;
    public float jumpHeight = 5;


    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    

    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void processMove(Vector2 input) // receives the input from inputManager.cs and applied to character controller.
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;
        controller.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2;
        }
        controller.Move(playerVelocity * Time.deltaTime);

        Debug.Log(playerVelocity.y);
    }

    public void jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
    
}