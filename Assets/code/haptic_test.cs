using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bhaptics.SDK2
{
    public class haptic_test : MonoBehaviour
    {
        private int[] a = new int[40];
        public int per;

        // Start is called before the first frame update
        void Start()
        {
            per = 0;
        }

        // Update is called once per frame
        void Update()
        {
            for(int i = 0; i < 40; i++){
                a[i] = 0;
            }
            a[per] = 100;

            if(Input.GetKeyDown(KeyCode.UpArrow)){
                if(per < 39){
                    per += 1;
                }
            }
            if(Input.GetKeyDown(KeyCode.DownArrow)){
                if(per > 0){
                    per -= 1;
                }
            }

            BhapticsLibrary.PlayMotors(0, a, 66);
        }
    }
}
