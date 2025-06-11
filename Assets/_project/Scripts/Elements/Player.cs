using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    public float pushForce;

    private Vector3 _initialMousePos;
    private Vector3 _currentDragVector;
    public DirectionPreview directionPreview;

    public LayerMask playerLayerMask;
    public LayerMask groundLayerMask;

    public bool didDragStartFromPlayer;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        directionPreview.transform.position = transform.position;
        if (Input.GetMouseButtonDown(0))
        {   
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 100, playerLayerMask))
            {
                _initialMousePos = hit.point;
                didDragStartFromPlayer = true;
                directionPreview.Show();
            }
            else
            {
                didDragStartFromPlayer = false;
            }
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, 100, groundLayerMask))
            {
                _currentDragVector = hit.point - _initialMousePos;
            }
            if (didDragStartFromPlayer)
            {
                directionPreview.SetDirection(_currentDragVector);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (didDragStartFromPlayer)
            {
                var dragForce = Mathf.Clamp(_currentDragVector.magnitude, 2, 7);
                var dragVector = _currentDragVector.normalized;
                dragVector.y = 0;
                AddForce(-dragVector, pushForce * dragForce);
                directionPreview.Hide();
            }
        }
    }

    void AddForce(Vector3 dir, float force)
    {
        _rb.AddForce(dir * force);
    }

    public void RestartPlayer()
    {
        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _rb.position = new Vector3(0,.5f,0);
    }
}
