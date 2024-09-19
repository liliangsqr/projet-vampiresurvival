extends Control



func _on_continuer_pressed() -> void:
	pass # Replace with function body.

func _on_option_pressed() -> void:
	get_tree().change_scene_to_file("res://Codes/Menus/Option_menu.tscn")


func _on_menu_principal_pressed() -> void:
	get_tree().change_scene_to_file("res://Codes/Menus/MenuPrincipal.tscn")

func _on_quitter_pressed() -> void:
	get_tree().quit()
