extends CuddleState

func enter(_msg : = {}) -> void:
	player.velocity = Vector2.ZERO
	
func update(delta: float) -> void:
	if Input.is_action_pressed("left") or Input.is_action_pressed("right"):
		state_machine.transition_to("Walk")
