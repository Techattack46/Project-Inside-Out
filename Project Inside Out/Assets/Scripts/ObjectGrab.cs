using UnityEngine;

public class ObjectGrab : MonoBehaviour
{
    public GameObject items;
    private GameObject heldItem;
    public float minimumItemRange;
    public float throwRange;

    private void Update()
    {
        ObjectEquip();
    }

    private void ObjectEquip()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem == null)
            {
                GameObject currentItem = FindNearestItem();

                if (currentItem != null)
                {
                    currentItem.GetComponent<ItemInteraction>().lockedToPlayer = true;
                    heldItem = currentItem;
                }
            }
            else
            {
                heldItem.GetComponent<ItemInteraction>().lockedToPlayer = false;

                if (GetComponent<SpriteRenderer>().flipX)
                {
                    heldItem.GetComponent<Rigidbody2D>().AddForce(throwRange * -transform.right, ForceMode2D.Impulse);
                }
                else
                {
                    heldItem.GetComponent<Rigidbody2D>().AddForce(throwRange * transform.right, ForceMode2D.Impulse);
                }

                heldItem = null;
            }
        }
    }

    private GameObject FindNearestItem()
    {
        float nearestPosition = 10000;
        int nearestChild = 0;

        for (int i = 0; i < items.transform.childCount; i++)
        {
            Transform item = items.transform.GetChild(i).transform;

            float distance = (item.position - transform.position).magnitude;
            if (distance < nearestPosition)
            {
                nearestPosition = distance;
                nearestChild = i;
            }
        }

        if (nearestPosition < minimumItemRange)
        {
            return items.transform.GetChild(nearestChild).gameObject;
        }
        else
        {
            return null;
        }
    }
}
