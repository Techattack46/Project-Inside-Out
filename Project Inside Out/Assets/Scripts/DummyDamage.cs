using UnityEngine;

public class DummyDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the dummy collides with an item...
        if (collision.gameObject.CompareTag("Item"))
        {
            //and that item is no longer locked to the player...
            if (!collision.gameObject.GetComponent<ItemInteraction>().lockedToPlayer) 
            {
                AudioManager.Instance.PlayClip(collision.gameObject.GetComponent<ItemInteraction>().dummyHitSound);
                
                //the dummy takes damage
                Debug.Log("Ouch!");

                //then if the item's supposed to be destroyed on hit...
                if (collision.gameObject.GetComponent<ItemInteraction>().destroyedOnDummyHit)
                {
                    //do so
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
