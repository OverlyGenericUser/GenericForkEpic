using System;
using Robust.Shared.GameObjects;
using Robust.Shared.Serialization;

namespace Content.Shared.GameObjects.Components.Interactable
{
    public enum Tool : byte
    {
        Wrench,
        Crowbar,
        Screwdriver,
        Wirecutter,
        Welder,
        Multitool,
    }

    public class SharedToolComponent : Component
    {
        public override string Name => "Tool";
        public override uint? NetID => ContentNetIDs.TOOL;

        public virtual Tool Behavior { get; set; }
    }

    [NetSerializable, Serializable]
    public class ToolComponentState : ComponentState
    {
        public Tool Behavior { get; }

        public ToolComponentState(Tool behavior) : base(ContentNetIDs.TOOL)
        {
            Behavior = behavior;
        }
    }

    [NetSerializable, Serializable]
    public class WelderComponentState : ComponentState
    {
        public float FuelCapacity { get; }
        public float Fuel { get; }
        public bool Activated { get; }
        public Tool Behavior { get; }

        public WelderComponentState(float fuelCapacity, float fuel, bool activated) : base(ContentNetIDs.WELDER)
        {
            FuelCapacity = fuelCapacity;
            Fuel = fuel;
            Activated = activated;
            Behavior = Tool.Welder;
        }
    }
}
