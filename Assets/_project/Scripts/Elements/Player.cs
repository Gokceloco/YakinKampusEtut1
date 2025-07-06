using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    private Rigidbody _rb;
    public float pushForce;

    private Vector3 _initialMousePos;
    private Vector3 _currentDragVector;
    public DirectionPreview directionPreview;

    public LayerMask playerLayerMask;
    public LayerMask groundLayerMask;

    public bool didDragStartFromPlayer;

    public List<Collectable> collectedObjects;

    public bool isMoving;
    public bool startChechingForBallVelocity;
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
                gameDirector.scoreManager.DragReleased();
                isMoving = true;
                Invoke(nameof(StartCheckingForBallVelocity), 1f);
            }
        }

        var pos = transform.position;
        pos.y = .51f;
        transform.position = pos;

        if (startChechingForBallVelocity && isMoving && _rb.linearVelocity.magnitude <= 0.5f)
        {
            _rb.linearVelocity = Vector3.zero;
            isMoving = false;
            startChechingForBallVelocity = false;
            if (collectedObjects.Count == gameDirector.collectableManager.shuffledCollectables.Count)
            {
                print("In Level Completed");
                gameDirector.LevelCompleted();
                return;
            }
            if (gameDirector.scoreManager.remainingAttemps == 0)
            {
                print("In Level Failed");
                gameDirector.LevelFailed();
            }
        }
    }

    void StartCheckingForBallVelocity()
    {
        startChechingForBallVelocity = true;
    }

    void AddForce(Vector3 dir, float force)
    {
        _rb.AddForce(dir * force);
    }

    public void RestartPlayer()
    {
        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _rb.position = new Vector3(0,.625f,0);
        transform.position = new Vector3(0, .625f, 0);
        collectedObjects.Clear();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Collectable") 
            && gameDirector.collectableManager.shuffledCollectables[collectedObjects.Count] == other.gameObject.GetComponentInParent<Collectable>())
        {
            gameDirector.scoreManager.UpdateScore(10, other.transform.position);
            gameDirector.topUI.ObjectCollected(collectedObjects.Count);
            collectedObjects.Add(other.gameObject.GetComponentInParent<Collectable>());
            other.gameObject.SetActive(false);
            
        }
        else if (other.gameObject.CompareTag("Collectable"))
        {
            gameDirector.scoreManager.UpdateScore(-5, other.transform.position);
        }
    }
}
