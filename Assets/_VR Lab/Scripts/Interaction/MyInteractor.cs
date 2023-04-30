using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.XR;

public class MyInteractor : MonoBehaviour
{
    [SerializeField] private Transform _interactionAncher;
    [SerializeField] private float _redius  = 0.1f;
    [SerializeField] private LayerMask _interactionLayermask;
    private readonly Collider[] handcolid = new Collider[10];
    [SerializeField] private int numFound = 0;
    
    // var used in get device by xrNode
    [SerializeField] private XRNode lefthandNode;
    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice lControler;

    [SerializeField] private XRNode righthandNode;
    private List<InputDevice> rightdevices = new List<InputDevice>();
    private InputDevice RControler;

    private myInteractable[] temp;

    void getDevice()
    {
        //get left controller
        InputDevices.GetDevicesAtXRNode(lefthandNode, devices);
        lControler = devices.FirstOrDefault();

        //get right controller
        InputDevices.GetDevicesAtXRNode(righthandNode, rightdevices);
        RControler = rightdevices.FirstOrDefault();

    }

    private void Start()
    {
        if(!lControler.isValid || !RControler.isValid)
        {
            getDevice();
        }
    }
    private void Update()
    {
        //try get input device 
        if (!lControler.isValid || !RControler.isValid)
        {
            getDevice();
        }


        numFound = Physics.OverlapSphereNonAlloc(_interactionAncher.position, _redius,handcolid, _interactionLayermask);
		temp = new myInteractable[numFound];
		if (numFound > 0)
        {
            var interactable = handcolid[0].GetComponent<myInteractable>();
			//interact with all element colided
			for (int i = 0; i < numFound; i++)
            {
                if (interactable != null)
                {
                    interactable = handcolid[i].GetComponent<myInteractable>();
                    temp[i] = interactable;
                    //colide call contact
                    interactable.interact(this);
                    bool ltriggerButtonAction = false;
                    if (lControler.TryGetFeatureValue(CommonUsages.triggerButton, out ltriggerButtonAction) && ltriggerButtonAction)
                    {
                        interactable.Leftinteract(this);
                    }


                    bool RtriggerButtonAction = false;
                    if (RControler.TryGetFeatureValue(CommonUsages.triggerButton, out RtriggerButtonAction) && RtriggerButtonAction)
                    {
                        interactable.Rightinteract(this);
                    }
                }
            }
        }
        //has some bug, not able to disslect a part of all collider while stillselecting other(but not necerry in this project)
        else
        {
            foreach (myInteractable x in temp)
            {
                x.loseContact(this);
            }
        }
    }


    //draw the collider 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionAncher.position, _redius);
    }

    //what happened when toggled

}