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
            }
            else
            {
                transform.position = (Vector2)player.transform.position + offset;
            }
        }
    }
}
