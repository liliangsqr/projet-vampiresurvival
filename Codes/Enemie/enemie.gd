extends CharacterBody2D

@export var reference_joueur : CharacterBody2D;
var direction : Vector2;
var vitesse : float = 60.0;
var degats : float 
var recul : Vector2
var elite:bool=false:
	set(valeur):
		elite=valeur
		if valeur:
			$Sprite2D.material = load("res://Codes/Enemie/Shaders/Arcenciel.tres")
			scale=Vector2(1.5,1.5)

var type : Ennemi : 
	set(valeur):
		type=valeur;
		$Sprite2D.texture = valeur.texture
		degats = valeur.degat

func _physics_process(delta: float) -> void:
	# a + de 2000 entité le jeux passe en dessous de 5 fps, on optimise 
	var ennemi_distance = (reference_joueur.position-position).length()
	if ennemi_distance >= 500 && not elite: #render distance pour pas accumulation
		queue_free() # probleme ca fait depop les mobs donc on arreter dsn
		
	
	velocity = (reference_joueur.position-position).normalized()*vitesse;
	recul = recul.move_toward(Vector2.ZERO,1); # reduire l'effet visuel des colision entre les ennemies
	velocity += recul;
	move_and_slide();
	
		#direction du sprite en fonction de la position du joueur
	if (reference_joueur.position-position).x > 0.1:
		$Sprite2D.flip_h = true
	elif (reference_joueur.position-position).x < 0.1 : 
		$Sprite2D.flip_h = false 
	
	
