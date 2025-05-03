using UnityEngine;

public class HingeCollision : MonoBehaviour
{

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.freezeRotation = false;
            Debug.Log("Collision");
        } 
    }
}
