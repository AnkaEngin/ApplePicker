using UnityEngine;

public class Apple : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Apple collided with: " + other.name + " (Tag: " + other.tag + ")");
        
        if (other.CompareTag("Basket"))
        {
            // Apple caught by basket
            Debug.Log("Apple caught!");
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            // Apple hit ground
            Debug.Log("Apple missed!");
            Destroy(gameObject);
        }
    }
}