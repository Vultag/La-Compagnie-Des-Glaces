using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle : MonoBehaviour
{

    public Transform target;
    private Quaternion rot_offset;

    public bool two_hand_grab_test = false;

    public List<GameObject> grabbing_obj = null;

    public GameObject handle_of_side;
    public GameObject handle_of_gachette;
    public GameObject tracking_origin;

    Rigidbody RB;

    public bool grabbed = false;


    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        /*
        // handlepasgrabbable en kinematique mais probleme avec 2hand grab ?

            //if (Vector3.Distance(RB.position,this.transform.position) < 0.000001f) RB.position += ((target.transform.position - this.transform.position).normalized * 0.1f);

            //RB.AddForce((target.transform.position - RB.position).normalized * 10); // MARCHE PRESQUE
            //RB.AddForce((target.transform.position - RB.position),ForceMode.VelocityChange);
            //RB.AddForceAtPosition((target.transform.position - RB.position).normalized * 10, target.transform.position);

            //RB.velocity = (target.transform.position - RB.position)*10; // OUIIIIIIIIIIIIIIIIIIIII

        //RB.MovePosition(target.GetComponent<Rigidbody>().position);
        //RB.MovePosition(tracking_origin.transform.position + (target.transform.position - tracking_origin.transform.position) * 0.1f); // REUSIS A LE FAIRE MARCHE ?
        //RB.MovePosition(ktracing_origin.GetComponentInParent<Transform>().position + (target.transform.position - tracking_origin.GetComponentInParent<Transform>().position) * 0.1f); // REUSIS A LE FAIRE MARCHE ?
        //RB.MovePosition(RB.position + (target.transform.position - RB.position) * 0.1f); // REUSIS A LE FAIRE MARCHE ?
        //RB.MovePosition(target.transform.position);
        //this.transform.position = this.transform.position + (target.transform.position - this.transform.position).normalized * 2f;
        //this.transform.position = this.transform.position + (target.transform.position - this.transform.position)/10;
        //RB.position = RB.position + (target.GetComponent<Rigidbody>().position - RB.position)/10;

        //this.transform.position += (target.transform.position - this.transform.position).normalized * 0.1f;


        //RB.AddForce(transform.forward*100);



        RB.velocity = (target.transform.position - this.transform.position) * 10;
        //print("target : " + target.transform.position);
        //print("position : " + this.transform.position);

        if (target.name != "handle_grabable_right" && target.name != "handle_grabable_left" &&  target.name != "grabable_handle")
        {
            RB.MoveRotation(target.transform.rotation);
            //this.transform.rotation = target.transform.rotation; //a remettre mais conflit avec le levier 
        }
        //RB.position = (target.transform.position);
        //RB.rotation = (target.transform.rotation);
        //RB.rotation = (target.transform.rotation);
        //RB.rotation = (target.transform.rotation * Quaternion.Inverse(rot_offset)).normalized; //tentative rotation plus offset mais pas bon ?
        */
        if (grabbed == true)
        {
            print("test");

            RB.velocity = (target.transform.position - this.transform.position) * 10;

            if (target.name != "handle_grabable_right" && target.name != "handle_grabable_left" && target.name != "grabable_handle")
            {
               this.transform.rotation = target.transform.rotation;
            }


        }
        //RB.velocity = (target.transform.position - this.transform.position) * 10;


    }

    public void _offset_setup()
    {

        rot_offset = target.transform.rotation;

    }

    public void _reset_grab_to_initial_pos()
    {
        grabbed = false;

        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        target.transform.position = this.transform.position;
        target.transform.rotation = this.transform.rotation;

    }

    public void _two_hand_grab_test(bool value)
    {
        two_hand_grab_test = value;
    }

    public void _add_as_grab(GameObject obj)
    {

        grabbing_obj.Add(obj);

    }

    public void _remove_as_grab(GameObject obj)
    {

        grabbing_obj.Remove(obj);

    }

    public void _gravity_check(GameObject obj)
    {

        //print(grabbing_obj.Count);

        if(handle_of_side.GetComponent<handle>().grabbing_obj.Count == 0 && handle_of_gachette.GetComponent<handle>().grabbing_obj.Count == 0)
        {
            obj.GetComponent<Rigidbody>().useGravity = true;
        }

    }

    public void _grabbed(bool state)
    {
        print("rzerzer");
        grabbed = state;
    }

}