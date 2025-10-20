using System;
using Domains.Events;
using Domains.Input;
using UnityEngine;

namespace Domains.Player
{
    public class PlayerController : MonoBehaviour
    {



        [SerializeField]
        private Rigidbody2D playerRb;

        private MetroMan _actions;
        void Awake()
        {
            _actions = new MetroMan();
            EventsManager.OnPlayerActionsEnabled?.Invoke(_actions);
            EventsManager.OnRigidbody2dEnabled?.Invoke(playerRb);

        }


        void OnEnable()
        {
            _actions?.Player.Enable();
        }

        void OnDisable()
        {
            _actions?.Player.Disable();
        }

        void OnDestroy()
        {
            _actions?.Dispose();
        }


    }
}
