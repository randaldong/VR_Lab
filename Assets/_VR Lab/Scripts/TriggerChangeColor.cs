using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangeColor : MonoBehaviour
{
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        // Give a upward force to the sphere at the start
        Debug.Log(mask);
        //GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Change its own color to red
        //if(other.gameObject.layer == mask)

        if(other.gameObject.layer == 7)
        {
            other.GetComponent<Renderer>().material.color = Color.red;
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        // Change its own color to white after 3 second
        StartCoroutine(ResetColor(other));
    }

    private IEnumerator ResetColor(Collider other)
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(2);
       other. GetComponent<Renderer>().material.color = Color.white;
    }
}
