using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMode : MonoBehaviour
{
	[SerializeField] private GameObject leftHandController;
	[SerializeField] private GameObject xRCamera;
	private GameObject switch2gaze;
	private GameObject switch2hand;
	private GameObject gazeReticle;
	public void SwitchText()
    {
		switch2gaze.SetActive(!switch2gaze.activeSelf);
		switch2hand.SetActive(!switch2hand.activeSelf);
	}

    public void Switch()
    {
		leftHandController.GetComponent<myRayInteractor>().enabled = !(leftHandController.GetComponent<myRayInteractor>().enabled);
		xRCamera.GetComponent<GazeInteractor>().enabled = !(xRCamera.GetComponent<GazeInteractor>().enabled);
		gazeReticle.SetActive(!gazeReticle.activeSelf);
	}

	private void Start()
	{
		gazeReticle = xRCamera.transform.Find("GazeReticle").gameObject;
		switch2gaze = transform.Find("Switch2Gaze").gameObject;
		switch2hand = transform.Find("Switch2Hand").gameObject;

		gameObject.GetComponent<Button>().onClick.AddListener(SwitchText);
		gameObject.GetComponent<Button>().onClick.AddListener(Switch);

	}
}
