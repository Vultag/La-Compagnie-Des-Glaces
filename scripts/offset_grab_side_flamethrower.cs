using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class offset_grab_side_flamethrower : XRGrabInteractable
{

    private Vector3 object_pos = Vector3.zero;
    private Quaternion object_rot = Quaternion.identity;


    //[SerializeField] GameObject teleport_obj;
    //[SerializeField] GameObject teleport_ray_obj;

    [SerializeField] GameObject parent_obj;

    public GameObject attach_box;

    //[SerializeField] Material red;
    //[SerializeField] Material green;



    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

        //this.transform.parent = parent_obj.transform;

        //teleport_obj.GetComponent<teleport_controller>().enable_right_teleport = false;
        //teleport_ray_obj.GetComponent<XRRayInteractor>().enabled = false;

        store_interactor(args);
        match_attach_points(args);

        parent_obj.GetComponent<Rigidbody>().useGravity = false;
        // attach_box.GetComponent<Rigidbody>().isKinematic = true;

        attach_box.GetComponent<handle>()._add_as_grab(this.gameObject);

        attach_box.GetComponent<handle>().grabbed = true;


    }

    private void store_interactor(SelectEnterEventArgs args)
    {

        object_pos = args.interactor.attachTransform.localPosition;
        object_rot = args.interactor.attachTransform.localRotation;

    }

    private void match_attach_points(SelectEnterEventArgs args)
    {

        bool hasAttach = attachTransform != null;
        args.interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        args.interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {


        //teleport_obj.GetComponent<teleport_controller>().enable_right_teleport = true;
        //teleport_ray_obj.GetComponent<XRRayInteractor>().enabled = true;

        reset_attach_point(args);
        clear_interactor(args);

        attach_box.GetComponent<handle>()._remove_as_grab(this.gameObject);

        attach_box.GetComponent<handle>()._gravity_check(parent_obj);

        //parent_obj.GetComponent<Rigidbody>().useGravity = true;

        attach_box.GetComponent<handle>()._reset_grab_to_initial_pos();

        attach_box.GetComponent<handle>().grabbed = false;

        //attach_box.GetComponent<Rigidbody>().isKinematic = false;

    }

    private void reset_attach_point(SelectExitEventArgs args)
    {

        //object_pos = args.interactor.attachTransform.localPosition;
        //object_rot = args.interactor.attachTransform.localRotation;

        args.interactor.attachTransform.localPosition = object_pos;
        args.interactor.attachTransform.localRotation = object_rot;

    }

    private void clear_interactor(SelectExitEventArgs args)
    {

        object_pos = Vector3.zero;
        object_rot = Quaternion.identity;

    }
}