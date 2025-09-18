using UnityEngine;

public class Apple : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basket"))
        {
            // Apple caught by basket - increase score!
            if (GameManager.instance != null)
            {
                GameManager.instance.AppleCaught();
            }
            
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            // Apple hit ground - lose a heart!
            if (GameManager.instance != null)
            {
                GameManager.instance.AppleMissed();
            }
            
            Destroy(gameObject);
        }
    }
}