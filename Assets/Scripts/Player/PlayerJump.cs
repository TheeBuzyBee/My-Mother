using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rigidbody;
    
    [SerializeField] private float _jumpForce;
    

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void UpdateJump()
    {
        
    }
}
