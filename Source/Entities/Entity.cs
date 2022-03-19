using Godot;
using System;

namespace Kaiju.Entities
{

    /// <summary>
    /// The superclass that handle all the entity in the game
    /// </summary>
    public abstract class Entity : KinematicBody2D
    {
        [Export]
        public readonly int walkingSpeed = 200;
        [Export]
        public readonly int runningSpeed = 400;

        public Vector2 direction = Vector2.Right;

        public Vector2 velocity = new Vector2();

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {

        }

        public abstract void GetInput();

        public override void _PhysicsProcess(float delta)
        {
            GetInput();
            UpdateAnimation();
            velocity = MoveAndSlide(velocity);
        }

        public abstract void UpdateAnimation();
    }
}
