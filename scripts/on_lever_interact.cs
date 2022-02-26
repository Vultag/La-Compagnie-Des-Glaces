using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class on_lever_interact : MonoBehaviour
{

    [SerializeField] GameObject hand_visual;
    [SerializeField] GameObject hand_control;
    [SerializeField] GameObject hand_snap_point;
    [SerializeField] GameObject train_ground;
    [SerializeField] GameObject handle;
    [SerializeField] GameObject grab_handle;


    private bool grab_switch = false;
    private double lever_rot = 0;

    public bool _is_blocked;

    public float train_max_speed;


    void Start()
    {




    }

    private void FixedUpdate()
    {


        if (grab_switch == true && _is_blocked == false)
        {

            

            lever_rot = (this.transform.localEulerAngles.x - 0) /(24.59 - 0);

            //print("angle:" + this.transform.localEulerAngles.x);
            //print("ratio:" + lever_rot);


            if ((float)lever_rot > 0.01)
            {

                train_ground.GetComponent<train_ground_path_follow>().speedModifier = train_max_speed * (float)lever_rot;
                //print("handgrab");
            }
            else
            {
                train_ground.GetComponent<train_ground_path_follow>().speedModifier = train_max_speed * 0;
            }

        }


    }


     public void _hand_grab()
    {

        grab_switch = true;

        handle.GetComponent<handle>().grabbed = true;

        //hand_visual.transform.parent = hand_snap_point.transform; 


        //hand_visual.transform.position = hand_snap_point.transform.position;
        //hand_visual.transform.eulerAngles = hand_snap_point.transform.eulerAngles;



    }

    public void _hand_release()
    {

        grab_switch = false;

        handle.GetComponent<handle>().grabbed = false;

        //hand_visual.transform.parent = hand_control.transform; 

        //hand_visual.transform.position = hand_control.transform.position;
        //hand_visual.transform.rotation = hand_control.transform.rotation;


        //Time.timeScale = 0;
        grab_handle.transform.position = handle.transform.position;


        grab_handle.GetComponent<Rigidbody>().velocity = Vector3.zero;
        grab_handle.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        handle.GetComponent<Rigidbody>().velocity = Vector3.zero;
        handle.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;




    }

    public void _train_enter_stop(bool state)
    {

        _is_blocked = state;

        if (state == true)
        {
            train_ground.GetComponent<train_ground_path_follow>().speedModifier = 0;
            train_ground.GetComponent<train_ground_path_follow>().is_blocked = true;
        }
        else
        {
            //print("test");
            //train_ground.GetComponent<train_ground_path_follow>().speedModifier = train_max_speed;
            train_ground.GetComponent<train_ground_path_follow>().is_blocked = false;
        }

    }



}
