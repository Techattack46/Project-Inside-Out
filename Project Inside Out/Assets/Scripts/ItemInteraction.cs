using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public GameObject player;
    public Vector2 offset;
    public bool lockedToPlayer;

    public bool destroyedOnDummyHit;

    private void Update()
    {
        if (lockedToPlayer)
        {
            GetComponent<BoxCollider2D>().excludeLayers = LayerMask.GetMask("Player");

            transform.position = (Vector2) player.transform.position + offset;
        }
    }
}
