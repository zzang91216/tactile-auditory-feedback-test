using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input_int_script : MonoBehaviour
{
    public int result;
    private InputField input_int0;
    public int ypos;
    public int xpos;
 
    private void Awake()
    {
        ypos = 10;
        xpos = 10;
        input_int0 = GetComponent<InputField>();
    }
 
    private void Update()
    {

        if (input_int0.text.Length > 0 && Input.GetKeyDown(KeyCode.Return))
        {
            result = int.Parse(input_int0.text);
            input_int0.Select();
            input_int0.text = "";
        }
        input_int0.placeholder.GetComponent<Text>().text = result.ToString();
        GetComponent<RectTransform>().anchoredPosition = new Vector2(xpos, global.scroll + ypos);
    }
}
