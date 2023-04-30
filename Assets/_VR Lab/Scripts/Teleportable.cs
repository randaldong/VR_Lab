using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleportable : BaseTeleportationInteractable
{
	[Header("Custom Teleportable Settings")]
	public bool isTeleportArea;
	public bool isTeleportAnchor;
	public GameObject teleportAreaReticle;
	public GameObject teleportAnchorReticle;

	private void Start()
	{
		if (isTeleportArea)
		{
			customReticle = teleportAreaReticle;
		}
		else if (isTeleportAnchor)
		{
			customReticle = teleportAnchorReticle;
		}
	}
	
}
