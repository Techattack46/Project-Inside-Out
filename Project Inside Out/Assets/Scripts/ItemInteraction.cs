using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer playerSprite;
    public Vector2 offset;
    public bool lockedToPlayer;

    public bool destroyedOnDummyHit;

    private void Update()
    {
        if (lockedToPlayer)
        {
            if (playerSprite.flipX)
            {
                transform.position = new Vector2(
                    player.transform.position.x - offset.x,
                    player.transform.position.y + offset.y);
                
                //transform.position = (Vector2)player.transform.position - offset; //except only x needs to be flipped
            }
            else
            {
                transform.position = (Vector2)player.transform.position + offset;
            }
        }
    }
}
