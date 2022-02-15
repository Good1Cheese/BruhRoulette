// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""b04149c3-b042-42a5-a441-23e161e56f72"",
            ""actions"": [
                {
                    ""name"": ""View"",
                    ""type"": ""Value"",
                    ""id"": ""ce5b1084-ee95-4965-aa25-1ec38803cb1f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartButtonPress"",
                    ""type"": ""Button"",
                    ""id"": ""30205789-5d39-4958-888d-8b7abceef6f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ed95e68f-536f-45e3-9a7a-eb6a02a78940"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false)"",
                    ""groups"": """",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfa2a09d-9db6-47bf-9567-fd4a2af1a0e5"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButtonPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Revolver"",
            ""id"": ""e3d4f5a2-3de1-4fc8-872d-da571f9a93dc"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""b511502e-c519-44fe-bd07-532692bae564"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Button"",
                    ""id"": ""35086495-3368-4266-99a4-b406b69ee054"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""17ee3eb1-4f16-4064-8ee3-9a114586488a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dde7779-0250-4f28-8a61-7d63840d2bcb"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_View = m_Main.FindAction("View", throwIfNotFound: true);
        m_Main_StartButtonPress = m_Main.FindAction("StartButtonPress", throwIfNotFound: true);
        // Revolver
        m_Revolver = asset.FindActionMap("Revolver", throwIfNotFound: true);
        m_Revolver_Fire = m_Revolver.FindAction("Fire", throwIfNotFound: true);
        m_Revolver_Scroll = m_Revolver.FindAction("Scroll", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_View;
    private readonly InputAction m_Main_StartButtonPress;
    public struct MainActions
    {
        private @PlayerInput m_Wrapper;
        public MainActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @View => m_Wrapper.m_Main_View;
        public InputAction @StartButtonPress => m_Wrapper.m_Main_StartButtonPress;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @View.started -= m_Wrapper.m_MainActionsCallbackInterface.OnView;
                @View.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnView;
                @View.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnView;
                @StartButtonPress.started -= m_Wrapper.m_MainActionsCallbackInterface.OnStartButtonPress;
                @StartButtonPress.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnStartButtonPress;
                @StartButtonPress.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnStartButtonPress;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @View.started += instance.OnView;
                @View.performed += instance.OnView;
                @View.canceled += instance.OnView;
                @StartButtonPress.started += instance.OnStartButtonPress;
                @StartButtonPress.performed += instance.OnStartButtonPress;
                @StartButtonPress.canceled += instance.OnStartButtonPress;
            }
        }
    }
    public MainActions @Main => new MainActions(this);

    // Revolver
    private readonly InputActionMap m_Revolver;
    private IRevolverActions m_RevolverActionsCallbackInterface;
    private readonly InputAction m_Revolver_Fire;
    private readonly InputAction m_Revolver_Scroll;
    public struct RevolverActions
    {
        private @PlayerInput m_Wrapper;
        public RevolverActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Revolver_Fire;
        public InputAction @Scroll => m_Wrapper.m_Revolver_Scroll;
        public InputActionMap Get() { return m_Wrapper.m_Revolver; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RevolverActions set) { return set.Get(); }
        public void SetCallbacks(IRevolverActions instance)
        {
            if (m_Wrapper.m_RevolverActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_RevolverActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_RevolverActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_RevolverActionsCallbackInterface.OnFire;
                @Scroll.started -= m_Wrapper.m_RevolverActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_RevolverActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_RevolverActionsCallbackInterface.OnScroll;
            }
            m_Wrapper.m_RevolverActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
            }
        }
    }
    public RevolverActions @Revolver => new RevolverActions(this);
    public interface IMainActions
    {
        void OnView(InputAction.CallbackContext context);
        void OnStartButtonPress(InputAction.CallbackContext context);
    }
    public interface IRevolverActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
    }
}
