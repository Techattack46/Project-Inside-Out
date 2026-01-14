using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public bool isGrounded;
    public float jumpFloat;
    public AudioClip jumpSound;
    public float walkSpeed;
    public SpriteRenderer playerSprite;
    
    public LayerMask groundLayer;
    public float groundDistance;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerSprite.flipX = false;
            transform.Translate(new Vector3(walkSpeed, 0, 0));
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerSprite.flipX = true;
            transform.Translate(new Vector3(-walkSpeed, 0, 0));
        }
    }

    private void Jump()
    {
        AudioManager.Instance.PlayClip(jumpSound);
        playerBody.AddForce(new Vector2(playerBody.linearVelocityX, jumpFloat));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.down * groundDistance);
    }
}
