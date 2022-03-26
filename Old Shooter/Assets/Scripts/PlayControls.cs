//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/PlayControls.inputactions
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

public partial class @PlayControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayControls"",
    ""maps"": [
        {
            ""name"": ""P1"",
            ""id"": ""cec67c6d-a487-4d0c-9207-07b37070f168"",
            ""actions"": [
                {
                    ""name"": ""MoveCrossair"",
                    ""type"": ""Value"",
                    ""id"": ""608b9320-84a3-4049-805e-862e17e12945"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""0e604b39-ce33-40b9-b1ec-aa5afebfd123"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""d3b197c7-21c1-4c0b-bf66-2ed4ccd11971"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""97fde2d6-034a-4ed2-9f38-7127378458ed"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCrossair"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e23adca4-d20d-4d09-abdf-63eab1c87c0d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCrossair"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3c5e63b5-c92c-4f9f-908f-6311ac075d5d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCrossair"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""39a2045a-5b0d-40c8-bb9b-bfbb1adac8b5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCrossair"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f8fe1cbf-a640-4b3d-9369-712bb8e0d876"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCrossair"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e824cfa5-2ee6-4f4c-88c8-da30079256d0"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cdfbf7b-429b-4c5a-ba3c-52568e878c95"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // P1
        m_P1 = asset.FindActionMap("P1", throwIfNotFound: true);
        m_P1_MoveCrossair = m_P1.FindAction("MoveCrossair", throwIfNotFound: true);
        m_P1_Shoot = m_P1.FindAction("Shoot", throwIfNotFound: true);
        m_P1_Reload = m_P1.FindAction("Reload", throwIfNotFound: true);
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

    // P1
    private readonly InputActionMap m_P1;
    private IP1Actions m_P1ActionsCallbackInterface;
    private readonly InputAction m_P1_MoveCrossair;
    private readonly InputAction m_P1_Shoot;
    private readonly InputAction m_P1_Reload;
    public struct P1Actions
    {
        private @PlayControls m_Wrapper;
        public P1Actions(@PlayControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCrossair => m_Wrapper.m_P1_MoveCrossair;
        public InputAction @Shoot => m_Wrapper.m_P1_Shoot;
        public InputAction @Reload => m_Wrapper.m_P1_Reload;
        public InputActionMap Get() { return m_Wrapper.m_P1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(P1Actions set) { return set.Get(); }
        public void SetCallbacks(IP1Actions instance)
        {
            if (m_Wrapper.m_P1ActionsCallbackInterface != null)
            {
                @MoveCrossair.started -= m_Wrapper.m_P1ActionsCallbackInterface.OnMoveCrossair;
                @MoveCrossair.performed -= m_Wrapper.m_P1ActionsCallbackInterface.OnMoveCrossair;
                @MoveCrossair.canceled -= m_Wrapper.m_P1ActionsCallbackInterface.OnMoveCrossair;
                @Shoot.started -= m_Wrapper.m_P1ActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_P1ActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_P1ActionsCallbackInterface.OnShoot;
                @Reload.started -= m_Wrapper.m_P1ActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_P1ActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_P1ActionsCallbackInterface.OnReload;
            }
            m_Wrapper.m_P1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveCrossair.started += instance.OnMoveCrossair;
                @MoveCrossair.performed += instance.OnMoveCrossair;
                @MoveCrossair.canceled += instance.OnMoveCrossair;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
            }
        }
    }
    public P1Actions @P1 => new P1Actions(this);
    public interface IP1Actions
    {
        void OnMoveCrossair(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
    }
}
