using System;
using Domains.Events;
using Domains.Input;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Domains.Player
{
    public class PlayerMovement : MonoBehaviour
    {

        private Rigidbody2D playerRb;
        private MetroMan actions;

        [SerializeField]
        private float moveSpeed = 5f;
        private float movement;


        private void GetRigidbody2D(Rigidbody2D rb)
        {
            playerRb = rb;
        }

        private void GetMetroManActions(MetroMan act)
        {
            actions = act;
            actions.Player.Move.performed += OnMove;
        }


        void OnEnable()
        {

            EventsManager.OnPlayerActionsEnabled.AddListener(GetMetroManActions);
            EventsManager.OnRigidbody2dEnabled.AddListener(GetRigidbody2D);
        }

        void OnDisable()
        {
            if (actions != null)
            {
                actions.Player.Move.performed -= OnMove;
            }
            EventsManager.OnPlayerActionsEnabled.RemoveListener(GetMetroManActions);
            EventsManager.OnRigidbody2dEnabled.RemoveListener(GetRigidbody2D);
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            movement = context.ReadValue<Vector2>().x;
        }

       
        void FixedUpdate()
        {
            playerRb.linearVelocity = new Vector2(movement * moveSpeed, playerRb.linearVelocity.y);
        }
    }
}