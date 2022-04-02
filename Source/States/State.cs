using System;
using System.Collections.Generic;
using Godot;

namespace Kaiju.States
{
    public  class State : Node
    {

        public StateMachine stateMachine = null;

        public virtual void HandleInput(InputEvent _event)
        {

        }

        public virtual void update(float _delta)
        {

        }

        public virtual void Enter(Dictionary<string,Godot.Object> _msg)
        {

        }

        public virtual void Exit()
        {

        }
    }
}
