using System.Collections;
using System;
using UnityEngine;

namespace Arkanoid
{
    public class InputController : MonoBehaviour
    {
        public event Action OnBallThrow;
        public event Action<float> OnMove;
        
        private InputControl input;
        private bool isMoving;

        private void Awake() => input = new InputControl();

        public void OnEnable() => input.Enable();

        private void OnDisable() => input.Disable();

        private void Start()
        {
            input.Main.Movement.performed += _ =>
            {
                if (!isMoving)
                {
                    isMoving = true;
                    StartCoroutine(MovementProcess());
                }
            };

            input.Main.Movement.canceled += _ => isMoving = false;

            input.Main.Fire.performed += _ => OnBallThrow?.Invoke();
        }

        private IEnumerator MovementProcess()
        {
            while (isMoving)
            {
                float movement = input.Main.Movement.ReadValue<float>();
                OnMove?.Invoke(movement);

                yield return null;
            }
        }
    }
}