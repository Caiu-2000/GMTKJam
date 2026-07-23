using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] TextMeshProUGUI interactionText;
    [SerializeField] float interactionDistance = 10f;
    IInteractable currentTargetedInteractable;
    public void Update()
    {
        UpdateCurrentInteractable();
        UpdateInteractionText();
        CheckForInteractionInput();
    }
    void UpdateCurrentInteractable()
    {
        Collider closestCollider = null;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionDistance);
        foreach (Collider collider in hitColliders)
        {
            if (collider?.GetComponent<IInteractable>() != null && closestCollider != null)
            {
                Vector3 closestPointNew = collider.ClosestPoint(transform.position);
                Vector3 closestPointOld = closestCollider.ClosestPoint(transform.position);
                if(Vector3.Distance(transform.position, closestPointNew) < Vector3.Distance(transform.position, closestPointOld))
                {
                    closestCollider = collider;
                }
            }
            else if (collider?.GetComponent<IInteractable>() != null)
            {
                closestCollider = collider;
            }
        }
        currentTargetedInteractable = closestCollider?.GetComponent<IInteractable>();
    }
    void UpdateInteractionText()
    {
        if(currentTargetedInteractable == null)
        {
            interactionText.text = string.Empty;
            return;
        }
        interactionText.text = currentTargetedInteractable.InteractMessage;
    }

    void CheckForInteractionInput()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && currentTargetedInteractable != null)
        {
            currentTargetedInteractable.Interact();
        }
    }
}
