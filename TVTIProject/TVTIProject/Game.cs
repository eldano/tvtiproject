using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVTIProject
{
    /// <summary>
    /// Clase principal donde se define como pasar las pantallas y se encarga de dibujar la escena en cada tick.
    /// </summary>
    public class Game
    {

        private LinkedList<Screen> screens;
        private Screen activeScreen;

        public Game() {
            initialize();
        }

        public void draw(float deltaTime) { 
            
        }

        private void initialize() { 
            //Inicializo todas los elementos del juego
        }

    }
}
