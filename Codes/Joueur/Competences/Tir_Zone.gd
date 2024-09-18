extends Competence
class_name Tir_Zone

func _init(cible) -> void:
	cooldown = 5.0
	nom_animation = "zone"
	texture = preload("res://Textures/Projectile/icon zoneshot.png")
	super._init(cible)

func Lancer_Competence(cible):
	super.Lancer_Competence(cible)
	cible.tir_zone(18)
	

	
