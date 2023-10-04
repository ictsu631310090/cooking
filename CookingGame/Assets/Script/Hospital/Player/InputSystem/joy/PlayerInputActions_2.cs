//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Script/Hospital/Player/InputSystem/joy/PlayerInputActions_2.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions_2 : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions_2()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions_2"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e063dcfa-250f-4a9c-8504-64fca66a958a"",
            ""actions"": [
                {
                    ""name"": ""Q"",
                    ""type"": ""PassThrough"",
                    ""id"": ""49928570-2dda-470f-8cdc-19d00a5a0d91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""walk"",
                    ""type"": ""Value"",
                    ""id"": ""95f92137-04bc-4480-89ff-abbba3627400"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""E"",
                    ""type"": ""Button"",
                    ""id"": ""9d24e631-cf38-41a6-88f7-ed15bd7049d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8e143fb2-6620-49ae-93b7-249c773b7a30"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Q"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""92567db4-ebfc-44b6-8e6d-b9946d35baa3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""276d4cfd-bb2c-4aa3-8db6-a079c50b9c98"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""fc751279-d695-41fc-bf37-81c42214e374"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""a2f24b99-3155-45db-a9fe-15374b04ca74"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""916712f0-f45c-4725-a88c-ac301be6fc6d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cdfdb0eb-5459-4978-acf1-858dd66a28c2"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Q = m_Player.FindAction("Q", throwIfNotFound: true);
        m_Player_walk = m_Player.FindAction("walk", throwIfNotFound: true);
        m_Player_E = m_Player.FindAction("E", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Q;
    private readonly InputAction m_Player_walk;
    private readonly InputAction m_Player_E;
    public struct PlayerActions
    {
        private @PlayerInputActions_2 m_Wrapper;
        public PlayerActions(@PlayerInputActions_2 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Q => m_Wrapper.m_Player_Q;
        public InputAction @walk => m_Wrapper.m_Player_walk;
        public InputAction @E => m_Wrapper.m_Player_E;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Q.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQ;
                @Q.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQ;
                @Q.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQ;
                @walk.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @walk.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @walk.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @E.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnE;
                @E.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnE;
                @E.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnE;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Q.started += instance.OnQ;
                @Q.performed += instance.OnQ;
                @Q.canceled += instance.OnQ;
                @walk.started += instance.OnWalk;
                @walk.performed += instance.OnWalk;
                @walk.canceled += instance.OnWalk;
                @E.started += instance.OnE;
                @E.performed += instance.OnE;
                @E.canceled += instance.OnE;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnQ(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnE(InputAction.CallbackContext context);
    }
}
