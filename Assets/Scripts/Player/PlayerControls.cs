// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""83dd3462-a093-4237-b87f-9541b60d614c"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""33da77f4-604d-4203-8c2b-a28a6b805426"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""e02a85d4-6abb-47fe-a940-f63f9019d1a3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""274a6bcd-4a47-40c0-b0d0-add75bff7057"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""ba6acd6a-2b21-4e9a-bd77-cb7a8e22b7cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""1c11ccfa-ff68-43da-8c4d-deb0acab3a9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""1df695e9-c68f-480a-b219-05e333fc2620"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PickUpObject"",
                    ""type"": ""Button"",
                    ""id"": ""bff6ba6d-fe4f-4960-b385-4aace7d56688"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ActivateObject"",
                    ""type"": ""Button"",
                    ""id"": ""91b78abe-5718-419b-8ee0-697cdbba6a24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""DropItem"",
                    ""type"": ""Button"",
                    ""id"": ""44d332b4-4b7c-4491-8001-636bcee7085e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Eat"",
                    ""type"": ""Button"",
                    ""id"": ""1da1762f-e73e-4227-98d5-5bafe4ad3b85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""SelectTool"",
                    ""type"": ""Button"",
                    ""id"": ""42352dd3-03ad-42ba-b336-ee681da122f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InteractMainMenu"",
                    ""type"": ""Button"",
                    ""id"": ""c3072744-6b84-4b3e-83da-475713a5b888"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""InteractPauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""b51da435-cee7-416c-b433-46080ebee726"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""InteractInventory"",
                    ""type"": ""Button"",
                    ""id"": ""beefe3b7-04bc-4b71-84cc-046281df1613"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""BuildingMenu"",
                    ""type"": ""Button"",
                    ""id"": ""304141bf-57f5-4144-a4ef-feb90ed39fb7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateBuilding"",
                    ""type"": ""Button"",
                    ""id"": ""28bf2ca8-d7ff-475c-95d8-c63fb0e2917d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CraftItemMenu"",
                    ""type"": ""Button"",
                    ""id"": ""eab6de57-62da-4cbc-95a1-b76f0fc57d5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector WASD"",
                    ""id"": ""b139dbeb-ef4b-4a35-987d-4e234b0c05b4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6444910d-3e93-4efb-ac79-56a03a4cdbca"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""45e470bc-3e20-492c-9428-fe93febd359c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""58010fd6-d304-490a-acbe-abbb21f9ac81"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""705e0416-51b8-446d-acd7-7ffaf7603388"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector Arrow Keys"",
                    ""id"": ""eb837e11-5775-46da-9212-48614d4ab292"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b82d3245-4eef-4be4-8032-e81892543f31"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c63e9c1d-51f8-490f-b785-81acec0a4c2d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""969b6673-a2b1-46bc-a474-8b99efbc8b20"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""40b9ab1f-b36c-49bf-b621-442bc3bc4674"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e6c77be1-2791-48c3-aef6-4d61c2af0805"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""589ee3e6-1c21-4138-89c9-0c81ae054aee"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd010b23-bc01-4422-a856-31d7ea6915b1"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""846a211e-1437-496d-ae7c-b2e1cb4b87d9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b44cc821-65f8-42b3-8919-2ea8d3086e32"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""342fd395-3402-4f4a-ba58-2ae9d5382b80"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c6e0eea-8a00-4ddd-8fc8-81c7af80d6a6"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""554d1b67-e127-4ecc-8550-80d7c1e72a84"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1bc9fa6-9627-472e-a96b-21b18f563e6e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0302e5ae-cf33-48aa-9248-a88ea40726f8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7abd6a5f-fae5-4be0-983a-a99620147c2d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbe3cf64-fa4f-4ca4-8a0a-3d7826af565d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PickUpObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcb57160-d35c-451b-bbd4-bee2d3bdb1a9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""PickUpObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcaa1bae-11da-4683-b025-abc603b8e021"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ActivateObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9455dcc7-3c81-4b8c-9529-c9c6ccedb3f9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""ActivateObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5e98fe0-5a7f-44ba-81bd-90d05d5bce49"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12bc2b40-ec2c-48b3-a2d6-fa9b7b650bc7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6c539a4-6f3c-48da-9690-edd44fab6e47"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""DropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb7886fd-1ad2-4b87-9bb0-ce3f31a9f59a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Eat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43d141a2-806e-42e3-96da-1646cb7d2738"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Eat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05435a7c-2fea-42ad-a900-c24dcb416db6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SelectTool"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0b10b5d-d96d-4572-aa44-b6442a62157c"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SelectTool"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9be52867-4007-46b6-9d17-1a968d1a9c8b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""InteractMainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eaab9282-bb48-496f-b7e9-27a21742e044"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""InteractMainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b72ee744-5e22-459c-b89a-0c289d38bb3b"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""InteractPauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fc41e5f-294c-41d0-bdc8-51ecaa7bdfb4"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""InteractPauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3656a7f9-21cf-4461-9616-a2aec8c0f54e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""InteractPauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3b35457-0691-4e18-bcf0-ecd4c6e52215"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""InteractInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""646a4df6-5398-4eca-a67d-50dbc3624ff6"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""InteractInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89805a34-dcd6-452e-91e2-dcbc4e6562cd"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""BuildingMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""id"": ""fb86e4f3-d3b0-41a1-b0e9-7021f77da96f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBuilding"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dc043035-8c0e-42a0-919c-eb10b090522f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""RotateBuilding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""48e47199-5330-4c3f-8b9b-5427f6961666"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""RotateBuilding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""RotateGamePad"",
                    ""id"": ""66260b18-fdbd-444b-af25-f1d9795ff252"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateBuilding"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""fb63ed52-36fc-437a-a4d8-49bdde75472e"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotateBuilding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7fea05ca-4557-446b-9b2c-edcfb196147c"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotateBuilding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ca30e35d-cc3e-4906-9e41-dd6092d3b016"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""CraftItemMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""c0dfc08f-3b1f-462c-bcdb-eac53659531d"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""661adfb1-e00b-4925-a278-0dff1a8bed9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8ab9001c-238b-439e-a0bc-6990bca1e304"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseCoordinates"",
                    ""type"": ""Value"",
                    ""id"": ""8f50ae9e-f4e6-46be-9d6b-26bd0502d544"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""06fc84d2-70e2-4455-916a-d72efc8d1d55"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e044cf1c-f0ae-4b18-9613-7e4e53c566bd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5506e36-15bb-4fbf-ace9-9e71370f2976"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06bf0714-5d3a-40f7-a671-c4c55ef8a534"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bc3bdc6-9b83-4b45-a984-020ca5313046"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e20d32fa-cfa7-405e-851c-0c05da80f8c8"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17e8bb0d-e136-47e5-a4a1-17762f355b3d"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90d4a1c2-027f-48cb-be96-f3ace53e1c3f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""eb858d88-aa43-4086-959e-8d051f201baf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ed123f54-a166-4201-a9ff-45a81bc1ddd7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b8cc1015-a833-4d6a-a64c-b9e8e146606f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6b04f745-0337-4334-a8df-97c9a2a50c2d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""898a9993-e239-4f8b-ab89-e80326ea70da"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""a70a51dc-a1c2-416f-8902-bff3c65e0080"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4a0bc95f-09f2-412f-b67f-768745be67e1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""99bcf6e9-3fba-49a7-aca6-de4fb2356445"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""807f85e4-551c-49c0-9b89-e4ab45fe262a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5046c0a9-87f7-4088-85f2-47fca06f4748"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0ffbc2c2-a265-4e48-8921-fc597422197c"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseCoordinates"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Look = m_Gameplay.FindAction("Look", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Crouch = m_Gameplay.FindAction("Crouch", throwIfNotFound: true);
        m_Gameplay_Attack = m_Gameplay.FindAction("Attack", throwIfNotFound: true);
        m_Gameplay_Throw = m_Gameplay.FindAction("Throw", throwIfNotFound: true);
        m_Gameplay_PickUpObject = m_Gameplay.FindAction("PickUpObject", throwIfNotFound: true);
        m_Gameplay_ActivateObject = m_Gameplay.FindAction("ActivateObject", throwIfNotFound: true);
        m_Gameplay_DropItem = m_Gameplay.FindAction("DropItem", throwIfNotFound: true);
        m_Gameplay_Eat = m_Gameplay.FindAction("Eat", throwIfNotFound: true);
        m_Gameplay_SelectTool = m_Gameplay.FindAction("SelectTool", throwIfNotFound: true);
        m_Gameplay_InteractMainMenu = m_Gameplay.FindAction("InteractMainMenu", throwIfNotFound: true);
        m_Gameplay_InteractPauseMenu = m_Gameplay.FindAction("InteractPauseMenu", throwIfNotFound: true);
        m_Gameplay_InteractInventory = m_Gameplay.FindAction("InteractInventory", throwIfNotFound: true);
        m_Gameplay_BuildingMenu = m_Gameplay.FindAction("BuildingMenu", throwIfNotFound: true);
        m_Gameplay_RotateBuilding = m_Gameplay.FindAction("RotateBuilding", throwIfNotFound: true);
        m_Gameplay_CraftItemMenu = m_Gameplay.FindAction("CraftItemMenu", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Select = m_Menu.FindAction("Select", throwIfNotFound: true);
        m_Menu_Move = m_Menu.FindAction("Move", throwIfNotFound: true);
        m_Menu_MouseCoordinates = m_Menu.FindAction("MouseCoordinates", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Look;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Crouch;
    private readonly InputAction m_Gameplay_Attack;
    private readonly InputAction m_Gameplay_Throw;
    private readonly InputAction m_Gameplay_PickUpObject;
    private readonly InputAction m_Gameplay_ActivateObject;
    private readonly InputAction m_Gameplay_DropItem;
    private readonly InputAction m_Gameplay_Eat;
    private readonly InputAction m_Gameplay_SelectTool;
    private readonly InputAction m_Gameplay_InteractMainMenu;
    private readonly InputAction m_Gameplay_InteractPauseMenu;
    private readonly InputAction m_Gameplay_InteractInventory;
    private readonly InputAction m_Gameplay_BuildingMenu;
    private readonly InputAction m_Gameplay_RotateBuilding;
    private readonly InputAction m_Gameplay_CraftItemMenu;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Look => m_Wrapper.m_Gameplay_Look;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Crouch => m_Wrapper.m_Gameplay_Crouch;
        public InputAction @Attack => m_Wrapper.m_Gameplay_Attack;
        public InputAction @Throw => m_Wrapper.m_Gameplay_Throw;
        public InputAction @PickUpObject => m_Wrapper.m_Gameplay_PickUpObject;
        public InputAction @ActivateObject => m_Wrapper.m_Gameplay_ActivateObject;
        public InputAction @DropItem => m_Wrapper.m_Gameplay_DropItem;
        public InputAction @Eat => m_Wrapper.m_Gameplay_Eat;
        public InputAction @SelectTool => m_Wrapper.m_Gameplay_SelectTool;
        public InputAction @InteractMainMenu => m_Wrapper.m_Gameplay_InteractMainMenu;
        public InputAction @InteractPauseMenu => m_Wrapper.m_Gameplay_InteractPauseMenu;
        public InputAction @InteractInventory => m_Wrapper.m_Gameplay_InteractInventory;
        public InputAction @BuildingMenu => m_Wrapper.m_Gameplay_BuildingMenu;
        public InputAction @RotateBuilding => m_Wrapper.m_Gameplay_RotateBuilding;
        public InputAction @CraftItemMenu => m_Wrapper.m_Gameplay_CraftItemMenu;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @Attack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Throw.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThrow;
                @PickUpObject.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUpObject;
                @PickUpObject.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUpObject;
                @PickUpObject.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUpObject;
                @ActivateObject.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnActivateObject;
                @ActivateObject.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnActivateObject;
                @ActivateObject.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnActivateObject;
                @DropItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDropItem;
                @DropItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDropItem;
                @DropItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDropItem;
                @Eat.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEat;
                @Eat.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEat;
                @Eat.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEat;
                @SelectTool.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectTool;
                @SelectTool.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectTool;
                @SelectTool.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectTool;
                @InteractMainMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractMainMenu;
                @InteractMainMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractMainMenu;
                @InteractMainMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractMainMenu;
                @InteractPauseMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractPauseMenu;
                @InteractPauseMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractPauseMenu;
                @InteractPauseMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractPauseMenu;
                @InteractInventory.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractInventory;
                @InteractInventory.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractInventory;
                @InteractInventory.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteractInventory;
                @BuildingMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBuildingMenu;
                @BuildingMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBuildingMenu;
                @BuildingMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBuildingMenu;
                @RotateBuilding.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateBuilding;
                @RotateBuilding.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateBuilding;
                @RotateBuilding.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateBuilding;
                @CraftItemMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCraftItemMenu;
                @CraftItemMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCraftItemMenu;
                @CraftItemMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCraftItemMenu;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @PickUpObject.started += instance.OnPickUpObject;
                @PickUpObject.performed += instance.OnPickUpObject;
                @PickUpObject.canceled += instance.OnPickUpObject;
                @ActivateObject.started += instance.OnActivateObject;
                @ActivateObject.performed += instance.OnActivateObject;
                @ActivateObject.canceled += instance.OnActivateObject;
                @DropItem.started += instance.OnDropItem;
                @DropItem.performed += instance.OnDropItem;
                @DropItem.canceled += instance.OnDropItem;
                @Eat.started += instance.OnEat;
                @Eat.performed += instance.OnEat;
                @Eat.canceled += instance.OnEat;
                @SelectTool.started += instance.OnSelectTool;
                @SelectTool.performed += instance.OnSelectTool;
                @SelectTool.canceled += instance.OnSelectTool;
                @InteractMainMenu.started += instance.OnInteractMainMenu;
                @InteractMainMenu.performed += instance.OnInteractMainMenu;
                @InteractMainMenu.canceled += instance.OnInteractMainMenu;
                @InteractPauseMenu.started += instance.OnInteractPauseMenu;
                @InteractPauseMenu.performed += instance.OnInteractPauseMenu;
                @InteractPauseMenu.canceled += instance.OnInteractPauseMenu;
                @InteractInventory.started += instance.OnInteractInventory;
                @InteractInventory.performed += instance.OnInteractInventory;
                @InteractInventory.canceled += instance.OnInteractInventory;
                @BuildingMenu.started += instance.OnBuildingMenu;
                @BuildingMenu.performed += instance.OnBuildingMenu;
                @BuildingMenu.canceled += instance.OnBuildingMenu;
                @RotateBuilding.started += instance.OnRotateBuilding;
                @RotateBuilding.performed += instance.OnRotateBuilding;
                @RotateBuilding.canceled += instance.OnRotateBuilding;
                @CraftItemMenu.started += instance.OnCraftItemMenu;
                @CraftItemMenu.performed += instance.OnCraftItemMenu;
                @CraftItemMenu.canceled += instance.OnCraftItemMenu;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Select;
    private readonly InputAction m_Menu_Move;
    private readonly InputAction m_Menu_MouseCoordinates;
    public struct MenuActions
    {
        private @PlayerControls m_Wrapper;
        public MenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Menu_Select;
        public InputAction @Move => m_Wrapper.m_Menu_Move;
        public InputAction @MouseCoordinates => m_Wrapper.m_Menu_MouseCoordinates;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                @Move.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMove;
                @MouseCoordinates.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMouseCoordinates;
                @MouseCoordinates.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMouseCoordinates;
                @MouseCoordinates.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMouseCoordinates;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MouseCoordinates.started += instance.OnMouseCoordinates;
                @MouseCoordinates.performed += instance.OnMouseCoordinates;
                @MouseCoordinates.canceled += instance.OnMouseCoordinates;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnPickUpObject(InputAction.CallbackContext context);
        void OnActivateObject(InputAction.CallbackContext context);
        void OnDropItem(InputAction.CallbackContext context);
        void OnEat(InputAction.CallbackContext context);
        void OnSelectTool(InputAction.CallbackContext context);
        void OnInteractMainMenu(InputAction.CallbackContext context);
        void OnInteractPauseMenu(InputAction.CallbackContext context);
        void OnInteractInventory(InputAction.CallbackContext context);
        void OnBuildingMenu(InputAction.CallbackContext context);
        void OnRotateBuilding(InputAction.CallbackContext context);
        void OnCraftItemMenu(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnMouseCoordinates(InputAction.CallbackContext context);
    }
}
