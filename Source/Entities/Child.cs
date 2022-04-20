using Godot;
using System;

namespace Kaiju.Entities {
    public class Child : Npc
    {

        private bool isFollowing = false;
        private PhysicsBody2D cuddle = null;
        private Vector2 velocity = Vector2.Zero;

        public override void _Ready()
        {
        }


        public override void _PhysicsProcess (float delta)
        {
            velocity = Vector2.Zero;
            if (isFollowing)
            {
                velocity = Position.DirectionTo(cuddle.Position) * movementSpeed;
            }
            velocity = MoveAndSlide(velocity);
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
            GD.Print("it collided?");
            cuddle = body;
            isPlayerNear = true;
        }
        public void OnChildBodyExited(PhysicsBody2D body)
        {
            isPlayerNear = false;
        }
    }
}
