using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChange : MonoBehaviour
{
    public GameObject prevSelectedItem;

    public void ChangeSelectedItem(GameObject currItem)
    {
		currItem.transform.Find("Spawn").gameObject.SetActive(true);

		if (prevSelectedItem != null && prevSelectedItem != currItem)
        {
			prevSelectedItem.transform.Find("Spawn").gameObject.SetActive(false);
		}

		prevSelectedItem = currItem;
	}
}
