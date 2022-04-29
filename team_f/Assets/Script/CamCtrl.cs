using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    private Camera cam;
    private Vector3 startPos;
    private Vector3 startAngle;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam == null)
        {
            return;
        }

        float sensitiveMove = 0.8f;
        float sensitiveRotate = 5.0f;
        float sensitiveZoom = 10.0f;

        if (Input.GetMouseButton(0))
        {
            // move camera
            float moveX = Input.GetAxis("Mouse X") * sensitiveMove;
            float moveY = Input.GetAxis("Mouse Y") * sensitiveMove;
            cam.transform.localPosition -= new Vector3(moveX, moveY, 0.0f);
        }
        else if (Input.GetMouseButton(1))
        {
            // rotate camera
            float rotateX = Input.GetAxis("Mouse X") * sensitiveRotate;
            float rotateY = Input.GetAxis("Mouse Y") * sensitiveRotate;
            cam.transform.Rotate(rotateY, rotateX, 0.0f);
        }

        // zoom camera
        float moveZ = Input.GetAxis("Mouse ScrollWheel") * sensitiveZoom;
        cam.transform.position += cam.transform.forward * moveZ;
    }
}
