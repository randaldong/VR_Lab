using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class myRayInteractor : MonoBehaviour
{
    // Start is called before the first frame update
    Ray _ray;
    RaycastHit _Rayhit;
    [SerializeField] float maxDist;
    [SerializeField] LineRenderer lineRend;
    [SerializeField] GameObject anchor;
    [SerializeField] LayerMask _layerMask;

    // var used in get device by xrNode
    [SerializeField] private XRNode lefthandNode;
    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice lControler;
    private MyRayInteractable _curInteractable;

    //setuo 

    void getDevice()
    {
        //get left controller
        InputDevices.GetDevicesAtXRNode(lefthandNode, devices);
        lControler = devices.FirstOrDefault();

    }

    private void Start()
    {
        if (!lControler.isValid)
        {
            getDevice();
        }
    }
    private void Update()
    {
        if (!lControler.isValid)
        {
            getDevice();
        }
        _ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(_ray, out _Rayhit, maxDist, _layerMask))
        {
            _curInteractable = _Rayhit.transform.GetComponent<MyRayInteractable>();
            //render ray
            lineRend.enabled = true;
            lineRend.SetPosition(0, anchor.transform.position);
            lineRend.SetPosition(1, _Rayhit.point);
            //select item
            bool ltriggerButtonAction = false;
            if (lControler.TryGetFeatureValue(CommonUsages.triggerButton, out ltriggerButtonAction) && ltriggerButtonAction)
            {
                _curInteractable.SelectObj();
                lineRend.startColor = Color.white;
                lineRend.endColor = Color.white;
                Debug.Log("trigger pulled");
            }
            //diselect item
            bool lgriprButtonAction = false;
            if (lControler.TryGetFeatureValue(CommonUsages.gripButton, out lgriprButtonAction) && lgriprButtonAction)
            {
                _curInteractable.diSelectObj();
                lineRend.startColor = Color.white;
                lineRend.endColor = Color.white; ;
                Debug.Log("grip pulled");
            }

            //distory item using prime button
            bool primeButtonAction = false;
            if (lControler.TryGetFeatureValue(CommonUsages.primaryButton, out primeButtonAction) && primeButtonAction)
            {
                _curInteractable.destroyObj();
                lineRend.startColor = Color.white;
                lineRend.endColor = Color.white;
                Debug.Log("grip pulled");
            }
        }
        else
        {
            lineRend.enabled = false;
        }
    }
}
