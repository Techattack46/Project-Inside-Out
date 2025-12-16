using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        Debug.Log("Jumping now.");
        playerBody.AddForce(Vector2.up, ForceMode2D.Impulse);
    }
}
