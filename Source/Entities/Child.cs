using Godot;
using System;

namespace Kaiju.Entities {
    public class Child : Area2D
    {

        private bool isFollowing = false;
        private bool isPlayerNear = false;
        private KinematicBody2D cuddle;

        public override void _Ready()
        {
            cuddle = Owner.GetNode<KinematicBody2D>("Cuddle");
        }
        //  // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(float delta)
        {
            if (isFollowing)
            {
                var position = GlobalPosition.LinearInterpolate(cuddle.GlobalPosition, 2);
                GlobalPosition = position;
            }
        }

        public override void _Input(InputEvent @event)
        {
            if (isPlayerNear)
            {
                if (@event.IsActionPressed("roar"))
                {
                    if (!isFollowing)
                    {
                        isFollowing = true;
                    }
                    else
                    {
                        isFollowing = false;
                    }
                }
            }
        }

        public void OnChildBodyEntered(PhysicsBody2D body)
        {
            isPlayerNear = true;
        }
        public void OnChildBodyExited(PhysicsBody2D body)
        {
            isPlayerNear = false;
        }
    }
}
