
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class teleport_controller_old : MonoBehaviour
{

    public GameObject controller_object;
    public GameObject teleportation_object;

    public InputActionReference teleport_activation_reference;

    [Space]
    public UnityEvent on_teleport_active;
    public UnityEvent on_teleport_cancel;






    void Start()
    {
        teleport_activation_reference.action.performed += _teleportModeActivate;
        teleport_activation_reference.action.canceled += Action_canceled;
    }

    private void Action_canceled(InputAction.CallbackContext obj)
    {
        Invoke("_deactivated_teleport", 0.1f);
    }

    void _deactivate_teleport()
    {
        on_teleport_cancel.Invoke();
    }

    private void _teleportModeActivate(InputAction.CallbackContext obj)
    {
        on_teleport_active.Invoke();
    }


}
