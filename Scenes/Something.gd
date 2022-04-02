extends Area2D

func _on_adult_body_entered(body: PhysicsBody2D)->void:
	 queue_free()
