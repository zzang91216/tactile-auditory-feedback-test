using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bhaptics.SDK2
{
    public class tacttest : MonoBehaviour
    {
        private int[] a = new int[40];
        private int k;
        private float b;
        public int per;
        public float xx;
        private float temp;

        // Start is called before the first frame update
        void Start()
        {
            k = 0;
            xx = 0;
            per = 50;
            b = 50.0f;
        }

        // Update is called once per frame
        void Update()
        {
            for(int i = 0; i < 40; i++){
                a[i] = 0;
            }
            if(global.phase == 4){
                xx = global.calmotor(global.calibmtrc[global.stage]);
            }
            if(global.phase == 2){
                int k;
                if(global.act == 0){k = global.stage;}
                else{k = global.calibmtran[global.stage];}

                

                if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x > 0){
                    global.calibmtc[k] += Time.deltaTime*6f/Mathf.PI;
                }
                if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x < 0){
                    global.calibmtc[k] -= Time.deltaTime*6f/Mathf.PI;
                }
                if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > 0){
                    global.calibmtc[k] += Time.deltaTime*6f/Mathf.PI;
                }
                if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < 0){
                    global.calibmtc[k] -= Time.deltaTime*6f/Mathf.PI;
                }

                if(Input.GetKey(KeyCode.LeftArrow)){
                    global.calibmtc[k] -= Time.deltaTime*6f/Mathf.PI;
                }
                if(Input.GetKey(KeyCode.RightArrow)){
                    global.calibmtc[k] += Time.deltaTime*6f/Mathf.PI;
                }

                global.calibmtc[k] = (global.calibmtc[k]+8f)%8f;

                xx = global.calibmtc[k];
            }
            if(global.phase == 5){
                xx = global.calmotor(global.calibsmtr[global.stage]);
            }
            xx = (xx + 1.5f)%8f;
            if(xx >= 0 && xx < 3){
                a[8+Mathf.FloorToInt(xx)] = 100 - Mathf.RoundToInt(100f*(xx%1f));
                a[9+Mathf.FloorToInt(xx)] = 100 - a[8+Mathf.FloorToInt(xx)];
            }
            if(xx >= 3 && xx < 4){
                a[11] = 100 - Mathf.RoundToInt(100f*(xx%1f));
                a[31] = 100 - a[11];
            }
            if(xx >= 4 && xx < 7){
                a[35-Mathf.FloorToInt(xx)] = 100 - Mathf.RoundToInt(100f*(xx%1f));
                a[34-Mathf.FloorToInt(xx)] = 100 - a[35-Mathf.FloorToInt(xx)];
            }
            if(xx >= 7 && xx < 8){
                a[28] = 100 - Mathf.RoundToInt(100f*(xx%1f));
                a[8] = 100 - a[28];
            }
            if((global.phase == 2 || global.phase == 4 || global.phase == 5) && global.soundon == 1){
                BhapticsLibrary.PlayMotors(0, a, 66);
            }
        }
    }
}
