using System;
using Domains.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Domains.Events
{
    public static class EventsManager
    {

        // Input Events
        public static readonly EventBase<MetroMan> OnPlayerActionsEnabled = new();

        // Player Events
        public static readonly EventBase<Rigidbody2D> OnRigidbody2dEnabled = new();
        

    }
}
