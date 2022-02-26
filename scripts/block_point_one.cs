using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_point_one : MonoBehaviour
{

    public GameObject levier;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "train")
        {

            levier.GetComponent<on_lever_interact>()._train_enter_stop(true);

            Destroy(this.gameObject);

        }
    }



}
