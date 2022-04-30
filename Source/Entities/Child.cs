using Godot;
using System;

namespace Kaiju.Entities
{
  public class Child : Npc
  {

	private bool isFollowing = false;
	private PhysicsBody2D cuddle = null;
	private Vector2 velocity = Vector2.Zero;
	private bool isWithinFollowRadius = false;

	public override void _Ready()
	{
	}


	public override void _PhysicsProcess(float delta)
	{
	  if (cuddle == null) { return; }
	  velocity = Vector2.Zero;
	  if (!isWithinFollowRadius)
	  {
		isFollowing = false;
	  }
	  if (isFollowing)
	  {
		velocity.x = cuddle.Position.x - this.Position.x;
		velocity *= movementSpeed * delta;
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
   public void OnFollowRadiusBodyEntered(object body)
	{
	  var colliderNode = (Node) body;
	  if (colliderNode.IsInGroup("Player"))
	  {
		isWithinFollowRadius = true;
	  }
	}

   public void OnFollowRadiusBodynExited(object body)
	{
	  var colliderNode = (Node)body;
	  if (colliderNode.IsInGroup("Player"))
	  {
		isWithinFollowRadius = false;
	  }
	}
  }
}

