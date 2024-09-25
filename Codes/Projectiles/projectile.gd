extends Area2D


var vitesse : float = 200;
@export var degat = 1:
	set(valeur):
		degat=valeur
		
var direction : Vector2 = Vector2.RIGHT:
	set(valeur):
		direction =valeur;
		rotation = direction.angle();

func _physics_process(delta: float) -> void:
	position += vitesse*direction*delta;
	
func Lancer_animation(nom_animation = "simple"):
	$AnimatedSprite2D.play(nom_animation);

func _on_visible_on_screen_notifier_2d_screen_exited() -> void:
	Detruire();
	
func Detruire():
	queue_free()


func _on_area_entered(area: Area2D,i=0) -> void:
	#detruire l'objet 
	pass
	
func _on_body_entered(body: Node2D,i=0) -> void:
	pass
	
