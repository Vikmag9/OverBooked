//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/ElevetorInputMap.inputactions
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

public partial class @ElevetorInputMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ElevetorInputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ElevetorInputMap"",
    ""maps"": [
        {
            ""name"": ""Elevator"",
            ""id"": ""ee8e421f-aaee-4d17-af14-7a5e3ae3da7b"",
            ""actions"": [
                {
                    ""name"": ""Call"",
                    ""type"": ""Button"",
                    ""id"": ""42817196-3617-40b9-8758-bc416925565b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveElevator"",
                    ""type"": ""Value"",
                    ""id"": ""e4af6626-289a-4f57-a368-e3490f1d0b44"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveElevatorUp"",
                    ""type"": ""Button"",
                    ""id"": ""8df3169f-79c1-453a-a29f-58247374419d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveElevatorDown"",
                    ""type"": ""Button"",
                    ""id"": ""4b12730e-fce4-4c89-a6d2-0c554f9f97f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""800442f2-86e5-49bb-bed5-3ba88051857b"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Call"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b338883-c37a-4040-96ac-6842b0b273f1"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Call"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""94abaf8c-7eba-496d-8768-a54a4989ab01"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevator"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""69f994f7-2850-433a-b5e6-5a6e74456b9a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5d9b2135-9884-4fae-bb9a-1e6f936ca26e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ea84ca2-44fe-41c3-908d-daf561cfea56"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""07b16634-2278-4b07-abc7-9596334624c4"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""bb3e501f-61c5-4dd2-a9cd-406d7a0daae7"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevator"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""14bc5d0e-c8ea-4fc8-bcde-a00729b785bb"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c5a01f64-72eb-4c1e-aef1-596f8a9e8b4c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""df9e212c-a5cc-4804-a4ae-a5726afe2f23"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevatorUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9d765e1-efc5-41a1-99da-b9966ff8e90a"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevatorUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2db487bb-be53-49b9-abb2-7ef0a9bf986c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevatorDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""187e4593-fee6-4c66-bf37-751ede518972"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveElevatorDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Elevator
        m_Elevator = asset.FindActionMap("Elevator", throwIfNotFound: true);
        m_Elevator_Call = m_Elevator.FindAction("Call", throwIfNotFound: true);
        m_Elevator_MoveElevator = m_Elevator.FindAction("MoveElevator", throwIfNotFound: true);
        m_Elevator_MoveElevatorUp = m_Elevator.FindAction("MoveElevatorUp", throwIfNotFound: true);
        m_Elevator_MoveElevatorDown = m_Elevator.FindAction("MoveElevatorDown", throwIfNotFound: true);
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

    // Elevator
    private readonly InputActionMap m_Elevator;
    private List<IElevatorActions> m_ElevatorActionsCallbackInterfaces = new List<IElevatorActions>();
    private readonly InputAction m_Elevator_Call;
    private readonly InputAction m_Elevator_MoveElevator;
    private readonly InputAction m_Elevator_MoveElevatorUp;
    private readonly InputAction m_Elevator_MoveElevatorDown;
    public struct ElevatorActions
    {
        private @ElevetorInputMap m_Wrapper;
        public ElevatorActions(@ElevetorInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Call => m_Wrapper.m_Elevator_Call;
        public InputAction @MoveElevator => m_Wrapper.m_Elevator_MoveElevator;
        public InputAction @MoveElevatorUp => m_Wrapper.m_Elevator_MoveElevatorUp;
        public InputAction @MoveElevatorDown => m_Wrapper.m_Elevator_MoveElevatorDown;
        public InputActionMap Get() { return m_Wrapper.m_Elevator; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ElevatorActions set) { return set.Get(); }
        public void AddCallbacks(IElevatorActions instance)
        {
            if (instance == null || m_Wrapper.m_ElevatorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ElevatorActionsCallbackInterfaces.Add(instance);
            @Call.started += instance.OnCall;
            @Call.performed += instance.OnCall;
            @Call.canceled += instance.OnCall;
            @MoveElevator.started += instance.OnMoveElevator;
            @MoveElevator.performed += instance.OnMoveElevator;
            @MoveElevator.canceled += instance.OnMoveElevator;
            @MoveElevatorUp.started += instance.OnMoveElevatorUp;
            @MoveElevatorUp.performed += instance.OnMoveElevatorUp;
            @MoveElevatorUp.canceled += instance.OnMoveElevatorUp;
            @MoveElevatorDown.started += instance.OnMoveElevatorDown;
            @MoveElevatorDown.performed += instance.OnMoveElevatorDown;
            @MoveElevatorDown.canceled += instance.OnMoveElevatorDown;
        }

        private void UnregisterCallbacks(IElevatorActions instance)
        {
            @Call.started -= instance.OnCall;
            @Call.performed -= instance.OnCall;
            @Call.canceled -= instance.OnCall;
            @MoveElevator.started -= instance.OnMoveElevator;
            @MoveElevator.performed -= instance.OnMoveElevator;
            @MoveElevator.canceled -= instance.OnMoveElevator;
            @MoveElevatorUp.started -= instance.OnMoveElevatorUp;
            @MoveElevatorUp.performed -= instance.OnMoveElevatorUp;
            @MoveElevatorUp.canceled -= instance.OnMoveElevatorUp;
            @MoveElevatorDown.started -= instance.OnMoveElevatorDown;
            @MoveElevatorDown.performed -= instance.OnMoveElevatorDown;
            @MoveElevatorDown.canceled -= instance.OnMoveElevatorDown;
        }

        public void RemoveCallbacks(IElevatorActions instance)
        {
            if (m_Wrapper.m_ElevatorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IElevatorActions instance)
        {
            foreach (var item in m_Wrapper.m_ElevatorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ElevatorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ElevatorActions @Elevator => new ElevatorActions(this);
    public interface IElevatorActions
    {
        void OnCall(InputAction.CallbackContext context);
        void OnMoveElevator(InputAction.CallbackContext context);
        void OnMoveElevatorUp(InputAction.CallbackContext context);
        void OnMoveElevatorDown(InputAction.CallbackContext context);
    }
}
