using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateReticle : MonoBehaviour
{
    void Update()
    {
        transform.Find("Directional Teleport Reticle").forward = Vector3.Cross(Camera.main.transform.right, Vector3.up);

	}
}
