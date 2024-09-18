extends CharacterBody2D

@onready var vitesse : float = 120
@onready var PV: int = 100:
	set(valeur):
		PV=valeur
		%Bare_vie.value = valeur
		
@onready var colision2D = $CollisionShape2D
@onready var anim2D = $AnimatedSprite2D

func _physics_process(_delta):
	Animation_joueur(Deplacement_joueur());

#region DEPLACEMENT & ANIMATION
func Deplacement_joueur() -> Vector2: 
	# le mouvement sur l'axe des X
	var deplacementX = Input.get_action_strength("droite") - Input.get_action_strength("gauche"); #input en forme de string c'est degeulasse
	# le mouvement sur l'axe des Y
	var deplacementY = Input.get_action_strength("bas") - Input.get_action_strength("haut");
	# Le vecteur de mouvement (X,Y)
	return Vector2(deplacementX,deplacementY);
	
func Animation_joueur(mouvement:Vector2):
	# Mouvement du personnage pdirection
	if mouvement == Vector2.ZERO:
		anim2D.play("statique");
	else : 
		anim2D.play("mouvement");
	
	if mouvement.x > 0 : 
		anim2D.flip_h = false;
		anim2D.play("mouvement");
	elif mouvement.x < 0  :
		anim2D.flip_h = true ;
		anim2D.play("mouvement");
			
	velocity = mouvement.normalized()*vitesse; #normalized-> vitesse constante meme en diagonale
	move_and_slide();
#endregion DEPLACEMENT & ANIMATION

func Prendre_degat(nombre):
	PV-=nombre;
	print(PV);

func _on_domages_subit_body_entered(body: Node2D) -> void:
	Prendre_degat(body.degats) # ou degat

func _on_timer_timeout() -> void:
	%CollisionShape2D.set_deferred("desibles",true)
	%CollisionShape2D.set_deferred("desibles",false)

#region PROJECTILE 
@export var objet_projectile : PackedScene

func tir_simple(nom_animation = "simple"):
	var new_projectile = objet_projectile.instantiate();
	new_projectile.Lancer_animation(nom_animation);
	new_projectile.position = global_position
	new_projectile.direction = (get_global_mouse_position()-global_position).normalized();
	get_tree().current_scene.call_deferred("add_child",new_projectile);

func tir_multiple(effectif:int=3,delai :float =0.2,nom_animation = "multiple"):
	for tir in range(effectif):
		tir_simple(nom_animation)
		await get_tree().create_timer(delai).timeout;

func angleDeTir(angle,i):
	var new_projectile = objet_projectile.instantiate();
	if i%2==0:
		new_projectile.Lancer_animation("multiple");
	else:
		new_projectile.Lancer_animation("zone");
	
	new_projectile.position = global_position
	new_projectile.direction = Vector2(cos(angle),sin(angle));
	get_tree().current_scene.call_deferred("add_child",new_projectile)
	
func tir_zone(effectif):
	for i in range(effectif):
		angleDeTir((float(i)/effectif)*2.0*PI,i)	

#func _ready() -> void:
#	await get_tree().create_timer(1).timeout
#	tir_simple();
#	await get_tree().create_timer(1).timeout
#	tir_multiple();
#	await get_tree().create_timer(1).timeout
#	tir_zone(18);
	
#endregion PROJECTILE 
