using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportManager : MonoBehaviour
{
    public InputActionAsset inputAction;
    public XRRayInteractor rayInteractor;
    public TeleportationProvider provider;
    public GameObject player;

    private InputAction _thumbstick;
    private InputAction _teleportActivate;
    private InputAction _teleportCancel;
    static private bool _isTeleportActive;

    void Start()
    {
        // uneable at first, enable only when teleport is activated
        rayInteractor.enabled = false;

        // find action map of the controller for both teleport mode activate and cancel;
        // and then enable it and subscribe itself to OnTeleportActivate/Cancel functions
        _teleportActivate = inputAction.FindActionMap("XRI RightHand Locomotion").FindAction("Teleport Mode Activate");
        _teleportActivate.Enable();
        _teleportActivate.performed += OnTeleportActivate;

		_teleportCancel = inputAction.FindActionMap("XRI RightHand Locomotion").FindAction("Teleport Mode Cancel");
		_teleportCancel.Enable();
		_teleportCancel.performed += OnTeleportCancel;

		// grab the input action reference for thumbstick
		_thumbstick = inputAction.FindActionMap("XRI RightHand Locomotion").FindAction("Move");
        _thumbstick.Enable();

	}

	// unsubscribe functions from the events
	private void OnDestroy()
	{
        _teleportActivate.performed -= OnTeleportActivate;
        _teleportCancel.performed -= OnTeleportCancel;
	}
	

	void Update()
    {
        if (!_isTeleportActive) return; // thumbstick not pushed, teleport inactivated

        if (_thumbstick.triggered) return; // thumbstick pushed but not released yet

		// now the thumbstick has been released, meaning the player is ready to be teleported
		if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hitInfo)) // but hit nothing
        {
            rayInteractor.enabled = false;
            _isTeleportActive = false;
            return;
        }

		// when the ray does hit something
		player.transform.position = hitInfo.point;
        
        if (hitInfo.transform.gameObject.GetComponent<Teleportable>().isTeleportAnchor)
        {
			player.transform.forward = hitInfo.transform.forward;
		}

		rayInteractor.enabled = false;
        _isTeleportActive = false;
    }

    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        if (!_isTeleportActive)
        {
            rayInteractor.enabled = true;
			_isTeleportActive = true;
		}
    }

    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        if (_isTeleportActive && rayInteractor.enabled == true)
        {
			rayInteractor.enabled = false;
            _isTeleportActive = false;
		}
	}
}
