using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResetButtonSC : MonoBehaviour
{
    private GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        Debug.Log("PassBottonOnclick()");
        MainCamera.GetComponent<CameraMover>().ResetCameraTransform();
    }
}
