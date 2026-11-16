using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rigidbody;

    [SerializeField] private float _moveSpeed;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void UpdateMovement(Vector3 moveDirection)
    {
        _rigidbody.linearVelocity = moveDirection * _moveSpeed;

        if (moveDirection.x != 0)
        {
            _transform.localScale = new Vector3(Mathf.Sign(moveDirection.x), _transform.localScale.y, 1);
        }
    }
}
