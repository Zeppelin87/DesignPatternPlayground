using System;

namespace DesignPatterPlayground.DesignPatterns.Behavioral.State.ClassicImplementationExample
{
    // Modeling a light switch.
    // The light is either on or off.
    // In the classic state design pattern, each state is a class.
    //      This is not recommended.
    public static class ClassicImplementation
    {
        public static void Run()
        {
            var lightSwitch = new LightSwitch();
            lightSwitch.On();
            lightSwitch.Off();
            lightSwitch.Off();
        }
    }

    // The control element - allows the light to switch from one state to another.
    // You tell the state to switch itself from one state to another.
    public class LightSwitch
    {
        public State State = new OffState();
        public void On() { State.On(this); }
        public void Off() { State.Off(this); }
    }

    // State of the light. 
    public abstract class State
    {
        public virtual void On(LightSwitch lightSwitch)
        {
            Console.WriteLine("Light is already on.");
        }

        public virtual void Off(LightSwitch lightSwitch)
        {
            Console.WriteLine("Light is already off.");
        }
    }

    public class OnState : State
    {
        public OnState()
        {
            Console.WriteLine("Light turned on.");
        }

        // Only override Off() - the light is already On();
        public override void Off(LightSwitch lightSwitch)
        {
            Console.WriteLine("Turing light off...");
            lightSwitch.State = new OffState();
        }
    }

    public class OffState : State
    {
        public OffState()
        {
            Console.WriteLine("Light turned off.");
        }

        // Only override On() - the light is already Off();
        public override void On(LightSwitch lightSwitch)
        {
            Console.WriteLine("Turning light on...");
            lightSwitch.State = new OnState();
        }
    }
}
