using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bhaptics.SDK2
{
    
    public class tact : MonoBehaviour
    {
        private Vector3 tempvec;
        public GameObject cam;
        private float xdir;
        private float ydir;
        private float viryest;
        private float virx;
        private float tempfl;
        private int tempr;
        public float power = 1f;
        public float width = 2000f;
        public float height = 2000f;
        private int[] a = new int[40];
        public float wide = 0.5f;
        private float dist;
        private float vtime;
        public float vspeed;
        public float margin;
        // Start is called before the first frame update
        void Start()
        {
            vspeed = 4;
            margin = 0f;
            vtime = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            vtime += 1f*Time.deltaTime;
            for(int i = 0; i < 40; i++){
               a[i] = 0;
            }
            
            for(int i = 0; i < global.cubes.Count; i++){
                tempvec = (cam.transform.position - global.cubes[i].transform.position);
                tempvec = Quaternion.Euler(0, -cam.transform.eulerAngles.y, 0) * tempvec;
                tempvec = Quaternion.Euler(-cam.transform.eulerAngles.x, 0, 0) * tempvec;
                

                xdir = - Mathf.Acos(tempvec.normalized.y)*Mathf.Rad2Deg;
                //xdir = - cam.transform.eulerAngles.x - Mathf.Acos(tempvec.normalized.y)*Mathf.Rad2Deg;
                xdir -= Mathf.Floor(xdir/360.0f)*360.0f;
                ydir = - Mathf.Atan2(tempvec.normalized.z, tempvec.normalized.x)*Mathf.Rad2Deg;
                //ydir = - cam.transform.eulerAngles.y - Mathf.Atan2(tempvec.normalized.z, tempvec.normalized.x)*Mathf.Rad2Deg;
                ydir -= Mathf.Floor(ydir/360.0f)*360.0f;

                for(int j = 0; j < 40; j++){
                        viryest = global.virmotorx[j] - ydir;
                        viryest -= Mathf.Floor((viryest+180.0f)/360.0f)*360.0f;
                }
                //Debug.Log((1f + Mathf.Sin(vtime/(dist+1f))));

            }
            if(Input.GetKey(KeyCode.Q)){
                BhapticsLibrary.PlayMotors(0, a, 10);
            }
        }
        int next(int num){
            if(num<20){
                if(num%4 == 3){
                    return(num+20);
                }
                else{
                    return(num+1);
                }
            }
            else{
                if(num%4 == 0){
                    return(num-20);
                }
                else{
                    return(num-1);
                }
            }
        }
        int down(int num){
            return(num+4);
        }
    }
}
