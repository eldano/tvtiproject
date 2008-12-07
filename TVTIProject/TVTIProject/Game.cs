using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary.Graphics;
using GorgonLibrary.InputDevices;

namespace TVTIProject
{
    /// <summary>
    /// Clase principal donde se define como pasar las pantallas y se encarga de dibujar la escena en cada tick.
    /// </summary>
    public class Game
    {
        private Level1 level1;

        private bool enabled = false;

        /// <summary>
        /// 
        /// </summary>
        private Mouse mouse;
        private Input input;

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

            //Inicializo el mouse

            // Load the input devices plug-in.
            input = Input.LoadInputPlugIn(@"..\..\Resources\Libraries\GorgonInput.dll", "Gorgon.RawInput");

            // Bind the devices to this window.
            input.Bind(Program.form);

            mouse = input.Mouse;
            mouse.Enabled = true;
            mouse.Exclusive = false;
            mouse.MouseUp += new MouseInputEvent(MouseEvent);

            level1 = new Level1("");
        }

        /// <summary>
        /// Handles any mouse input.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GorgonLibrary.InputDevices.MouseInputEventArgs"/> instance containing the event data.</param>
        private void MouseEvent(object sender, MouseInputEventArgs e)
        {
            if ((e.Buttons & GorgonLibrary.InputDevices.MouseButtons.Button1) == GorgonLibrary.InputDevices.MouseButtons.Button1)
            {
                level1.click(e.Position);
            }
        }
    }
}
