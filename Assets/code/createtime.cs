using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createtime : MonoBehaviour
{
    public GameObject globalobj;
    public void createtimeline(){
        globalobj.GetComponent<global>().onemore();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
