extends Control

func _on_reesayer_pressed() -> void:
	CustomGameLoop.GetInstance().GetLevelManager().LoadLevel("res://Codes/world.tscn")
	CustomGameLoop.GetInstance().GetLevelManager().SwitchPauseLevel();

func _on_menu_principal_pressed() -> void:
	CustomGameLoop.GetInstance().GetLevelManager().LoadLevel("res://Codes/Menus/MenuPrincipal.tscn")
	CustomGameLoop.GetInstance().GetLevelManager().SwitchPauseLevel();

func _on_quitter_pressed() -> void:
	get_tree().quit()
