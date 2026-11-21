using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    public float gravityScale = 1.0f;
    public static float globalGravity = -9.81f;
    public LayerMask groundLayer;
    public float rayDistance = 0.1f;

    Rigidbody m_rb;

    void OnEnable ()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
    }

    void FixedUpdate ()
    {
        if (!IsGrounded())
        {
            Vector3 gravity = globalGravity * gravityScale * Vector3.up;
            m_rb.AddForce(gravity, ForceMode.Acceleration);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayDistance, groundLayer);
    }
}