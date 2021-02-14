using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformFall : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            Invoke("fall",0.3f);
        }
    }

    void fall()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 3);
        platformSpawner.instance.spawnRandom();
    }
}
