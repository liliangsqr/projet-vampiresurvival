extends Competence
class_name Tir_Simple

func _init(cible) -> void:
	cooldown = 1.0
	nom_animation = "simple"
	texture = preload("res://Textures/Projectile/icon simpleshot.png")
	super._init(cible)

func Lancer_Competence(cible):
	super.Lancer_Competence(cible)
	cible.tir_simple()
	

	
