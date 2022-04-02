using System;
using Godot;

namespace Kaiju.Entities
{
	public class Cuddle : Entity
	{
		private AnimatedSprite animation;

		public override void _Ready()
		{
			animation = GetNode<AnimatedSprite>("AnimatedSprite");
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
			}
			if (Input.IsActionPressed("right"))
			{
				velocity.x += 1;
				direction = Vector2.Right;
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
			if (!isActionInProgress)
			{
				if (Input.IsActionPressed("left"))
				{
					animation.FlipH = true;
					animation.Play("walk");
					direction = Vector2.Left;

				}
				else if (Input.IsActionPressed("right"))
				{
					animation.FlipH = false;
					animation.Play("walk");
					direction = Vector2.Right;
				}
				else
				{
					animation.Play("idle");
				}
			}
		}
	}
}
