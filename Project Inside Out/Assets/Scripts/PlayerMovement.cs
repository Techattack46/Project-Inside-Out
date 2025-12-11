using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;

    private void Update()
    {   
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping now.");
            playerBody.AddForce(Vector2.up, ForceMode2D.Impulse);
        }
    }
}
