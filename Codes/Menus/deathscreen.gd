extends Control



func _on_reesayer_pressed() -> void:
	get_tree().change_scene_to_file("res://Codes/world.tscn")


func _on_menu_principal_pressed() -> void:
		get_tree().change_scene_to_file("res://Codes/Menus/MenuPrincipal.tscn")



func _on_quitter_pressed() -> void:
	get_tree().quit()
