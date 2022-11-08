using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Public Vars")]
    public float jumpForce;
    public bool grounded;
    private Rigidbody2D rb;

    [Header("Private Vars")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radiusCircle;
    [SerializeField] private LayerMask whatIsGround;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, radiusCircle, whatIsGround);
        // use space and w to jump
        if (Input.GetButtonDown("Jump") && grounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    
    private void OnDrawGizmos(){
        Gizmos.DrawSphere(groundCheck.position, radiusCircle);
    }
}
