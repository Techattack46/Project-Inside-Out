using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float jumpFloat;
    public AudioClip jumpSound;

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
        AudioManager.Instance.PlayClip(jumpSound);
        playerBody.AddForce(new Vector2(playerBody.linearVelocityX, jumpFloat));
    }
}
