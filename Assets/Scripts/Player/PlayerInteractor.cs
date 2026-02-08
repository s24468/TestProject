using Interactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Raycast")] [SerializeField] private float interactDistance = 12f;
    [SerializeField] private LayerMask interactLayer;

    [Header("Pointer")] [SerializeField] private Image pointer;
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color interactColor = Color.green;

    [Header("Camera Control")] [SerializeField]
    private Transform rayOrigin;

    [Header("UI")] [SerializeField] private TextMeshProUGUI interactedNameObject;

    private InteractableBase current;

    void Update()
    {
        RaycastingCheck();
    }

    private void RaycastingCheck()
    {
        InteractableBase newTarget = null;
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
        {
            newTarget = hit.collider.GetComponentInParent<InteractableBase>();
            Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.red);
        }

        EventsInteraction(newTarget);

        UIInteraction();
    }

    private void EventsInteraction(InteractableBase newTarget)
    {
        if (newTarget != current)
        {
            if (current != null)
            {
                current.FocusExit();
            }

            current = newTarget;
            if (current != null)
            {
                current.FocusEnter();
            }
        }
    }

    private void UIInteraction()
    {
        if (interactedNameObject != null)
        {
            if (current != null)
            {
                string prompt = current.Name;
                interactedNameObject.text = prompt;
            }
            else
            {
                interactedNameObject.text = "";
            }
        }

        if (pointer != null)
        {
            pointer.color = (current != null) ? interactColor : defaultColor;
        }
    }

    public void OnInteract()
    {
        if (current != null)
            current.Interact();
    }
}