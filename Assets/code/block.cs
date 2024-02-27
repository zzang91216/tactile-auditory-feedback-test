using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct data{
    public float[ , ] postime;
    public float endtime;
}


public class block : MonoBehaviour
{

    public float xx;
    public float yy;
    private float rot;
    public GameObject soundtemporary;
    public GameObject tempobj;
    private int count = 4;
    private int[] xpos = new int[] { 1, 2, 3, 4 };
    private int[] zpos = new int[] { 1, 2, 3, 4 };
    void Start(){
        xx = transform.position.x;
        yy = transform.position.z;
        rot = 0;
        //tempobj = Instantiate(soundtemporary, soundtemporary.transform.position, soundtemporary.transform.rotation);
        //tempobj.GetComponent<soundtemp>().block = gameObject;
    }
    void Update(){
        rot += Time.deltaTime*720f;
        if(global.phase == 3){
            /*if(Input.GetKey(KeyCode.UpArrow)){
                global.calibrc[global.stage, 1] += Time.deltaTime*3f;
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                global.calibrc[global.stage, 1] -= Time.deltaTime*3f;
            }*/
            if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x > 0){
                global.calibrc[global.stage, 0] += Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x < 0){
                global.calibrc[global.stage, 0] -= Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > 0){
                global.calibrc[global.stage, 0] += Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < 0){
                global.calibrc[global.stage, 0] -= Time.deltaTime*1.5f;
            }

            if(Input.GetKey(KeyCode.LeftArrow)){
                global.calibrc[global.stage, 0] -= Time.deltaTime*1.5f;
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                global.calibrc[global.stage, 0] += Time.deltaTime*1.5f;
            }
            yy = global.calibrc[global.stage, 1];
            xx = global.calibrc[global.stage, 0];
        }
        if(global.phase == 1){
            if(global.act == 0){
                yy = global.calib[global.stage,1];
                xx = global.calib[global.stage,0];
            }
            else{
                yy = global.calib[global.stage,1];
                xx = global.calib[global.calibsdran[global.stage],0];
            }
        }
        if(global.phase == 2){
            yy = 1f;
            if(global.act == 0){
                xx = global.calibmt[global.stage];
            }
            else{
                xx = global.calibmt[global.calibmtran[global.stage]];
            }
        }
        if(global.phase == 4){

            if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x > 0){
                global.calibmtr[global.stage] += Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x < 0){
                global.calibmtr[global.stage] -= Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > 0){
                global.calibmtr[global.stage] += Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < 0){
                global.calibmtr[global.stage] -= Time.deltaTime*1.5f;
            }

            if(Input.GetKey(KeyCode.LeftArrow)){
                global.calibmtr[global.stage] -= Time.deltaTime*1.5f;
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                global.calibmtr[global.stage] += Time.deltaTime*1.5f;
            }
            yy = 1f;
            xx = global.calibmtr[global.stage];
        }

        if(global.phase == 5){

            if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x > 0){
                global.calibsmt[global.stage] += Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x < 0){
                global.calibsmt[global.stage] -= Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > 0){
                global.calibsmt[global.stage] += Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < 0){
                global.calibsmt[global.stage] -= Time.deltaTime*1.5f;
            }

            if(Input.GetKey(KeyCode.LeftArrow)){
                global.calibsmt[global.stage] -= Time.deltaTime*1.5f;
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                global.calibsmt[global.stage] += Time.deltaTime*1.5f;
            }
            yy = 1f;
            xx = global.calibsmt[global.stage];
        }

        if(global.phase == 0){

            if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x > 0){
                global.blocktestr[global.stage] += Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x < 0){
                global.blocktestr[global.stage] -= Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > 0){
                global.blocktestr[global.stage] += Time.deltaTime*1.5f;
            }
            if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < 0){
                global.blocktestr[global.stage] -= Time.deltaTime*1.5f;
            }

            if(Input.GetKey(KeyCode.LeftArrow)){
                global.blocktestr[global.stage] -= Time.deltaTime*1.5f;
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                global.blocktestr[global.stage] += Time.deltaTime*1.5f;
            }
            yy = 1f;
            xx = global.blocktestr[global.stage];
        }
        transform.position = new Vector3(yy*Mathf.Sin(xx),0,yy*Mathf.Cos(xx));
        transform.rotation = Quaternion.Euler(rot*0.72f, xx*180f/Mathf.PI + rot,0);
    }

}
