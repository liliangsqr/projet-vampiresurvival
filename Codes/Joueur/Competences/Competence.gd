extends Resource
class_name Competence

var cooldown : float
var texture : Texture2D
var nom_animation: String
var degats = 1;

func _init(cible) -> void:
	cible.cooldown.max_value = cooldown
	cible.texture_normal = texture
	cible.timer.wait_time = cooldown
	
func Lancer_Competence(cible):
	print(nom_animation + "Lance le sort"+ cible.name)
