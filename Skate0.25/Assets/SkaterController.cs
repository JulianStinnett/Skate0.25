using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class SkaterController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6.5f;      // constant forward speed
    public float jumpVelocity = 12f;    // how strong the jump is

    [Header("Jump Forgiveness")]
    public float coyoteTime = 0.08f;    // small time window to still jump after leaving ground
    public float jumpBuffer = 0.12f;    // allows jump input slightly before landing

    [Header("Ground Check")]
    public LayerMask groundMask;        // which layers count as ground
    public float groundCheckPad = 0.05f; // extra space below collider for checking ground

    Rigidbody2D rb;
    CapsuleCollider2D col;

    float coyoteTimer = 0f; // timer tracking coyote-time window
    float bufferTimer = -1f; // timer tracking jump-buffer window

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        // Store jump input for a short time (jump buffering)
        if (Input.GetKeyDown(KeyCode.Space))
            bufferTimer = jumpBuffer;

        // Refresh coyote timer if grounded, otherwise count down
        if (IsGrounded()) coyoteTimer = coyoteTime;
        else coyoteTimer -= Time.deltaTime;

        // Try to perform jump if there's a buffered press
        if (bufferTimer > 0f)
        {
            bufferTimer -= Time.deltaTime;

            // Can only jump if still within coyote-time window
            if (coyoteTimer > 0f)
            {
                // clear downward velocity before jumping for a sharper feel
                var v = rb.velocity;
                if (v.y < 0f) v.y = 0f;
                v.y = jumpVelocity;
                rb.velocity = v;

                bufferTimer = -1f; // consume buffered jump
                SimpleAudio.Instance?.PlayJump(); // play jump sound
            }
        }
    }

    void FixedUpdate()
    {
        // Constant forward motion (like an endless runner)
        var v = rb.velocity;
        v.x = moveSpeed;
        rb.velocity = v;
    }

    bool IsGrounded()
    {
        // Small box check just below the collider to detect ground
        Vector2 size = new Vector2(col.bounds.size.x * 0.95f, 0.05f);
        Vector2 origin = (Vector2)col.bounds.center + Vector2.down * (col.bounds.extents.y + 0.02f);
        var hit = Physics2D.OverlapBox(origin, size, 0f, groundMask);
        return hit != null;
    }

    void OnDrawGizmosSelected()
    {
        // Draw the ground check area in the editor for debugging
        if (!col) col = GetComponent<CapsuleCollider2D>();
        Vector2 size = new Vector2(col.bounds.size.x * 0.95f, 0.05f);
        Vector2 origin = (Vector2)col.bounds.center + Vector2.down * (col.bounds.extents.y + 0.02f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(origin, size);
    }
}