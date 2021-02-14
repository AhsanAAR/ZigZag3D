using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class diamondControl : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(100, 100, 100) * Time.deltaTime);
    }
}
