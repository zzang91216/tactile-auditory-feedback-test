using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class pos : MonoBehaviour
{
    public Text TextLegacy;
    public Camera cam;
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextLegacy.text = (cam.transform.position).ToString();
    }
}
