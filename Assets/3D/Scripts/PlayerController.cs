using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpHeight = 2.0f;
    [SerializeField] LayerMask mask;

    Rigidbody rb;
    Vector3 force;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        force = direction * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        var colliders = Physics.OverlapSphere(transform.position, 2);

        //foreach(var collider in colliders)
        //{
        //    //Destroy(collider.gameObject);
        //}

        //Debug.DrawRay(transform.position, transform.forward * 5);
        //if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 1))
        //{
        //    //Destroy(hit.collider.gameObject);
        //}
    }

    private void FixedUpdate()
    {
        rb.AddForce(force, ForceMode.Force);
        rb.AddTorque(Vector3.up, ForceMode.Force);
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, 2);
    }
}
