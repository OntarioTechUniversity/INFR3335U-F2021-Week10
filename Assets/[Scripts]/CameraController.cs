using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Look Controls")]
    public float sensitivity = 10.0f;

    [Header("Movement")] 
    public float maxSpeed = 10.0f;
    public Vector3 velocity;

    [Header("OnScreen Controls")] 
    public Joystick leftJoystick;
    public Joystick rightJoystick;

    private float XAxisRotation = 0.0f;
    private float YAxisRotation = 0.0f;

    private Vector2 mouse;

    // Update is called once per frame
    void Update()
    {
        MouseLook();
        Move();
    }

    private void MouseLook()
    {
        // get input from the mouse
        mouse.x = (Input.GetAxis("Mouse X") * sensitivity) + rightJoystick.Horizontal;
        mouse.y = (Input.GetAxis("Mouse Y") * sensitivity) + rightJoystick.Vertical;

        // look up and down
        XAxisRotation -= mouse.y;
        XAxisRotation = Mathf.Clamp(XAxisRotation, -90.0f, 90.0f);

        // look left and right and rotate around the Y Axis
        YAxisRotation += mouse.x;

        // rotate
        transform.localRotation = Quaternion.Euler(XAxisRotation, YAxisRotation, 0.0f);
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") + leftJoystick.Horizontal;
        float y = Input.GetAxisRaw("Vertical") + leftJoystick.Vertical;
        float z = Input.GetAxisRaw("Up");

        Vector3 moveForward =  Vector3.MoveTowards(Vector3.zero, transform.forward * maxSpeed, y * maxSpeed * Time.deltaTime);
        Vector3 moveSideways = Vector3.MoveTowards(Vector3.zero, transform.right * maxSpeed, x * maxSpeed * Time.deltaTime);
        Vector3 moveUp = Vector3.MoveTowards(Vector3.zero, transform.up * maxSpeed, z * maxSpeed * Time.deltaTime);
        transform.position += moveForward + moveSideways + moveUp;
    }
}
