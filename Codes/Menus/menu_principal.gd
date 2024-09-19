extends Control



func _on_jouer_pressed() -> void:
	get_tree().change_scene_to_file("res://Codes/world.tscn")

func _on_option_pressed() -> void:
	get_tree().change_scene_to_file("res://Codes/Menus/Option_menu.tscn")
	

func _on_quitter_pressed() -> void:
	get_tree().quit()
