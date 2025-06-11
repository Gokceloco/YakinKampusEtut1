using System;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpPower;
    public float fallMultiplier;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.linearVelocity = Vector3.up * jumpPower;
        }

        if (_rb.linearVelocity.y < 0)
        {
            _rb.linearVelocity += Vector3.down * fallMultiplier;
        }
    }
}
