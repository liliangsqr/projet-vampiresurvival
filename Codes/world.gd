extends Node2D

func _process(delta: float) -> void:
	if Input.is_action_just_pressed("Pause_menu"):
		pause()
	
func pause():
	Globals.game_paused =!Globals.game_paused
	
