using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameratemp : MonoBehaviour
{
    private int angle;
    private int k;
    public GameObject camcenter;
    private Vector3 corrpos;
    private float corrrot;
    float tempx;
    float tempy;
    float tempz;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        k = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        tempx = camcenter.transform.eulerAngles.x-Mathf.Round(camcenter.transform.eulerAngles.x/360f)*360f;
        tempy = camcenter.transform.eulerAngles.y-Mathf.Round(camcenter.transform.eulerAngles.y/360f)*360f;
        tempz = camcenter.transform.eulerAngles.z-Mathf.Round(camcenter.transform.eulerAngles.z/360f)*360f;
        if(tempx < range && tempx > -range && tempy < range*2f && tempy > -range*2f && tempz < range && tempz > -range){
            global.soundon = 1;
        }
        else{
            global.soundon = 0;
        }



        if(Input.GetKeyDown(KeyCode.M)){
            
            corrrot = camcenter.transform.localEulerAngles.y;
            if(k == 0){transform.rotation = Quaternion.Euler(k*270,-corrrot,0);}
        }
        corrpos += camcenter.transform.position - new Vector3(0, k*10, 0);
        transform.position = new Vector3(0, k*10, 0) - corrpos;
        if(k == 1){transform.rotation = Quaternion.Euler(k*270,-corrrot,0);}
    }
}
