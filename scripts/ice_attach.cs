using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ice_attach : MonoBehaviour
{

    public string pick_name;

    public GameObject xr_rig;
    public GameObject parent;

    public XRDirectInteractor right_hand; 
    public XRDirectInteractor left_hand; 


    private string hand_attached = null; 

    //public bool is_attached = false;
    //public bool is_held = false; pour réduire le calcul de la velocité uniquement quand y'a besoin pour opti

    public Material green;
    public Material red;

    private Vector3 velocity;
    private Vector3 previous_pos;



    void Start()
    {
        xr_rig = xr_rig;
        previous_pos = this.transform.position;

    }


    void FixedUpdate()
    {

        velocity = ((this.transform.position - previous_pos) / Time.fixedDeltaTime);
        previous_pos = this.transform.position;


        //essaye de track la velocity du piolet (bof) mtn grab object comme poignee

        //print(Hand.GetComponent<Rigidbody>().velocity.magnitude);

        //print(velocity);


        if (velocity.magnitude > 2)
        {
            //print("test");
            //parent.GetComponent<MeshCollider>().enabled = false;
            GetComponent<MeshRenderer>().material = red;

            this.gameObject.layer = 14; //climable_layer

        }
        else
        {
            GetComponent<MeshRenderer>().material = green;

            this.gameObject.layer = 11; //objects_interract_static
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //print("enter");

        // probleme la !!
        /*
        if (right_hand.isSelectActive)
        {
            if (right_hand.selectTarget.name == pick_name)
            {
                hand_attached = "right";
                //print("test");
            }
        }
        if (left_hand.isSelectActive)
        {
            if (left_hand.selectTarget.name == pick_name)
            {
                hand_attached = "left";
            }
        }
        */
        /*
        
            if (right_hand.selectTarget.name == "pick_handle_grabbable_2")
            {
                hand_attached = "right";
            }
            if (right_hand.selectTarget.name == "pick_handle_grabbable_1")
            {
                hand_attached = "right";
            }




            if (left_hand.selectTarget.name == "pick_handle_grabbable_1")
            {
                hand_attached = "left";
            }
            if (left_hand.selectTarget.name == "pick_handle_grabbable_2")
            {
                hand_attached = "left";
            }
      */



        //print(other.gameObject.layer);

        if (other.gameObject.layer == 14)
        {
            //is_attached = true;

            //print(right_hand.isSelectActive);
            //print(left_hand.isSelectActive);


            //print(hand_grabbing);

            //if (hand_grabbing != null)
            //{
               // if (hand_attached == "right")
               // {

                    

                    xr_rig.GetComponent<climb_script>()._ice_attached(hand_attached, pick_name);
            //print(hand_attached);
            //print(pick_name);

                    parent.GetComponent<Rigidbody>().isKinematic = true;

                    this.gameObject.layer = 14;

                    //this.GetComponent<BoxCollider>().enabled = false;

               // }
            //}
            /*
            if (left_hand.isSelectActive)
            {

                if (hand_attached == "left")
                {


                    xr_rig.GetComponent<climb_script>()._ice_attached("left", pick_name);

                    parent.GetComponent<Rigidbody>().isKinematic = true;

                    this.gameObject.layer = 14;

                    //this.GetComponent<BoxCollider>().enabled = false;

                }
            }
            */
        }

    }

    public void ice_detach()
    {

        //print(this.name);

        //is_attached = false;


        parent.GetComponent<Rigidbody>().isKinematic = false;

        this.gameObject.layer = 11;

        //hand_attached = null;

        //this.GetComponent<BoxCollider>().enabled = true;

        //xr_rig.GetComponent<Rigidbody>().isKinematic = false;

        //xr_rig.GetComponent<MeshRenderer>().material = green;

    }

    public void holding_hand (SelectEnterEventArgs agrs)
    {
        if (agrs.interactor == right_hand) hand_attached = "right";

        if (agrs.interactor == left_hand) hand_attached = "left";

        //print(agrs.interactor.name);


        //hand_attached = "right";

    }


}
