using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice_block : MonoBehaviour
{

    [SerializeField] GameObject offset;



     void OnTriggerEnter(Collider other)
    {

        //faire condition spécifique pour les particules de fue


        offset.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);

        if (offset.transform.localScale.x < 0.01)
        {
            Destroy(offset);
        }

    }


}
