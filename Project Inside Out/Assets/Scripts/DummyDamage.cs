using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DummyDamage : MonoBehaviour
{
    public GameObject healthBarSlider;
    public AudioClip breakSound;
    public bool gameIsEnding = false;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ItemInteraction collidingItemProperties = collision.gameObject.GetComponent<ItemInteraction>();
        
        if (collision.gameObject.CompareTag("Item"))
        {
            if (!collidingItemProperties.lockedToPlayer) 
            {
                AudioManager.Instance.PlayClip(collidingItemProperties.dummyHitSound);

                healthBarSlider.transform.localScale = new Vector2(
                    healthBarSlider.transform.localScale.x - collidingItemProperties.itemToDummyDamage,
                    healthBarSlider.transform.localScale.y);

                if (collidingItemProperties.destroyedOnDummyHit)
                {
                    Destroy(collision.gameObject);
                }

                if (!gameIsEnding)
                {
                    EndGameCheck();
                }
            }
        }
    }

    private void EndGameCheck()
    {
        if (healthBarSlider.transform.localScale.x <= 0)
        {
            StartCoroutine(EndGame(2));
        }
    }

    private IEnumerator EndGame(float duration)
    {
        gameIsEnding = true;
        
        AudioManager.Instance.PlayClip(breakSound);
        transform.Rotate(0, 0, -60);
        
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        AudioManager.Instance.LevelMusicIndex(1);
        SceneManager.LoadScene(2);
    }
}
