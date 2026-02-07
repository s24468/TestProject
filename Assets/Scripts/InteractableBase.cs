using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class InteractableBase: MonoBehaviour
    {
        [Header("Events")]
        public UnityEvent OnFocusEnter;
        public UnityEvent OnFocusExit;
        public UnityEvent OnInteracted;

        private bool _isFocused = false;

        
        public void FocusEnter()
        {
            if (_isFocused) return;
            _isFocused = true;
            OnFocusEnter?.Invoke();
        }

        public void FocusExit()
        {
            if (!_isFocused) return;
            _isFocused = false;
            OnFocusExit?.Invoke();
        }
        
    }
}