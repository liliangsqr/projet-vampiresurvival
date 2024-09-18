extends HBoxContainer

var case : Array
var capacites : Array = [Tir_Simple,Tir_Multiple,Tir_Zone]

func _ready() -> void:
	case = get_children()
	#for child in get_child_count():
		#case[child].change_key = str(child+1)
		#case[child].competence = capacites[child].new(case[child])
	
	case[0].change_key = "A"
	case[0].competence = capacites[0].new(case[0])
	case[1].change_key = "E"
	case[1].competence = capacites[1].new(case[1])
	case[2].change_key = "R"
	case[2].competence = capacites[2].new(case[2])
