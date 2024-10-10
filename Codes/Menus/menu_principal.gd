extends Control

func _on_continuer_pressed() -> void:
	CustomGameLoop.GetInstance().OnContinueButtonPressed();
	pass 

func _on_nouvelle_partie_pressed() -> void:
	#reset du fichier de sauvegarde + 
	CustomGameLoop.GetInstance().GetLevelManager().LoadLevel("res://Codes/world.tscn")
	pass 

func _on_option_pressed() -> void:
	CustomGameLoop.GetInstance().GetLevelManager().LoadLevel("res://Codes/Menus/Option_menu.tscn")
	pass 

func _on_quitter_pressed() -> void:
	CustomGameLoop.GetInstance().CloseGame()
	pass # Replace with function body.
