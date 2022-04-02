using System;
using Godot;

namespace Kaiju.States
{
    public class StateMachine : Node
    {
        [Signal]
        delegate void transitionned(string state_name);

        public NodePath initialState = new NodePath();

        [Export]
        public State state;

        public override void _Ready()
        {
            state = GetNode<State>(initialState);
            

        }
    }
}
