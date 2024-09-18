extends Area2D

var vitesse : float = 200;
var direction : Vector2 = Vector2.RIGHT:
	set(valeur):
		direction =valeur;
		rotation = direction.angle();

func _physics_process(delta: float) -> void:
	position += vitesse*direction*delta;
	
func Lancer_animation(nom_animation = "simple"):
	$AnimatedSprite2D.play(nom_animation);

func _on_visible_on_screen_notifier_2d_screen_exited() -> void:
	queue_free();
	
