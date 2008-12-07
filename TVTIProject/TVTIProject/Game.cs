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

        private const float fps = 30.0f;
        private float ticks = 0;

        public void Draw(float deltaTime) {
            ticks += deltaTime;
            if (ticks >= 1.0f / fps) {
                if (enabled)
                {
                    level1.Draw(deltaTime);
                }
                ticks = 0;
            }
        }

        /// <summary>
        /// Inicializa los elementos del juego.
        /// </summary>
        private void Initialize() { 
            level1 = new Level1("");
        }

    }
}
