extends Area2D



func _on_Adults_body_entered(body: PhysicsBody2D)->void:
	print("Man it hurt :<")
	queue_free()
