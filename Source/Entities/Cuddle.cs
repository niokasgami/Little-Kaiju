using System;
using Godot;

namespace Kaiju.Entities
{
    public class Cuddle : Entity
    {

        public override void GetInput()
        {
            velocity = new Vector2();
            int speed;
            if (Input.IsActionPressed("run"))
            {
                speed = runningSpeed;
            }
            else
            {
                speed = walkingSpeed;
            }

            if (Input.IsActionPressed("left"))
            {
                velocity.x -= 1;
                direction = Vector2.Left;
            }
            if (Input.IsActionPressed("right"))
            {
                velocity.x += 1;
                direction = Vector2.Right;
            }
            velocity = velocity.Normalized() * speed;
        }

        public override void UpdateAnimation()
        {
            // TODO: wait for Amy to have the sprites?
        }
    }
}
