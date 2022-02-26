using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class handle_grab_overwrite_left : MonoBehaviour
{

    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] public GameObject static_handle;



    void Start()
    {


        var activate_l = actionAsset.FindActionMap("XRI LeftHand").FindAction("Select");
        activate_l.canceled += _realese_grab;
        var activate_r = actionAsset.FindActionMap("XRI RightHand").FindAction("Select");
        activate_r.canceled += _realese_grab;




        //activate.performed += _teleportModeActivate;

    }

    void _realese_grab(InputAction.CallbackContext obj)
    {



        this.transform.position = static_handle.transform.position;
        this.transform.rotation = static_handle.transform.rotation;

    }



}
