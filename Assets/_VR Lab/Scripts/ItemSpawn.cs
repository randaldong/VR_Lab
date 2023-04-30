using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawn : MonoBehaviour
{
	public GameObject inventoryButton;

	private GameObject item;
	private GameObject spawnAnchor;
	private Vector3 spawnPos;

	private void Awake()
	{
		spawnAnchor = GameObject.Find("anchors/spawnAnchor");
		spawnPos = Vector3.zero;
	}
	public void SpawnItem(GameObject itemPrefab)
	{
		spawnPos = new Vector3(spawnAnchor.transform.position.x, 0.1f, spawnAnchor.transform.position.z);
		item = Instantiate(itemPrefab, spawnPos, Quaternion.identity);

		inventoryButton.GetComponent<Button>().onClick.Invoke();
	}

}
