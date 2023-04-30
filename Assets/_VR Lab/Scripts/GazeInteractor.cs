using UnityEngine;
using UnityEngine.UI;

public class GazeInteractor : MonoBehaviour
{
	[Header("Ray Settings")]
	[SerializeField] private float _maxDetectionDistance = 10.0f;
	[SerializeField] private LayerMask _gazeInteractableLayer;


	[Header("Reticle Settings")]
	[SerializeField] GameObject gazeAim;
	[SerializeField] Image gazeWizardImage;


	private Ray _ray;
	private RaycastHit _hitInfo;
	private GazeInteractable _curInteractable, _prevInteractable;
	private float _gazeTime = 0;

	private Quaternion attachOrient;
	private float distance = 0;
	private Vector3 attachPos;

	private void FixedUpdate()
	{
		_ray = new Ray(transform.position, transform.forward);

		/*--------------------------------- Ray & GazeInteractable ---------------------------------*/
		if (Physics.Raycast(_ray, out _hitInfo, _maxDetectionDistance, _gazeInteractableLayer))
		{
			_curInteractable = _hitInfo.transform.GetComponent<GazeInteractable>();
			if (_curInteractable != null && _curInteractable != _prevInteractable) // gaze enter
			{
				_curInteractable.GazeEnter();
				if (_prevInteractable != null)
				{
					OnGazeExit();
				}
				_prevInteractable = _curInteractable;
			}
			else if (_curInteractable != null && _curInteractable == _prevInteractable) // keep gazing
			{
				_gazeTime += Time.deltaTime;

				gazeWizardImage.fillAmount = _gazeTime / _curInteractable.timeToActivate;

				if (_gazeTime >= _curInteractable.timeToActivate)
				{
					if (distance == 0)
					{
						distance = _hitInfo.distance;
						attachOrient = _curInteractable.transform.rotation;
					}
					OnGazeActivated();
				}
			}
		}
		else
		{
			if (_prevInteractable != null)
			{
				OnGazeExit();
			}
		}
	}
	/*--------------------------------- Ray & GazeInteractable ---------------------------------*/
	private void OnGazeActivated()
	{

		gazeWizardImage.fillAmount = 0;

		attachPos = transform.position + distance * transform.forward;
		_curInteractable.GazeAvtivated(_gazeTime - _curInteractable.timeToActivate, attachPos, attachOrient);

	}

	private void OnGazeExit()
	{
		_prevInteractable.GazeExit();
		_prevInteractable = null;
		_gazeTime = 0;
		gazeWizardImage.fillAmount = 0f;
	}

	

}