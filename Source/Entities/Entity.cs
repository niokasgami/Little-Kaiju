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
        public readonly int walkingSpeed = 250;
        [Export]
        public readonly int runningSpeed = 400;

        public Vector2 direction = Vector2.Right;

        public Vector2 velocity = new Vector2();
        public bool isActionInProgress = false;
        private int cooldown = 0;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {

        }

        public abstract void UpdateMovement();
        public abstract void UpdateAction();

        public override void _PhysicsProcess(float delta)
        {

            UpdateAction();
            if (!isActionInProgress)
            {
                UpdateMovement();
                velocity = MoveAndSlide(velocity);
            }
            if (isActionInProgress)
            {
                UpdateCooldown();
            }
            UpdateAnimation();
        }

        private void UpdateCooldown()
        {
            if(cooldown <= 0)
            {
                isActionInProgress = false;
                cooldown = 0;
                GD.Print("Input no more blocked");
            } else
            {
                cooldown--;
            }
        }

        public abstract void UpdateAnimation();

        public void setCooldown(int frames)
        {
            cooldown = frames;
        }
    }
}
