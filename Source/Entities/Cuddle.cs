using System;
using Godot;

namespace Kaiju.Entities
{
	public class Cuddle : Entity
	{
		//private AnimatedSprite animation;
		private AnimationNodeStateMachinePlayback stateMachine;
		private bool isMoving;
		private Sprite sprite;
		public override void _Ready()
		{

			var node = GetNode<AnimationTree>("StateMachine");
			stateMachine = (AnimationNodeStateMachinePlayback)node.Get("parameters/playback");
			sprite = GetNode<Sprite>("Sprite");
		}

		public override void UpdateMovement()
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
				sprite.Scale = new Vector2(-4,4);
				isMoving = true;
			}
			if (Input.IsActionPressed("right"))
			{
				velocity.x += 1;
				direction = Vector2.Right;
				sprite.Scale = new Vector2(4, 4);
				isMoving = true;
			}
			velocity = velocity.Normalized() * speed;
		}

		public override void UpdateAction()
		{
			if (!isActionInProgress)
			{
				if (Input.IsActionPressed("roar"))
				{
					Roar();
				}
				if (Input.IsActionPressed("stomping"))
				{
					// to do?
				}
			}
		}

		public void Roar()
		{
			isActionInProgress = true;
			setCooldown(120);
			GD.Print("RAWR!");
		}



		public override void UpdateAnimation()
		{
			var current = stateMachine.GetCurrentNode();
			if (!isActionInProgress)
			{
				if (Input.IsActionPressed("left") || Input.IsActionPressed("right"))
				{
					stateMachine.Travel("walk");
				}
				else
				{
					stateMachine.Travel("idle");
				}
			}
		}
	}
}
