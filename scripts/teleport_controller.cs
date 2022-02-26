
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class teleport_controller : MonoBehaviour
{

    //public GameObject teleport_ray_right;
    //public GameObject teleport_ray_left;

    //public InputActionReference teleport_activation_reference;

    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor raycast_interactor_right;
    [SerializeField] private XRRayInteractor raycast_interactor_left;
    [SerializeField] private GameObject reticle;


    public bool enable_right_teleport;
    public bool enable_left_teleport;


    void Start()
    {


        raycast_interactor_right.GetComponent<XRInteractorLineVisual>().enabled = false;
        raycast_interactor_left.GetComponent<XRInteractorLineVisual>().enabled = false;

        var activate_right = actionAsset.FindActionMap("XRI RightHand").FindAction("Activate");
        var activate_left = actionAsset.FindActionMap("XRI LeftHand").FindAction("Activate");


        activate_right.canceled += _teleportModeDeactivate_right;
        activate_left.canceled += _teleportModeDeactivate_left;

        activate_right.performed += _teleportModeActivate_right;
        activate_left.performed += _teleportModeActivate_left;


    }

    private void _teleportModeActivate_right(InputAction.CallbackContext obj)
    {

        //print("test");

        if (enable_right_teleport == true)
        {
            //print("test");
            raycast_interactor_right.GetComponent<XRInteractorLineVisual>().enabled = true;
            reticle.SetActive(true);
        }


    }


    private void _teleportModeDeactivate_right(InputAction.CallbackContext obj)
    {
        if (enable_right_teleport == true)
        {
            if (raycast_interactor_right.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                print(hit.collider.name.ToString());

                if (hit.collider.name.ToString() == "train_ground_teleport")
                {
                    this.transform.parent = hit.collider.transform;
                }
                else  if (hit.collider.tag == "sol")
                {
                    this.transform.parent = null;
                    //print(hit.collider.name.ToString());
                }

            }

            raycast_interactor_right.GetComponent<XRInteractorLineVisual>().enabled = false;
            reticle.SetActive(false);
        }

    }
    private void _teleportModeActivate_left(InputAction.CallbackContext obj)
    {



        if (enable_left_teleport == true)
        {
            //print("test");
            raycast_interactor_left.GetComponent<XRInteractorLineVisual>().enabled = true;
            reticle.SetActive(true);
        }

    }


    private void _teleportModeDeactivate_left(InputAction.CallbackContext obj)
    {
        if (enable_left_teleport == true)
        {
            if (raycast_interactor_left.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {


                if (hit.collider.name.ToString() == "train_ground_teleport")
                {
                    this.transform.parent = hit.collider.transform;
                }
                else if (hit.collider.tag == "sol")
                {
                    this.transform.parent = null;
                }

            }

            raycast_interactor_left.GetComponent<XRInteractorLineVisual>().enabled = false;
            reticle.SetActive(false);
        }

    }


}
