using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float jumpFloat;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
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
        playerBody.AddForce(new Vector2(playerBody.linearVelocityX, jumpFloat));
    }
}
