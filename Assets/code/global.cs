using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.IO;


public class global : MonoBehaviour
{
    private System.Random _random = new System.Random();
    public static float time;
    public static float k;
    public static float a;
    private float timespeed;
    private float onoff;
    public static int act;
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject cube;
    private GameObject obj;
    private GameObject cubeobj;
    data data1;
    private GameObject[ , ] texts;
    private GameObject[] delbut; 

    private GameObject endtime;
    public static int delete;
    private int texttime;
    public static int count;
    public static int scroll;
    public static int soundon;
    public GameObject pref_int;
    public GameObject pic;
    public GameObject pref_float;
    public GameObject but_del;
    public static int create;
    public float aa;
    public float kk;
    public static List<GameObject> cubes = new List<GameObject>();
    public GameObject soundtemp;
    public static float[] virmotorx = new float[40];
    public static float[] virmotory = new float[40];
    public static int phase;
    public static int stage;
    private float[] caly;
    private float[] calx;

    public static float[] blocktestd;
    public static float[] blocktestr;

    public static float[,] calib;
    public static float[,] calibs;
    public static float[,] calibrc;
    public static float[,] calibrs;

    public static int[] calibsdran;

    public static float[] realcalibsd;
    public static float[] realcalibmt;

    public static float[] calibmt;
    public static float[] calibmtc;
    public static float[] calibmtr;
    public static float[] calibmtrc;

    public static int[] calibmtran;

    public static float[] calibsmt;
    public static float[] calibsmtr;

