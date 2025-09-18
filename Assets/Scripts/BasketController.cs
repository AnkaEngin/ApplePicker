using UnityEngine;

public class BasketController : MonoBehaviour 
{
    public float speed = 10f; 
        
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        Debug.Log("Input value: " + move);
        
        transform.position += Vector3.right * move * speed * Time.deltaTime;
    }
}