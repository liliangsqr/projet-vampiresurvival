extends Control


func _on_option_pressed() -> void:
	get_tree().paused = false
	CustomGameLoop.GetInstance().GetLevelManager().LoadLevel("res://Codes/Menus/Option_menu.tscn")

func _on_menu_principal_pressed() -> void:
	get_tree().paused = false
	CustomGameLoop.GetInstance().GetLevelManager().LoadLevel("res://Codes/Menus/MenuPrincipal.tscn")

func _on_quitter_pressed() -> void:
	CustomGameLoop.GetInstance().CloseGame()


func _on_continuer_pressed() -> void:
	get_tree().paused = false
	hide()

func _on_saugarder_quitter_pressed() -> void:
	pass # Replace with function body.
