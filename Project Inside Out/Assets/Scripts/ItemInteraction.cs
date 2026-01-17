using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer playerSprite;
    public Vector2 offset;
    public bool lockedToPlayer;

    public AudioClip dummyHitSound;
    public bool destroyedOnDummyHit;

    private void Update()
    {
        if (lockedToPlayer)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
            if (playerSprite.flipX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                
                transform.position = new Vector2(
                    player.transform.position.x - offset.x,
                    player.transform.position.y + offset.y);
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
                
                transform.position = (Vector2)player.transform.position + offset;
            }
        }
    }
}
