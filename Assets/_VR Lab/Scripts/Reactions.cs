using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reactions : MonoBehaviour
{
    [Header("Change Material")]
    public Material changeToMaterial;

    [Header("Inventory Button Reaction")]
    public GameObject inventoryButton;
	public Sprite buttonDownImage;
	public Sprite buttonUpImage;
    public GameObject inventory;

	public void ChangeMaterial()
    {
        gameObject.GetComponent<Renderer>().material = changeToMaterial;
    }

    public void InventoryButtonReaction()
    {
        inventory.SetActive(!inventory.activeSelf);
        ChangeImage();
    }
	public void ChangeImage()
    {
        if (inventory.activeSelf)
        {
			inventoryButton.GetComponent<Image>().sprite = buttonDownImage;
		}
        else
        {
			inventoryButton.GetComponent<Image>().sprite = buttonUpImage;
		}
	}


}
