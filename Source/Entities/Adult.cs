using Godot;
using System;
namespace Kaiju.Entities
{
    public class Adult : Area2D
    {

        public bool isPlayerNear = false;

        public override void _Input(InputEvent @event)
        {
            if(@event.IsActionPressed("roar") && isPlayerNear)
            {
                GD.Print("Ah scary!");
            }
        }
        public void OnAdultsBodyEntered(PhysicsBody2D body)
        {
            isPlayerNear = true;
        }

        public void OnAdultsBodyExited(PhysicsBody2D body)
        {
            isPlayerNear = false;
        }
    }
}
