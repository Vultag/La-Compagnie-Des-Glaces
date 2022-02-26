using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_opening : MonoBehaviour
{

    [SerializeField] GameObject verrou;
    [SerializeField] GameObject handle_right;
    [SerializeField] GameObject grabable_handle_right;
    [SerializeField] GameObject handle_left;
    [SerializeField] GameObject grabable_handle_left;

    [SerializeField] Material red;
    [SerializeField] Material green;
    [SerializeField] Material orange;

    bool handle_grabbed = false;
    bool lock_door_test = true;


    Vector3 stored_right_pos;
    Vector3 stored_left_pos;


    
    void Start()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;

    }

    
    void FixedUpdate()
    {

        if (handle_grabbed == true)
        {

            HingeJoint joint = verrou.GetComponent<HingeJoint>();
            HingeJoint joint_door = this.GetComponent<HingeJoint>();

            //print(joint_door.angle);


            if (lock_door_test == true)
            {

                if (joint.angle > 175)
                {

                    //grab_right.GetComponent<XRGrabInteractable>().interactionLayerMask = 0;
                    //grab_left.GetComponent<XRGrabInteractable>().interactionLayerMask = 0;
                    this.GetComponent<Rigidbody>().isKinematic = false;
                    verrou.GetComponent<MeshRenderer>().material = green;
                    lock_door_test = false;
                    
                }

                if (joint.angle < -175)
                {

                    verrou.GetComponent<MeshRenderer>().material = red;

                }
                else if(joint.angle < 175)
                {
                    verrou.GetComponent<MeshRenderer>().material = orange;
                }

            }
            else
            {


                if ((joint_door.angle > 1))
                {
                
                    if (joint.angle < 175)
                    {
                        this.GetComponent<Rigidbody>().isKinematic = true;
                        this.transform.localEulerAngles = new Vector3(0, 0, 0);
                        lock_door_test = true;
                    }
                }




            }
        }


    }

    public void _press_grab_right()
    {


        stored_right_pos = handle_right.transform.localPosition;

        

        handle_grabbed = true;

        //this.transform.parent = handle_right.transform;


        handle_right.GetComponent<handle>().grabbed = true;




    }

    public void _press_grab_left()
    {

        stored_left_pos = handle_left.transform.localPosition;

        handle_grabbed = true;

        handle_left.GetComponent<handle>().grabbed = true;

    }


    public void _realese_grab_right()
    {

        handle_grabbed = false;

        //this.transform.parent = null;
        grabable_handle_right.transform.localPosition = stored_right_pos;
        grabable_handle_right.transform.localRotation = handle_right.transform.rotation;

        handle_right.GetComponent<handle>().grabbed = false;


    }
    public void _realese_grab_left()
    {

        handle_grabbed = false;

        //this.transform.parent = null;
        grabable_handle_left.transform.localPosition = stored_left_pos;
        grabable_handle_left.transform.localRotation = handle_left.transform.rotation;

        handle_left.GetComponent<handle>().grabbed = false;

    }



}


//float minRotation = -45;
//float maxRotation = 45;
//Vector3 currentRotation = transform.localRotation.eulerAngles;
//currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);
//transform.localRotation = Quaternion.Euler(currentRotation);