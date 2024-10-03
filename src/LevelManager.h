#ifndef LEVEL_MANAGER_H
#define LEVEL_MANAGER_H

#include <godot_cpp/classes/CustomMainLoop>

namespace godot {

	class LevelManager : public CustomMainLoop {


    private : 
        
        double _timeElapsed = 0;

    public :

        void _Initialize();

        bool _Process(double delta);

        void _Finalize();

	};
}

#endif