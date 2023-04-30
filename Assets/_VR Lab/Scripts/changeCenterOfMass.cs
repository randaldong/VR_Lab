using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCenterOfMass : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public Transform _centerOfMass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.centerOfMass = _centerOfMass.localPosition;
    }
}
