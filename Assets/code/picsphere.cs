using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picsphere : MonoBehaviour
{
    private float xx;
    private float yy;
    // Start is called before the first frame update
    void Start()
    {
        xx = 0.35f;
        yy = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(global.phase == 0){
            yy = 0.35f;
            xx = global.blocktestd[global.stage];
        }
        transform.localPosition = new Vector3(yy*Mathf.Sin(xx),0,-yy*Mathf.Cos(xx));
    }
}
