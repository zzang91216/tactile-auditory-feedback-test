using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class cubenum : MonoBehaviour
{
    public Text TextLegacy;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextLegacy.text = (cube.GetComponent<block>().xx - Mathf.PI*2f*Mathf.Floor(cube.GetComponent<block>().xx/(Mathf.PI*2f))).ToString("F3") + ", " + (cube.GetComponent<block>().yy).ToString("F3");
    }
}
