using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuberev : MonoBehaviour
{
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, -cube.transform.position.z);
    }
}
