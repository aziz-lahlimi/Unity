using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJuming = false;
    public bool isGrounded;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

   
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if ( Input.GetButtonDown("Jump"))
        {
            isJuming = true;
        }

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJuming == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJuming = false;
        }
    }
}
