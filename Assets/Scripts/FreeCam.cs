using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public float speed = 10f; // the speed of the camera movement
    public float sensitivity = 2f; // the sensitivity of the mouse look
    public bool ignoreCollisions = true; // whether to ignore collisions or not

    private float yaw = 0f;
    private float pitch = 0f;

    private void Update()
    {
        // move the camera based on keyboard input
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float up = Input.GetKey(KeyCode.Space) ? speed * Time.deltaTime : 0f;
        float down = Input.GetKey(KeyCode.LeftShift) ? -speed * Time.deltaTime : 0f;

        transform.Translate(horizontal, up + down, vertical);

        // rotate the camera based on mouse input
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        // ignore collisions if enabled
        if (ignoreCollisions)
        {
            Physics.IgnoreLayerCollision(0, 8, true); // ignore collisions between layer 0 (default) and layer 8 (custom)
        }
    }
}

