extends Control

func _on_continuer_pressed() -> void:
	hide() #Cache le menu 
	CustomGameLoop.GetInstance().GetLevelManager().SwitchPauseLevel(); #Unpause le jeu
	
func _on_option_pressed() -> void:
	CustomGameLoop.GetInstance().GetLevelManager().SwitchPauseLevel(); #Unpause le jeu
	CustomGameLoop.GetInstance().GetLevelManager().LoadLevel("res://Codes/Menus/Option_menu.tscn")

func _on_menu_principal_pressed() -> void:
	CustomGameLoop.GetInstance().GetLevelManager().SwitchPauseLevel();  #Unpause le jeu
	CustomGameLoop.GetInstance().GetLevelManager().LoadLevel("res://Codes/Menus/MenuPrincipal.tscn")

func _on_quitter_pressed() -> void:
	CustomGameLoop.GetInstance().CloseGame()

func _on_saugarder_quitter_pressed() -> void:
	#fonction qui sauvegarde 
	CustomGameLoop.GetInstance().GetSaveManager().save("res://save/save.json")
	CustomGameLoop.GetInstance().CloseGame()
	
