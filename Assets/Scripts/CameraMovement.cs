using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 2f; 
    public float acceleration = 0.1f; 
    public float maxSpeed = 18f;

    void Update()
    {
        acceleration += 0.01f * Time.deltaTime;

        cameraSpeed += acceleration * Time.deltaTime;
        cameraSpeed = Mathf.Clamp(cameraSpeed, 0, maxSpeed);

        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }
}
