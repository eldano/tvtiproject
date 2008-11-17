using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary.Graphics;

namespace TVTIProject
{
    /// <summary>
    /// Clase principal donde se define como pasar las pantallas y se encarga de dibujar la escena en cada tick.
    /// </summary>
    public class Game
    {
        private Level1 level1;

        private bool enabled = false;

        public Game() {
            Initialize();
            enabled = true;
        }

        public void Draw(float deltaTime) {
            if(enabled) 
                level1.Draw(deltaTime);
        }

        /// <summary>
        /// Inicializa los elementos del juego.
        /// </summary>
        private void Initialize() { 
            level1 = new Level1("");
        }

    }
}
