using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input_time : MonoBehaviour
{
    public float result;
    private InputField input_float0;
 
    private void Awake()
    {
        input_float0 = GetComponent<InputField>();
    }
 
    private void Update()
    {

        if (input_float0.text.Length > 0 && Input.GetKeyDown(KeyCode.Return))
        {
            result = float.Parse(input_float0.text);
            global.time = result;
            input_float0.Select();
            input_float0.text = "";
        }
        GetComponent<InputField>().placeholder.GetComponent<Text>().text = global.time.ToString();
    }
}
