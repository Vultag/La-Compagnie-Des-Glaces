using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class iceblock_master : MonoBehaviour
{

    public GameObject levier;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.childCount == 0)
        {

            levier.GetComponent<on_lever_interact>()._train_enter_stop(false);

            Destroy(this.gameObject);

        }

    }
}
