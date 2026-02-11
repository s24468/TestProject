using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Interactions
{
    public abstract class InteractableBase : MonoBehaviour
    {
        [Header("Attributes")] [SerializeField]
        public InteractionData interactionData;


        [Header("Interaction")] [SerializeField]
        private bool isEnabled = true;

        private bool _isFocused = false;


        protected abstract void PerformInteract();

        public void FocusEnter()
        {
            if (_isFocused)
            {
                return;
            }

            _isFocused = true;
        }

        public void FocusExit()
        {
            if (!_isFocused)
            {
                return;
            }

            _isFocused = false;
        }

        public void Interact()
        {
            if (!isEnabled)
            {
                return;
            }

            PerformInteract();
        }
    }
}