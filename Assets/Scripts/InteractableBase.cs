using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public abstract class InteractableBase : MonoBehaviour
    {
        [Header("Attributes")] [SerializeField]
        public string Name = "Interactable";

        [Header("Interaction")] [SerializeField]
        private bool isEnabled = true;

        [Header("Events")] public UnityEvent OnFocusEnter;
        public UnityEvent OnFocusExit;
        public UnityEvent OnInteracted;

        private bool _isFocused = false;

        protected abstract void PerformInteract();
        public void FocusEnter()
        {
            if (_isFocused)
            {
                return;
            }

            _isFocused = true;
            OnFocusEnter?.Invoke();
        }

        public void FocusExit()
        {
            if (!_isFocused)
            {
                return;
            }

            _isFocused = false;
            OnFocusExit?.Invoke();
        }

        public void Interact()
        {
            if (!isEnabled)
            {
                return;
            }

            PerformInteract();
            OnInteracted?.Invoke();
        }
    }
}