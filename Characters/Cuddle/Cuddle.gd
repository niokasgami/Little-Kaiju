class_name Cuddle
extends KinematicBody2D

export (int) var speed = 200
export (int) var run = 400

onready var animation_tree = $AnimationTree
onready var state_machine = animation_tree.get("parameters/playback")


var velocity = Vector2()

func get_input():
	velocity = Vector2()
	var movement = 0
	if Input.is_action_pressed("run"):
		movement = run
	else: 
		movement = speed
		
	if Input.is_action_pressed("right"):
		velocity.x += 1		
	if Input.is_action_pressed("left"):
		velocity.x -= 1
	velocity = velocity.normalized() * movement
	

func _physics_process(delta):
	get_input()
	velocity = move_and_slide(velocity)
	if Input.is_action_pressed("right") or Input.is_action_pressed("left"):
		state_machine.travel("walk")
	else:
		state_machine.travel("idle")
