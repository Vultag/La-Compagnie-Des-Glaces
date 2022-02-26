using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Locomotion_controler_old : MonoBehaviour
{

    public XRController left_teleport;
    public XRController right_teleport;
    public InputHelpers.Button teleport_activation_button;
    public float activation_threshold = 0.1f;


    void Update()
    {
        if (left_teleport)
        {
            left_teleport.gameObject.SetActive(check_if_activated(left_teleport));
        }
        if (right_teleport)
        {
            right_teleport.gameObject.SetActive(check_if_activated(left_teleport));
        }

    }

    public bool check_if_activated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleport_activation_button, out bool isActivated, activation_threshold);
        return isActivated;
    }



}
