using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class climb_script : MonoBehaviour
{

    private string hand_attached = null; // recupere la main qui utilise le piolet et si elle attachee // pas utile?
    private Vector2 pick_attached = new Vector2(0, 0); //recupe le nom du piolet attache // pas utile?



    private string pick_attached_to_right = null;
    private string pick_attached_to_left = null;


    private CharacterController character; // pas utile

    public GameObject right_hand;
    public GameObject left_hand;

    public XRDirectInteractor right_hand_interactor;
    public XRDirectInteractor left_hand_interactor;

    public GameObject pick_1;
    public GameObject pick_2;

    public GameObject tip_collider_1; //pas utile ?
    public GameObject tip_collider_2; //pas utile ?

    private Vector3 right_hand_velocity = Vector3.zero;
    private Vector3 left_hand_velocity = Vector3.zero;
    private Vector3 right_hand_previous_pos = Vector3.zero;
    private Vector3 left_hand_previous_pos = Vector3.zero;

    void Start()
    {

        character = GetComponent<CharacterController>(); // pas utile ?

    }


    void FixedUpdate()
    {
        //left_hand.transform.position += new Vector3(2, 2, 2);

        //print(left_hand_interactor.isSelectActive);

        //calcule de la velocite des deux mains

        right_hand_velocity = ((right_hand.transform.localPosition - right_hand_previous_pos) / Time.fixedDeltaTime);
        right_hand_previous_pos = right_hand.transform.localPosition;

        left_hand_velocity = ((left_hand.transform.localPosition - left_hand_previous_pos) / Time.fixedDeltaTime);
        left_hand_previous_pos = left_hand.transform.localPosition;


        if (pick_attached_to_right != null || pick_attached_to_left != null)
        {

            _climb();
            //print(right_hand_velocity.z);

            if (pick_attached_to_right != null)
            {

                if (pick_attached_to_right == "pick_handle_grabbable_1")
                {

                    if (right_hand_velocity.z < -2 && right_hand_interactor.isSelectActive)
                    {

                        //print("test");

                        pick_1.GetComponent<ice_attach>().ice_detach();

                        pick_attached_to_right = null;


                    }
                }
                else if (pick_attached_to_right == "pick_handle_grabbable_2")
                {

                    if (right_hand_velocity.z < -2 && right_hand_interactor.isSelectActive)
                    {

                        

                        pick_2.GetComponent<ice_attach>().ice_detach();

                        pick_attached_to_right = null;


                    }

                }

            }
            if (pick_attached_to_left != null)
            {
                //print("test");

                if (pick_attached_to_left == "pick_handle_grabbable_1")
                {

                    

                    if (left_hand_velocity.z < -2 && left_hand_interactor.isSelectActive)
                    {

                        //print("test");

                        pick_1.GetComponent<ice_attach>().ice_detach();

                        pick_attached_to_left = null;


                    }
                }
                else if (pick_attached_to_left == "pick_handle_grabbable_2")
                {

                    if (left_hand_velocity.z < -2 && left_hand_interactor.isSelectActive)
                    {

                        //print("test");

                        pick_2.GetComponent<ice_attach>().ice_detach();

                        pick_attached_to_left = null;


                    }

                }

            }



        }

    }

    public void _ice_attached(string hand, string pick)
    {


        if (hand == "right")
        {
            pick_attached_to_right = pick;
        }

        if (hand == "left")
        {
            pick_attached_to_left = pick;
            print(pick);
        }


        //hand_attached = hand;

        //pick_attached = pick;

    }

    void _climb()
    {

            //print(hand_attached);

            //character.Move(-velocity * Time.fixedDeltaTime);

            if (pick_attached_to_right != null && pick_attached_to_left != null)
        {

            //print("test");

            //this.transform.position += (this.transform.rotation * -right_hand_velocity * Time.fixedDeltaTime);
            //this.transform.position += (this.transform.rotation * -left_hand_velocity * Time.fixedDeltaTime);

            var right_hand_move = (this.transform.rotation * -right_hand_velocity * Time.fixedDeltaTime);
            var left_hand_move = (this.transform.rotation * -left_hand_velocity * Time.fixedDeltaTime);

            this.transform.position += right_hand_move;
            this.transform.position += left_hand_move;

            right_hand.transform.position -= left_hand_move;
            left_hand.transform.position -= left_hand_move;

        }
        else if (pick_attached_to_right != null && pick_attached_to_left == null)
        {

            //print("test");

            this.transform.position += (this.transform.rotation * -right_hand_velocity * Time.fixedDeltaTime);

        }

        else if (pick_attached_to_right == null && pick_attached_to_left != null)
        {

            this.transform.position += (this.transform.rotation * -left_hand_velocity * Time.fixedDeltaTime);

        }



    }


}
