using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class mic_event : MonoBehaviour
{

    [SerializeField] Canvas canvas_dialogue;




    void Start()
    {

        canvas_dialogue.enabled = false;

    }

    

    

    public void _mic_activate()
    {
        // temporaire avant que ce soit rythmé par les dialogues


        canvas_dialogue.enabled = true;

        //print("azeazeazeaze");

        // besoin du ray du teleport actif pour interagir avec UI

    }

    public void _mic_deactivate()

    {

        canvas_dialogue.enabled = false;


    }


    public void _button_press(GameObject button)
    {
        //print("test");
        if (button.GetComponent<Image>().color == Color.blue) button.GetComponent<Image>().color = Color.green;
        else button.GetComponent<Image>().color = Color.blue;


    }




    //ColorBlock colors = button.colors;
    //colors.normalColor = Color.green;
    // button.colors = colors;





}
