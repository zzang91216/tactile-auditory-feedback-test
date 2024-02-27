using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class stagenum : MonoBehaviour
{
    public Text TextLegacy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextLegacy.text = (global.stage).ToString() + ", " + (global.phase).ToString();
    }
}
