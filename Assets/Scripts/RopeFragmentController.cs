using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeFragmentController : MonoBehaviour
{
    Color parentRopeColor;
    // Start is called before the first frame update
    void Start()
    {
        parentRopeColor = transform.parent.parent.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Freeze the rope if it connects with the same colored connectionPoint
        if(collision.transform.gameObject.name == "ConnectionPoint" && collision.transform.gameObject.GetComponent<Renderer>().material.color == parentRopeColor)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Rope fragment hit connection point");
        }
    }
}
