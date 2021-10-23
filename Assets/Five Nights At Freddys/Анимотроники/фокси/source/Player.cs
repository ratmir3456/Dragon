using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float Ver, Hor, Jump;

    public float Speed = 10, JumpSpeed = 200;

    void Update()
    {
        
Ver = Input.GetAxis("vertical") * Time.deltaTime * Speed; 

    Hor = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        
Jump = Input.GetAxis("Jump") * Time.deltaTime * JumpSpeed;

        GetComponent<Rigidbody>().AddForce(transform.up * Jump, ForceMode.Impulse);
        transform.Translate(new Vector3(Hor, 0, Ver));
    }
    
}
