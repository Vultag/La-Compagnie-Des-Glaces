using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class grab_parent_fix : MonoBehaviour
{


    public void grab(SelectEnterEventArgs args)
    {
        //StartCoroutine(reparent(args.interactable));

        args.interactable.transform.parent = this.transform;

    }


    //IEnumerator reparent(XRBaseInteractable target)
    //{
    //    print(target.transform.parent);
    //    //yield return new WaitForSeconds(1f);

    //    target.transform.parent = this.transform;

    //    //print(target.transform.parent);
    //    print(target.name);

    //    yield return null;

    //}


}
