using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Player player;
    public Transform followObject;
    public float rotateSpeed;
    public bool isFollowing;
    public bool isRotating;

    private void FixedUpdate()
    {
        if (isFollowing)
        {
            transform.position = followObject.position;
        }
    }

    private void Update()
    {
        if (isRotating && !player.didDragStartFromPlayer)
        {
            if (Input.GetMouseButton(0))
            {
                var xRotation = Input.GetAxis("Mouse X");
                transform.Rotate(0, rotateSpeed * Time.deltaTime * xRotation, 0);
            }
        }
    }
}
