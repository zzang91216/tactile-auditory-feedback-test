using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class soundtemp : MonoBehaviour
{
    System.Random rand = new System.Random();
    private float times = 0;
    public float frequency;
    private float realfrequency;
    private float noise = 0;
    public float tri = 0;
    private int sampleRate = 48000;
    private GameObject maincamera;
    public GameObject block;
    private Vector3 posc;
    private Vector3 posp;
    private Vector3 posm;
    private float tempvar;
    const int num = 20;

    private float stop;
    private float ttime;
    private float vtime;
    private float dist;
    private float pastdist;
    private float diff;
    private float[] randd;
    public float amppower;
    public float ampspeed;
    public float mspeed;
    public float mpower;
    public float kxx;
    public float kzz;
    public float bound;
    float mp1;
    float mp2;
    private int pulse;
    public AudioClip frontsound;
    public AudioClip backsound;
    public AudioClip ahsound;
    private bool issound;
    public AudioSource audioSource;

    float mmm;
    float ttt;
    public int mxx;

    float diff2;
    private float mm1;
    private float mm2;
    float soundfunc(float num){
        if(num > bound){
            return(0);
        }
        else{
            return(1.0f-num/bound);
        }
    }
    float GetSinWave(float index, float frequency, int sampleRate, float diff) {
        return Mathf.Sin(diff*2 * Mathf.PI * (index / (float) sampleRate) * frequency);
    }
    float GetTriWave(float index, float frequency, int sampleRate) {
        return 2*((index * frequency / (float) sampleRate)%1);
    }
    float GetRandWave() {
        float s = (float)rand.NextDouble() * 2.0f - 1.0f;
        float v = (float)rand.NextDouble() * 2.0f - 1.0f;
        //return(2.0f * UnityEngine.Random.value - 1.0f);
        return (v * Mathf.Sqrt(-2.0f * Mathf.Log((v * v + s * s)) / (v * v + s * s)));
    }

    float pptan(float num, float mp, float rate){
        return(1-Mathf.Abs(Mathf.Atan((num-mp)/rate)/(Mathf.PI/2)));
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        pulse = 0;
        bound = 0.5f;
        mm1 = UnityEngine.Random.Range(0.0f, 6.28f);
        mm2 = UnityEngine.Random.Range(0.0f, 6.28f);
        vtime = 0f;
        noise = 0.1f;
        //diff2 = UnityEngine.Random.Range(0.9f, 1.1f);
        diff2 = 1f;
        realfrequency = frequency;
        randd = new float[num];
        amppower = 0.5f;
        ampspeed = 0.5f;
        mspeed = 1f;
        mpower = 1000f;
        diff = 0;
        dist = 0;
        ttime = 0;
        stop = 1;
        kxx = transform.position.x;
        kzz = transform.position.z;
        frequency = 400f;
        maincamera = GameObject.Find("OVRCameraRig");
        mxx = 24000;
        audioSource.mute = false;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        issound = false;
        audioSource.clip = frontsound;
    }
    
    // Update is called once per frame
    void Update()
    {
        vtime += 1f*Time.deltaTime;
        pastdist = dist;
        posc = maincamera.transform.position;
        posp = block.transform.position;
        posm = posp-posc;
        tempvar = global.k * Mathf.Pow(Vector3.Distance(posc, posp),global.a-1);
        //mp1 = UnityEngine.Random.Range(0.0f, 1000.0f);
        //mp2 = UnityEngine.Random.Range(1000.0f, 2000.0f);
        mp1 = 1000f+mpower*Mathf.Sin(mspeed*(vtime+mm1));
        mp2 = 1000f+mpower*Mathf.Sin(mspeed*(vtime+mm2));
        for(int i = 0; i < num; i++){
            randd[i] = pptan(frequency*(i+1), mp1, 200)+pptan(frequency*(i+1), mp2, 200);
        }
        diff = Mathf.Atan2(transform.position.x - maincamera.transform.position.x, transform.position.z - maincamera.transform.position.z) - Mathf.Atan2(maincamera.transform.rotation.w,maincamera.transform.rotation.y) ;
        diff -= Mathf.Floor(diff/(Mathf.PI*2f))*2f*Mathf.PI;
        //frequency = (2000f+(diff+(float)Math.PI)*100f)/(Mathf.Sqrt(Mathf.Sqrt(Vector3.Distance(posc, posp)))+2.0f);
        
        dist = Mathf.Sqrt(Mathf.Sqrt(Vector3.Distance(posc, posp)))*4800;
        
        //Debug.Log(mxx);
        //tri = Math.Abs((float)Math.PI - diff)/(Mathf.PI)*0f;
        tri = 0;
        
        //mmm = global.soundon;
        //Debug.Log(diff);
        realfrequency = frequency;
        if(global.phase == 1){
            /*
            if(Input.GetKey(KeyCode.UpArrow)){
                global.calibs[global.stage, 1] += Time.deltaTime*1f;
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                global.calibs[global.stage, 1] -= Time.deltaTime*1f;
            }*/
            int k;
            if(global.act == 0){k = global.stage;}
            else{k = global.calibsdran[global.stage];}

            if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x > 0){
                global.calibs[k, 0] += Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x < 0){
                global.calibs[k, 0] -= Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > 0){
                global.calibs[k, 0] += Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < 0){
                global.calibs[k, 0] -= Time.deltaTime*1.5f;
            }

            if(Input.GetKey(KeyCode.LeftArrow)){
                global.calibs[k, 0] -= Time.deltaTime*1.5f;
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                global.calibs[k, 0] += Time.deltaTime*1.5f;
            }
            kxx = global.calibs[k, 0];
            kzz = global.calibs[k, 1];
            mmm = 1;
        }
        if(global.phase == 3){
            kxx = global.calsound(global.calibrs[global.stage, 0]);
            kzz = global.calibrs[global.stage, 1];
            mmm = 1;
        }
        if(global.phase == 5){
            kxx = global.calsound(Mathf.PI*global.calibsmtr[global.stage]/4f);
            kzz = 1f;
            mmm = 1;
        }
        if(global.phase%2 == 0){
            mmm = 0f;
            if(audioSource.isPlaying){
                audioSource.Stop();
            }
        }
        if(Input.GetKey(KeyCode.J)){
            issound = false;
            audioSource.clip = frontsound;
        }
        if(Input.GetKey(KeyCode.H)){
            issound = true;
            audioSource.clip = null;
        }
        if(issound == false){
            if(mmm != 0){
                if(vtime > amppower){
                    vtime -= amppower;
                    audioSource.Play();
                }
                if(global.soundon == 0){
                    audioSource.Stop();
                }
            }
            else{
                if(audioSource.isPlaying){
                    audioSource.Stop();
                }
            }
        }

        else{
            if(mmm != 0){
                if(!audioSource.isPlaying){
                    audioSource.Play();
                }
            }
            else{
                if(audioSource.isPlaying){
                    audioSource.Stop();
                }
            }
        }
        //transform.position = new Vector3(posc.x+posm.x*tempvar,posc.y+posm.y*tempvar,posc.y+posm.y*tempvar);
        transform.position = new Vector3(kzz*Mathf.Sin(kxx),0,kzz*Mathf.Cos(kxx));
        
    }

    private void OnAudioFilterRead(float[] data, int channels) {
      // looping through each sample group
      if(issound == true){
          for (int i = 0; i < data.Length; i += channels) {
            // looping through sample of each channel in sample group
            if(times > mxx){
                times = 0;
                //pulse = (pulse+1)%5;
            }
            if(global.phase<=1){
                mmm = soundfunc(times/mxx);
            }
            for (int j = 0; j < channels; j++) {
              //data[i + j] = stop*(GetTriWave(times, frequency, sampleRate)*(1-noise)*tri + GetSinWave(times, frequency, sampleRate, diff)*(1-noise)*(1-tri));
              data[i + j] =  GetSinWave(times, realfrequency*1f, sampleRate, diff2)*mmm*global.soundon/2f + GetSinWave(times, realfrequency*12f, sampleRate, diff2)*mmm*global.soundon/2f;
              //for(int k = 0; k < num; k++){
              //  data[i + j] += GetSinWave(times+k*21, frequency*(1+k), sampleRate, diff2)*randd[k]*0.1f;
              //}
              //data[i + j] += GetRandWave()*noise;
            }

            times++; // increase sample count in each call

            //ttime++;
            //if(pastdist > dist){
                //if(ttime > dist){
                //    ttime -= dist;
                //}
                //if(ttime > dist/2){
                //    stop = 0;
                //}
                //else{
                //    stop = 1;
                //}
            //}
            //else{stop = 0;}
            // resetting wave every 5 sec to avoid overflow in float
          }
        }
    }
}
