using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    float xRotation = 0f;
    float xSensitivity = 30;
    float ySensitivity = 30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void ProcessLook(Vector2 input)
    {
        xRotation -= input.y * Time.deltaTime * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * input.x * Time.deltaTime * xSensitivity);
    }
}
