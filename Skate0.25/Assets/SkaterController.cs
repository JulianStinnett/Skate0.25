using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]

public class SkaterController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6.5f;
    public float jumpVelocity = 12f;

    [Header("Jump Forgiveness")]
    public float coyoteTime = 0.08f;     // time after leaving ground you can still jump
    public float jumpBuffer = 0.12f;     // time before landing that a jump press is buffered

    [Header("Ground Check")]
    public LayerMask groundMask;
    public float groundCheckPad = 0.05f; // extra space below collider for ray

    Rigidbody2D rb;
    CapsuleCollider2D col;

    float coyoteTimer = 0f;
    float bufferTimer = -1f;
    bool grinding = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        // Input buffering
        if (Input.GetKeyDown(KeyCode.Space))
            bufferTimer = jumpBuffer;

        // Track coyote timer
        if (IsGrounded()) coyoteTimer = coyoteTime;
        else coyoteTimer -= Time.deltaTime;

        // Try jump if buffered
        if (bufferTimer > 0f)
        {
            bufferTimer -= Time.deltaTime;
            if (coyoteTimer > 0f || grinding)
            {
                // clear any downward vel before jump for snappier feel
                var v = rb.velocity;
                if (v.y < 0f) v.y = 0f;
                v.y = jumpVelocity;
                rb.velocity = v;

                grinding = false; // leave rail if we were grinding
                bufferTimer = -1f;
                SimpleAudio.Instance?.PlayJump();
            }
        }
    }

    void FixedUpdate()
    {
        // Constant forward motion (endless runner feel)
        var v = rb.velocity;
        v.x = moveSpeed;
        rb.velocity = v;
    }

    bool IsGrounded()
    {
        // Box cast slightly below collider bottom
        Vector2 size = new Vector2(col.bounds.size.x * 0.95f, 0.05f);
        Vector2 origin = (Vector2)col.bounds.center + Vector2.down * (col.bounds.extents.y + 0.02f);
        var hit = Physics2D.OverlapBox(origin, size, 0f, groundMask);
        return hit != null && !grinding;
    }

    void OnDrawGizmosSelected()
    {
        if (!col) col = GetComponent<CapsuleCollider2D>();
        Vector2 size = new Vector2(col.bounds.size.x * 0.95f, 0.05f);
        Vector2 origin = (Vector2)col.bounds.center + Vector2.down * (col.bounds.extents.y + 0.02f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(origin, size);
    }
}