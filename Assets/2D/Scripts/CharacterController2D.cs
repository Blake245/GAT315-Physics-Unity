using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpHeight = 2.0f;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] LayerMask mask;
    [SerializeField] Animator animator;

    Rigidbody2D rb;
    Vector2 force;
    Vector2 direction;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Vector2 direction = Vector2.zero;
        //direction.x = Input.GetAxis("Horizontal");

        force = direction * speed;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            
        //}

        animator.SetFloat("Speed", Mathf.Abs(direction.x));
        if (direction.x > 0.05f) spriteRenderer.flipX = false;
        else if (direction.x < 0) spriteRenderer.flipX = true;
    }
    private void FixedUpdate()
    {
        //rb.AddForce(force, ForceMode2D.Force);
        rb.linearVelocity = new Vector2(force.x, rb.linearVelocity.y);
        
    }
    #region Input
    public void OnMove(Vector2 v) => direction = v; // == { direction = v; }
    public void OnJump()
    {
        rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }
    public void OnAttack()
    {
        animator.SetTrigger("Attack");
    }
    public void OnDeath()
    {
        animator.SetTrigger("Death");
    }
    public void OnHit()
    {
        animator.SetTrigger("Hit");
    }
    #endregion
}
