using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class assign_climb_hand : XRGrabInteractable
{

    protected override void OnSelectEntered( SelectEnterEventArgs interactor)
    {

        print(interactor.GetType());

    }



}
