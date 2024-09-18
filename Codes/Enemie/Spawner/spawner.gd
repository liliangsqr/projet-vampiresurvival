extends Node2D

@export var reference_joueur : CharacterBody2D; # --> 
@export var reference_ennemi : PackedScene; # -->
@export var type_ennemis:Array[Ennemi] # --> voir sur le coté ce qu'il y a dedans

var distance : float = 400;
var peut_apparaitre:bool = true;

var minutes :int : 
	set(valeur):
		minutes=valeur;
		$"%Minutes".text= str(valeur);

var secondes :int : 
	set(valeur):
		secondes=valeur
		if secondes >=10:
			secondes -= 10;
			minutes +=1;
		$"%Secondes".text= str(secondes).lpad(2,'0');
		
func _physics_process(_delta: float) -> void:
	if get_tree().get_node_count_in_group("Ennemi")< 300:
		peut_apparaitre = true;
	else:
		peut_apparaitre =false;
		
	
func Apparition(localisation : Vector2,elite :bool= false) :
	if not peut_apparaitre and not elite:
		return
	var new_ennemi = reference_ennemi.instantiate();
	new_ennemi.type = type_ennemis[min(minutes,type_ennemis.size()-1)] # change dennemy toutes les minutes
	new_ennemi.position = localisation;
	new_ennemi.reference_joueur= reference_joueur;
	new_ennemi.elite=elite;
	get_tree().current_scene.add_child(new_ennemi);

func Localisation_aleatoire()-> Vector2:
	return reference_joueur.position + distance * Vector2.RIGHT.rotated(randf_range(0,2*PI))

func Nombre_spawnable(nombre:int = 1):
	for ajouter in nombre:
		Apparition(Localisation_aleatoire())

func _on_timer_timeout() -> void: #timer nommé "TIMER"
	secondes +=1
	Nombre_spawnable(secondes%10) # augmentation du nombre de spawn par seconde 

func _on_patern_timeout() -> void:
	for i in range(75):
		Apparition(Localisation_aleatoire())

func _on_elite_timeout() -> void:
	Apparition(Localisation_aleatoire(),true)
