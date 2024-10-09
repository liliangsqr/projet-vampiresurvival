extends Control




func _on_retour_pressed() -> void:
	CustomGameLoop.GetInstance().GetLevelManager().LoadLevel("res://Codes/Menus/MenuPrincipal.tscn")
