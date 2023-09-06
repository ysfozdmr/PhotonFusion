using Fusion;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : NetworkBehaviour
{
    PlayerInteractions interactions;

    [Networked(OnChanged = nameof(Bubble1DisplayedChanged))] public bool Bubble1Displayed { get; set; }
    [Networked(OnChanged = nameof(Bubble2DisplayedChanged))] public bool Bubble2Displayed { get; set; }

    public static void Bubble1DisplayedChanged(Changed<PlayerInput> changed)
    {
        if (changed.Behaviour.Bubble1Displayed)
        {
            changed.Behaviour.interactions.SayHi();
        }
    }

    public static void Bubble2DisplayedChanged(Changed<PlayerInput> changed)
    {
        if (changed.Behaviour.Bubble2Displayed)
        {
            changed.Behaviour.interactions.SayWhatsUp();
        }
    }


    private void Start()
    {
        interactions = GetComponent<PlayerInteractions>();
    }

    public enum PlayerButtons
    {
        DisplayDialog1 = 0,
        DisplayDialog2 = 1
    }

    public struct PlayerInputs : INetworkInput
    {
        public NetworkButtons buttons;
    }

    public override void FixedUpdateNetwork()
    {
        
    }

    private void Update()
    {
        Bubble1Displayed = Input.GetKey(KeyCode.Alpha1);
        Bubble2Displayed = Input.GetKey(KeyCode.Alpha2);
    }
}
