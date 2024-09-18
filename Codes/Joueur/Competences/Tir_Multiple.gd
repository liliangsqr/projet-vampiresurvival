extends Competence
class_name Tir_Multiple

func _init(cible) -> void:
	cooldown = 3.0
	nom_animation = "multiple"
	texture = preload("res://Textures/Projectile/icon multishot.png")
	super._init(cible)

func Lancer_Competence(cible):
	super.Lancer_Competence(cible)
	cible.tir_multiple(10,0.4,nom_animation)
	

	
