using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class soundnum : MonoBehaviour
{
    public Text TextLegacy;
    public GameObject soundtemp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextLegacy.text = (soundtemp.GetComponent<soundtemp>().kxx - Mathf.PI*2f*Mathf.Floor(soundtemp.GetComponent<soundtemp>().kxx/(Mathf.PI*2f))).ToString("F3") + ", " + (soundtemp.GetComponent<soundtemp>().kzz).ToString("F3");
    }
}
