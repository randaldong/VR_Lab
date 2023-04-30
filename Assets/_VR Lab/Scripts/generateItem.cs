using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generateItem : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject toSpawn;
    [SerializeField] private GameObject anchor;
    private Vector3 anchorSpawn;
    void spawnItem()
    {
        
        Instantiate(toSpawn, anchorSpawn, Quaternion.identity);
    }

    private void Start()
    {
        anchor = GameObject.Find("anchors/spawnAnchor");
        button.onClick.AddListener(spawnItem);
    }

    private void Update()
    {
        anchorSpawn = new Vector3(anchor.transform.position.x, 0.1f, anchor.transform.position.z);
    }

}