    private StreamWriter sw;
    private StreamReader sr;
    public int numfir;
    public int numsec;
    public int numthi;
    public int numfou;
    public int numfif;
    public int numsix;
    // Start is called before the first frame update
    void Start()
    {
        act = 0;
        numfir = 2;
        numsec = 4;
        numthi = 4;
        numfou = 2;
        numfif = 2;
        numsix = 2;

        soundon = 1;

        blocktestd = new float[32];
        blocktestr = new float[32];

        calib = new float[64, 2];
        calibs = new float[64, 2];

        realcalibsd = new float[16];
        realcalibmt  = new float[16];

        calibmt = new float[64];
        calibmtc = new float[64];

        calibrc = new float[32, 2];
        calibrs = new float[32, 2];

        calibmtrc = new float[32];
        calibmtr = new float[32];

        calibsmt = new float[32];
        calibsmtr = new float[32];

        calibsdran = new int[64];
        calibmtran = new int[64];

        //caly = new float [] {1.22, 1.72, 2.44, 3.45, 4.88, 6.90, 9.75, 13.79};
        caly = new float[] {1.0f, 1.0f, 1.0f, 1.0f};
        calx = new float[] {0, Mathf.PI/8f, Mathf.PI/4f, Mathf.PI*3f/8f, Mathf.PI/2f, Mathf.PI*5f/8f, Mathf.PI*3f/4f, Mathf.PI*7f/8f, Mathf.PI, Mathf.PI*9f/8f, Mathf.PI*5f/4f, Mathf.PI*11f/8f, Mathf.PI*3f/2f, Mathf.PI*13f/8f, Mathf.PI*7f/4f, Mathf.PI*15f/8f};
        
        
        for(int i = 0; i < 64; i++){
            calibsdran[i] = i;
            calibmtran[i] = i;
        }
        for (int i = 0; i < numsec*16; i++){
            int r = _random.Next(0, i+1);
            int tx = calibsdran[r];
            calibsdran[r] = calibsdran[i];
            calibsdran[i] = tx;
        }
        for (int i = 0; i < numthi*16; i++){
            int r = _random.Next(0, i+1);
            int tx = calibmtran[r];
            calibmtran[r] = calibmtran[i];
            calibmtran[i] = tx;
        }


        for(int i = 0; i < numfir; i++){
            for(int j = 0; j < 16; j++){
                blocktestd[i*16+j] = calx[j]+UnityEngine.Random.Range(0f, Mathf.PI/8f);
            }
        }
        for(int i = 0; i < numfir*16; i++){
            blocktestr[i] = UnityEngine.Random.Range(0f, Mathf.PI*2f);
        }
        for (int i = 0; i < numfir; i++){
            for (int j = 15; j > 0; j--){
                int r = _random.Next(i*16, i*16+j+1);
                float tx = blocktestd[r];
                blocktestd[r] = blocktestd[i*16+j];
                blocktestd[i*16+j] = tx;
            }
        }
        
        for(int i = 0; i < numsec; i++){
            for(int j = 0; j < 16; j++){
                calib[i*16+j,0] = calx[j];
                calib[i*16+j,1] = caly[i];
            }
        }
        for (int i = 0; i < numsec; i++){
            for (int j = 15; j > 0; j--){
                int r = _random.Next(i*16, i*16+j+1);
                float tx = calib[r,0];
                float ty = calib[r,1];
                calib[r,0] = calib[i*16+j,0];
                calib[r,1] = calib[i*16+j,1];
                calib[i*16+j,0] = tx;
                calib[i*16+j,1] = ty;
            }
        }
        for(int i = 0; i < numsec*16; i++){
            calibs[i,0] = UnityEngine.Random.Range(0f, Mathf.PI*2f);
            calibs[i,1] = 1.0f;
        }
        for(int i = 0; i < numfou*16; i++){
            calibrc[i,0] = UnityEngine.Random.Range(0f, Mathf.PI*2f);
            calibrc[i,1] = 1.0f;
        }
        for(int i = 0; i < numfou; i++){
            for(int j = 0; j < 16; j++){
                calibrs[i*16+j,0] = calx[j]+UnityEngine.Random.Range(0f, Mathf.PI/8f);
                calibrs[i*16+j,1] = caly[i];
            }
        }
        for (int i = 0; i < numfou; i++){
            for (int j = 15; j > 0; j--){
                int r = _random.Next(i*16, i*16+j+1);
                float tx = calibrs[r,0];
                float ty = calibrs[r,1];
                calibrs[r,0] = calibrs[i*16+j,0];
                calibrs[r,1] = calibrs[i*16+j,1];
                calibrs[i*16+j,0] = tx;
                calibrs[i*16+j,1] = ty;
            }
        }

        calx = new float[] {0f, 0.5f, 1f, 1.5f, 2f, 2.5f, 3f, 3.5f, 4f, 4.5f, 5f, 5.5f, 6f, 6.5f, 7f, 7.5f};

        for(int i = 0; i < numthi; i++){
            for(int j = 0; j < 16; j++){
                calibmt[i*16+j] = calx[j]*Mathf.PI/4f;
            }
        }
        for(int i = 0; i < numthi*16; i++){
            calibmtc[i] = UnityEngine.Random.Range(0f, 8f);
        }
        for (int i = 0; i < numthi; i++){
            for (int j = 15; j > 0; j--){
                int r = _random.Next(i*16, i*16+j+1);
                float tx = calibmt[r];
                calibmt[r] = calibmt[i*16+j];
                calibmt[i*16+j] = tx;
            }
        }

        for(int i = 0; i < numfif; i++){
            for(int j = 0; j < 16; j++){
                calibmtrc[i*16+j] = calx[j] + UnityEngine.Random.Range(0f, 0.5f);
            }
        }
        for(int i = 0; i < numfif*16; i++){
            calibmtr[i] = UnityEngine.Random.Range(0f, Mathf.PI*2f);;
        }
        for (int i = 0; i < numfif; i++){
            for (int j = 15; j > 0; j--){
                int r = _random.Next(i*16, i*16+j+1);
                float tx = calibmtrc[r];
                calibmtrc[r] = calibmtrc[i*16+j];
                calibmtrc[i*16+j] = tx;
            }
        }

        for(int i = 0; i < numsix; i++){
            for(int j = 0; j < 16; j++){
                calibsmtr[i*16+j] = calx[j] + UnityEngine.Random.Range(0f, 0.5f);
            }
        }
        for (int i = 0; i < numsix; i++){
            for (int j = 15; j > 0; j--){
                int r = _random.Next(i*16, i*16+j+1);
                float tx = calibsmtr[r];
                calibsmtr[r] = calibsmtr[i*16+j];
                calibsmtr[i*16+j] = tx;
            }
        }
        for(int i = 0; i < numsix*16; i++){
            calibsmt[i] = UnityEngine.Random.Range(0f, Mathf.PI*2f);;
        }


        phase = 0;
        kk = 1f;
        aa = 1f;
        texts = new GameObject[0,0];
        delbut = new GameObject[0];
        timespeed = 1;
        onoff = 1;
        delete = 0;
        scroll = 0;
        act = 0;
        create = 0;
        count = 0;
        
        for(int j = 0; j < 4; j++){
            for(int k = 0; k < 5; k++){
                virmotorx[j+k*4] = 36.0f+(float)j*36.0f;
                virmotory[j+k*4] = 198.0f+(float)k*36.0f;
            }
        }
        for(int j = 0; j < 4; j++){
            for(int k = 0; k < 5; k++){
                virmotorx[20+j+k*4] = 324.0f-(float)j*36.0f;
                virmotory[20+j+k*4] = 198.0f+(float)k*36.0f;
            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if(texttime > 0){
            texttime -= 1;
        }
        else{
            canvas3.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.F1)){
            phase = (phase + 1)%6;
            stage = 0;
            act = 0;
        }
        if(Input.GetKeyDown(KeyCode.F2)){
            phase = (phase + 5)%6;
            stage = 0;
            act = 0;
        }
        if(Input.GetKeyDown(KeyCode.Q) || OVRInput.GetDown(OVRInput.Button.One)|| OVRInput.GetDown(OVRInput.Button.Two)|| OVRInput.GetDown(OVRInput.Button.Three)|| OVRInput.GetDown(OVRInput.Button.Four)){
            if(phase == 1){
                int k;
                if(act == 0){k = stage;}
                else{k = calibsdran[stage];}

                if(frontback(calib[k,0], calibs[k, 0], Mathf.PI*2f, Mathf.PI/3f)){
                    stage += 1;
                }
                else{
                    canvas3.SetActive(true);
                    texttime = 100;
                }

                if(stage >= 64){
                    stage = 0;
                    act = 1;
                }
            }
            else{
                if(phase == 2){
                    int k;
                    if(act == 0){k = stage;}
                    else{k = calibmtran[stage];}
                    float tempnum;
                    tempnum = calibmt[k]*4f/Mathf.PI;
                    if(frontback(tempnum, calibmtc[k], 8f, 4f/3f)){
                        stage += 1;
                    }
                    else{
                        canvas3.SetActive(true);
                        texttime = 100;
                    }
                    if(stage >= 64){
                        stage = 0;
                        act = 1;
                    }
                }
                else{
                    if(stage < 31){
                        stage += 1;
                    }
                }
            }
            
        }
        if(Input.GetKeyDown(KeyCode.W)){
            stage -= 1;
            if(phase == 1 || phase == 2){
                if(stage < 0){
                    act = 0;
                    stage = 63;
                }
            }
            else{
                if(stage < 0){
                    stage = 0;
                }
            }
            
        }
        if(Input.GetKeyDown(KeyCode.C)){
            calibration();
            Debug.Log("calibrated");
        }

        if(phase == 0){
            if(soundon == 1){
                pic.SetActive(true);
            }
            else{
                pic.SetActive(false);
            }
        }
        else{pic.SetActive(false);}
        


        if(Input.GetKeyDown(KeyCode.S)){
            savedat();
            saveres();
            savecal();
        }

        if(Input.GetKeyDown(KeyCode.L)){
            loaddat();
            loadres();
            loadcal();
        }

        /*a = aa;
        k = kk;
        if(act == 0){
            canvas1.SetActive(true);
            canvas2.SetActive(false);

            time += timespeed*onoff;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetKeyDown(KeyCode.Space)){
                onoff = Mathf.Round(1.0f-onoff);
            }

            if (Input.GetMouseButtonDown(0)){
                if (Physics.Raycast(ray, out hit)){
                    try{Destroy(endtime);}
                    catch{}
                    obj = hit.collider.gameObject;
                    data1 = obj.GetComponent<block>().data1;
                    act = 1;
                    endtime = Instantiate(pref_float, pref_float.transform.position, pref_float.transform.rotation);
                    endtime.GetComponent<input_float_script>().xpos = 0;
                    endtime.GetComponent<input_float_script>().ypos = 200;
                    endtime.GetComponent<input_float_script>().result = data1.endtime;
                    endtime.transform.SetParent(canvas2.transform,false);
                    updatedata();
                }
            }
            if(create == 1){
                cubeobj = Instantiate(cube, cube.transform.position, cube.transform.rotation);
                cubes.Add(cubeobj);
                create = 0;
            }
        }
        else{
            if(delete == 1){
                cubes.Remove(obj);
                Destroy(obj.GetComponent<block>().tempobj);
                Destroy(obj);
                delete = 0;
                act = 0;
            }
            canvas1.SetActive(false);
            canvas2.SetActive(true);
            scroll += (int)(Input.GetAxis("Mouse ScrollWheel")*100);


            for(int i = 0; i < data1.postime.GetLength(0)-1; i++){
                for(int j = 0; j < 4; j++){
                    data1.postime[i, j] = texts[i, j].GetComponent<input_float_script>().result;
                }
            }
            data1.endtime = endtime.GetComponent<input_float_script>().result;


            int deletepos = -1;
            for(int i = 0; i < data1.postime.GetLength(0)-1; i++){
                if(delbut[i].GetComponent<deletetime>().result == 1){
                    deletepos = i;
                }
            }
            if(deletepos >= 0){
                float[,] datas = new float [data1.postime.GetLength(0)-1, 4];
                for(int i = 0; i < deletepos; i++){
                    for(int j = 0; j < 4; j++){
                        datas[i, j] = data1.postime[i, j];
                    }
                }
                for(int i = deletepos; i < data1.postime.GetLength(0)-2; i++){
                    for(int j = 0; j < 4; j++){
                        datas[i, j] = data1.postime[i+1, j];
                    }
                }
                data1.postime = datas;
                updatedata();
            }
            
            
        }
        if (Input.GetKeyDown(KeyCode.Tab)){
            if(act == 1){datatoobj();}
            act = 1-act;

        }*/
        
    }
    void calibration(){
        for(int i = 0; i < 16; i++){
            realcalibsd[i] = 0;
        }
        for(int i = 0; i < numsec*16; i++){
            realcalibsd[(int)Mathf.Round(8*calib[i,0]/Mathf.PI)] += ( calibs[i,0] - (Mathf.Round((calibs[i,0]-calib[i,0])/(Mathf.PI*2f))*Mathf.PI*2f) )/numsec;
        }
        for(int i = 0; i < 16; i++){
            realcalibmt[i] = 0;
        }
        for(int i = 0; i < numthi*16; i++){
            float cubex = 4f*calibmt[i]/Mathf.PI;
            realcalibmt[(int)Mathf.Round(cubex*2f)] += ( calibmtc[i] - (Mathf.Round((calibmtc[i] - cubex)/8f)*8f) )/numthi;
        }
    }

    public static float calsound(float x) {
        x = (x+6*Mathf.PI)%(2f*Mathf.PI);
        float x1 = realcalibsd[((int)Mathf.Floor(x*8f/Mathf.PI))%16];
        float x2 = realcalibsd[((int)Mathf.Floor(x*8f/Mathf.PI) + 1)%16];
        if(x1-x2 > Mathf.PI){x2 += 2f*Mathf.PI;}
        if(x2-x1 > Mathf.PI){x1 += 2f*Mathf.PI;}
        float dir = (x*8f/Mathf.PI)%1f;
        return (x1*(1f-dir) + x2*dir);
    }

    public static float calmotor(float x) {


        
        x = x%(8f);
        float x1 = realcalibmt[((int)Mathf.Floor(x*2f))%16];
        float x2 = realcalibmt[((int)Mathf.Floor(x*2f) + 1)%16];

        if(x1-x2 > 4f){x2 +=  8f;}
        if(x2-x1 > 4f){x1 +=  8f;}
        float dir = (x*2f)%1f;
        return (x1*(1f-dir) + x2*dir);
        
    }


    private void savedat(){
        if (File.Exists("Assets/code/savedat.txt") == true){
            try {
                File.Delete("Assets/code/savedat.txt");
            }
            catch (Exception e) {
                Console.WriteLine("The deletion failed: {0}", e.Message);
            }
        }
        sw = new StreamWriter("Assets/code/savedat.txt");
        for(int i = 0; i < 64; i++){
            sw.WriteLine(calib[i, 0].ToString());
        }
        sw.WriteLine(" ");
        for(int i = 0; i < 64; i++){
            sw.WriteLine(calibs[i, 0].ToString());
        }
        sw.WriteLine(" ");
        for(int i = 0; i < 64; i++){
            sw.WriteLine(calibmt[i].ToString());
        }
        sw.WriteLine(" ");
        for(int i = 0; i < 64; i++){
            sw.WriteLine(calibmtc[i].ToString());
        }
        sw.Flush();
        sw.Close();
        Debug.Log("dat saved");
    }

    private void saveres(){
        if (File.Exists("Assets/code/saveres.txt") == true){
            try {
                File.Delete("Assets/code/saveres.txt");
            }
            catch (Exception e) {
                Console.WriteLine("The deletion failed: {0}", e.Message);
            }
        }
        sw = new StreamWriter("Assets/code/saveres.txt");
            
        for(int i = 0; i < 32; i++){
            sw.WriteLine(blocktestd[i].ToString());
        }
        sw.WriteLine(" ");
        for(int i = 0; i < 32; i++){
            sw.WriteLine(blocktestr[i].ToString());
        }
        sw.WriteLine(" ");

        for(int i = 0; i < 32; i++){
            sw.WriteLine(calibrc[i, 0].ToString()) ;
        }
        sw.WriteLine(" ");
        for(int i = 0; i < 32; i++){
            sw.WriteLine(calsound(calibrc[i, 0]).ToString());
        }
        sw.WriteLine(" ");
        for(int i = 0; i < 32; i++){
            sw.WriteLine(calibrs[i, 0].ToString());
        }
         
        sw.WriteLine(" ");

        for(int i = 0; i < 32; i++){
            sw.WriteLine(calibmtrc[i].ToString()) ;
        }
        sw.WriteLine(" ");
        for(int i = 0; i < 32; i++){
            sw.WriteLine(calmotor(calibmtrc[i]).ToString());
        }
        sw.WriteLine(" ");
        for(int i = 0; i < 32; i++){
            sw.WriteLine(calibmtr[i].ToString());
        }

        sw.WriteLine(" ");
        for(int i = 0; i < 32; i++){
            sw.WriteLine(calibsmtr[i].ToString());
        }
        sw.WriteLine(" ");
        for(int i = 0; i < 32; i++){
            sw.WriteLine(calsound(calibsmtr[i]*Mathf.PI/4f).ToString());
        }
        sw.WriteLine(" ");
        for(int i = 0; i < 32; i++){
            sw.WriteLine(calmotor(calibsmtr[i]).ToString());
        }
        sw.WriteLine(" ");
        for(int i = 0; i < 32; i++){
            sw.WriteLine(calibsmt[i].ToString());
        }
        sw.Flush();
        sw.Close();
        Debug.Log("res saved");
    }

    private void savecal(){
        if (File.Exists("Assets/code/savecal.txt") == true){
            try {
                File.Delete("Assets/code/savecal.txt");
            }
            catch (Exception e) {
                Console.WriteLine("The deletion failed: {0}", e.Message);
            }
        }
        sw = new StreamWriter("Assets/code/savecal.txt");
        for(int i = 0; i < 16; i++){
            sw.WriteLine(realcalibsd[i].ToString());
        }
         
        sw.WriteLine(" ");
        for(int i = 0; i < 16; i++){
            sw.WriteLine(realcalibmt[i].ToString());
        }
        sw.Flush();
        sw.Close();
        Debug.Log("cal saved");
    }

    private void loaddat(){
        if (File.Exists("Assets/code/savedat.txt") == true){
            sr = new StreamReader("Assets/code/savedat.txt");
            for(int i = 0; i < 64; i++){
                calib[i, 0] = float.Parse(sr.ReadLine());
            }
            sr.ReadLine();

            for(int i = 0; i < 64; i++){
                calibs[i, 0] = float.Parse(sr.ReadLine());
            }
            sr.ReadLine();

            for(int i = 0; i < 64; i++){
                calibmt[i] = float.Parse(sr.ReadLine());
            }
            sr.ReadLine();

            for(int i = 0; i < 64; i++){
                calibmtc[i] = float.Parse(sr.ReadLine());
            }
            sr.Close();
            Debug.Log("dat loaded");
        }
        else{
            Debug.Log("fail to load dat");
        }
    }

    private void loadres(){
        if (File.Exists("Assets/code/saveres.txt") == true){
            sr = new StreamReader("Assets/code/saveres.txt");
            for(int i = 0; i < 32; i++){
                blocktestd[i] = float.Parse(sr.ReadLine());
            }
            sr.ReadLine();
            for(int i = 0; i < 32; i++){
                blocktestr[i] = float.Parse(sr.ReadLine());
            }
            sr.ReadLine();
            for(int i = 0; i < 32; i++){
                calibrc[i, 0] = float.Parse(sr.ReadLine());
            }
            sr.ReadLine();
            for(int i = 0; i < 32; i++){
                sr.ReadLine();
            }
            sr.ReadLine();
            for(int i = 0; i < 32; i++){
                calibrs[i, 0] = float.Parse(sr.ReadLine());
            }
            sr.ReadLine();
            for(int i = 0; i < 32; i++){
                calibmtrc[i] = float.Parse(sr.ReadLine());
            }
            sr.ReadLine();
            for(int i = 0; i < 32; i++){
                sr.ReadLine();
            }
            sr.ReadLine();
            for(int i = 0; i < 32; i++){
                calibmtr[i] = float.Parse(sr.ReadLine());
            }
            sr.ReadLine();
            for(int i = 0; i < 32; i++){
                calibsmtr[i] = float.Parse(sr.ReadLine());
            }
            sr.ReadLine();
            for(int i = 0; i < 32; i++){
                sr.ReadLine();
            }
            sr.ReadLine();
            for(int i = 0; i < 32; i++){
                sr.ReadLine();
            }
            sr.ReadLine();
            for(int i = 0; i < 32; i++){
                calibsmt[i] = float.Parse(sr.ReadLine());
            }
            sr.Close();
            Debug.Log("res loaded");
        }
        else{
            Debug.Log("fail to load res");
        }
    }



    private void loadcal(){
        if (File.Exists("Assets/code/savecal.txt") == true){
            sr = new StreamReader("Assets/code/savecal.txt");
            for(int i = 0; i < 16; i++){
                realcalibsd[i] = float.Parse(sr.ReadLine());
            }
         
            sr.ReadLine();
            for(int i = 0; i < 16; i++){
                realcalibmt[i] = float.Parse(sr.ReadLine());
            }

            sr.Close();
            Debug.Log("cal loaded");
        }
        else{
            Debug.Log("fail to load cal");
        }
    }

    void updatedata(){/*
        for(int i = 0; i < texts.GetLength(0); i++){
            for(int j = 0; j < 4; j++){
                try{Destroy(texts[i, j]);}
                catch{}
            }
            try{Destroy(delbut[i]);}
            catch{}
        }
        //sort 추가
        texts = new GameObject[data1.postime.GetLength(0)-1,4];
        delbut = new GameObject[data1.postime.GetLength(0)-1];

        for(int i = 0; i < data1.postime.GetLength(0)-1; i++){
            for(int j = 0; j < 4; j++){
                texts[i, j] = Instantiate(pref_float, pref_float.transform.position, pref_float.transform.rotation);
                texts[i, j].GetComponent<input_float_script>().xpos = -400 + j*220;
                texts[i, j].GetComponent<input_float_script>().ypos = 60 - i*80;
                texts[i, j].GetComponent<input_float_script>().result = data1.postime[i, j];
                texts[i, j].transform.SetParent(canvas2.transform,false);
            }
            delbut[i] = Instantiate(but_del, but_del.transform.position, but_del.transform.rotation);
            delbut[i].GetComponent<deletetime>().xpos = 500;
            delbut[i].GetComponent<deletetime>().ypos = 60 - i*80;
            delbut[i].transform.SetParent(canvas2.transform,false);
        }
        */
    }

    void datatoobj(){/*
//sort 추가
        data1.postime[data1.postime.GetLength(0)-1, 0] = data1.endtime;
        data1.postime[data1.postime.GetLength(0)-1, 1] = data1.postime[0, 1];
        data1.postime[data1.postime.GetLength(0)-1, 2] = data1.postime[0, 2];
        data1.postime[data1.postime.GetLength(0)-1, 3] = data1.postime[0, 3];
        //obj.GetComponent<block>().data1 = data1;
        */
    }

    public void onemore(){/*
        float[,] datas = new float [data1.postime.GetLength(0)+1, 4];
        for(int i = 0; i < data1.postime.GetLength(0)-1; i++){
            for(int j = 0; j < 4; j++){
                datas[i,j] = data1.postime[i,j];
            }
        }
        datas[data1.postime.GetLength(0)-1,0] = 0f;
        datas[data1.postime.GetLength(0)-1,1] = 0f;
        datas[data1.postime.GetLength(0)-1,2] = 0f;
        datas[data1.postime.GetLength(0)-1,3] = 0f;
        data1.postime = datas;
        updatedata();*/
    }
    private bool frontback(float angle1, float angle2, float ranges, float maxerror){
        float tempangle;
        tempangle = angle1 - angle2;
        tempangle -= ranges*Mathf.Round(tempangle/ranges);
        if((tempangle < maxerror ) && (tempangle > -maxerror )){
            return(true);
        }
        else{
            return(false);
        }
    }
}
