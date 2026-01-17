using UnityEngine;

public class OutOfBoundsFailSafe : MonoBehaviour
{
    public float horizontalEdge;
    public float verticalEdge;
    
    private void Update()
    {
        if (transform.position.x < -horizontalEdge)
        {
            transform.position = Vector2.zero;
        }

        if (transform.position.x > horizontalEdge)
        {
            transform.position = Vector2.zero;
        }

        if (transform.position.y < -verticalEdge)
        {
            transform.position = Vector2.zero;
        }

        if (transform.position.y > verticalEdge)
        {
            transform.position = Vector2.zero;
        }
    }
}
