using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletetime : MonoBehaviour
{
    public int result;
    public int xpos;
    public int ypos;
    public void delete(){
        result = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        result = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(xpos, global.scroll + ypos);
    }
}
