using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject cam;

    Quaternion StartingRotation;

    float Ver, Hor, Jump, RotHor, RotVer;

    bool isGround;

    public float Speed = 10, senssensitivity = 5;

    void Start()
    {
        StartingRotation = transform.rotation;
        Cursor.visible = false;
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }


    void FixedUpdate()
    {
        RotHor += Input.GetAxis("Mouse X") * senssensitivity;
        RotVer += Input.GetAxis("Mouse Y") * senssensitivity;

        RotVer = Mathf.Clamp(RotVer, -60, 60);

        Quaternion RotY = Quaternion.AngleAxis(RotHor, Vector3.up);
        Quaternion RotX = Quaternion.AngleAxis(-RotVer, Vector3.right);

        cam.transform.rotation = StartingRotation * transform.rotation * RotX;
        transform.rotation = StartingRotation * RotY;

        if (isGround)
        {
            Ver = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
            Hor = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            

            

        }
        transform.Translate(new Vector3(Hor, 0, Ver));
    }

}
