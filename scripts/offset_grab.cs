using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.InputSystem;

public class offset_grab : XRGrabInteractable
{

    private Vector3 object_pos = Vector3.zero;
    private Quaternion object_rot = Quaternion.identity;
    [SerializeField] Transform parent_object;
    [SerializeField] GameObject teleport_obj;
    [SerializeField] GameObject teleport_ray_obj;

    public GameObject micro;

    //[SerializeField] private InputActionAsset actionAsset;


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

        
        //print((args.interactor.name));

        if (args.interactor.name != "mic_socket"  && args.interactor.name != "Teleport Ray Interactor right") // laisser sinon regrab instant quand on lache le mic dans le socket ou ray
        {
            teleport_obj.GetComponent<teleport_controller>().enable_right_teleport = false;    //A REMETTRE
            teleport_ray_obj.GetComponent<XRRayInteractor>().enabled = false;      //A REMETTRE

            //this.transform.parent = parent_object;

            store_interactor(args);
            match_attach_points(args);

            if (args.interactable.name == "micro")
            {


                micro.GetComponent<mic_event>()._mic_activate();

            }

        }


    }

    private void store_interactor(SelectEnterEventArgs args)
    {

        object_pos = args.interactor.attachTransform.localPosition;
        object_rot = args.interactor.attachTransform.localRotation;

        //pas sur
        //object_parent = args.interactor.transform.parent.gameObject;

    }

    private void match_attach_points(SelectEnterEventArgs args)
    {

        bool hasAttach = attachTransform != null;
        args.interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        args.interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {

        //print("exit");

        teleport_obj.GetComponent<teleport_controller>().enable_right_teleport = true;
        teleport_ray_obj.GetComponent<XRRayInteractor>().enabled = true;

        reset_attach_point(args);
        clear_interactor(args);

        //this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        if (args.interactable.name == "micro")
        {


            micro.GetComponent<mic_event>()._mic_deactivate();

        }

    }


    private void reset_attach_point(SelectExitEventArgs args)
    {

        // TRUC D AVANT
        //object_pos = args.interactor.attachTransform.localPosition;
        //object_rot = args.interactor.attachTransform.localRotation;

        // CA MARCHE COMME CA
        args.interactor.attachTransform.localPosition = object_pos;
        args.interactor.attachTransform.localRotation = object_rot;

        // pas sur
        //args.interactor.transform.parent.gameObject = object_parent;

    }

    private void clear_interactor(SelectExitEventArgs args)
    {

        object_pos = Vector3.zero;
        object_rot = Quaternion.identity;

        //object_parent = null;
        //this.transform.parent = parent_object;

    }







}
