using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float groundYPosition;
    public bool isJumping = false;

    private void Start()
    {
        isJumping = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        Debug.Log("Jumping now.");
        playerBody.AddForce(Vector2.up, ForceMode2D.Impulse);
        isJumping = true;

        //GroundCheck();
    }

    private void GroundCheck()
    {
        if(gameObject.transform.position.y <= groundYPosition)
        {
            Debug.Log("Landed again.");
            isJumping = false;
        }
    }
}
