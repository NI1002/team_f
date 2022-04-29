using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOnOffParts : MonoBehaviour
{

    public bool control; //操作可能パーツかどうかを示す


    void Update()
    {
        if(control) Move();
    }



    void Move()
    {
        if (Input.GetButtonDown("MoveX"))
        {
            transform.Translate(Input.GetAxisRaw("MoveX"), 0, 0);
        }
        if (Input.GetButtonDown("MoveY"))
        {
            Debug.Log("MoveYが起動");
            transform.Translate(0, Input.GetAxisRaw("MoveY"), 0);
        }
        if (Input.GetButtonDown("MoveZ"))
        {
            transform.Translate(0, 0, Input.GetAxisRaw("MoveZ"));
        }

    }

    public void ChangeControl(bool controlFlag)
    {
        control = controlFlag;
    } 

}
