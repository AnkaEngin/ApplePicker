using UnityEngine;

public class TreeMover : MonoBehaviour
{
    public float speed = 2f;
    public float leftBound = -8f;
    public float rightBound = 8f;
    public GameObject applePrefab;
    public float appleDropRate = 1f;
    
    private float direction = 1f; // 1 for right, -1 for left
    private float nextDirectionChange;
    private float nextAppleDrop;
    
    void Start()
    {
        nextDirectionChange = Time.time + Random.Range(2f, 5f);
        nextAppleDrop = Time.time + appleDropRate;
    }
    
    void Update()
    {
        // Move the tree
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
        
        // Check boundaries and reverse direction
        if (transform.position.x <= leftBound || transform.position.x >= rightBound)
        {
            direction *= -1f;
            nextDirectionChange = Time.time + Random.Range(2f, 5f);
        }
        
        // Check for random direction change
        if (Time.time >= nextDirectionChange)
        {
            direction *= -1f;
            nextDirectionChange = Time.time + Random.Range(2f, 5f);
        }
        
        // Drop apples
        if (Time.time >= nextAppleDrop)
        {
            DropApple();
            nextAppleDrop = Time.time + appleDropRate;
        }
    }
    
    void DropApple()
    {
        Vector3 applePos = transform.position;
        applePos.y -= 1f;
        Instantiate(applePrefab, applePos, Quaternion.identity);
    }
}