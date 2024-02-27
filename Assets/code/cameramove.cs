using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public float mousespeed;
    private float mousex;
    private float mousey;
    // Start is called before the first frame update
    void Start()
    {
        mousespeed = 3;
        mousex = 0;
        mousey = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)){
            mousex += Input.GetAxis("Mouse X") * mousespeed;
            mousey += Input.GetAxis("Mouse Y") * mousespeed;
            mousey = Mathf.Clamp(mousey,-80f, 80f);
            transform.localEulerAngles = new Vector3(-mousey, mousex, 0);
        }
        if(Input.GetKey(KeyCode.W)){
            gameObject.transform.Translate(0f, 0f,0.05f);
        }
        if(Input.GetKey(KeyCode.A)){
            gameObject.transform.Translate(-0.05f, 0f,0f);
        }
        if(Input.GetKey(KeyCode.D)){
            gameObject.transform.Translate(0.05f, 0f,0f);
        }
        if(Input.GetKey(KeyCode.S)){
            gameObject.transform.Translate(0f, 0f, -0.05f);
        }
    }
}
