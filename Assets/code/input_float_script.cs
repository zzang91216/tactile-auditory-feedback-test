using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input_float_script : MonoBehaviour
{
    public float result;
    private InputField input_float0;
    public int ypos;
    public int xpos;
 
    private void Awake()
    {
        ypos = 10;
        xpos = 10;
        input_float0 = GetComponent<InputField>();
    }
 
    private void Update()
    {

        if (input_float0.text.Length > 0 && Input.GetKeyDown(KeyCode.Return))
        {
            result = float.Parse(input_float0.text);
            input_float0.Select();
            input_float0.text = "";
        }
        input_float0.placeholder.GetComponent<Text>().text = result.ToString();
        GetComponent<RectTransform>().anchoredPosition = new Vector2(xpos, global.scroll + ypos);
    }
}
