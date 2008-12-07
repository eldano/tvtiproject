using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Drawing = System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GorgonLibrary;
using GorgonLibrary.Graphics;

namespace TVTIProject
{
    public partial class Form1 : Form
    {
        #region Variables
        private Game game;
        #endregion

        #region Methods.
        /// <summary>
        /// Handles the KeyDown event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            if (e.KeyCode == Keys.S)
                Gorgon.FrameStatsVisible = !Gorgon.FrameStatsVisible;
        }

        /// <summary>
        /// Handles the OnFrameBegin event of the Level1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GorgonLibrary.FrameEventArgs"/> instance containing the event data.</param>
        private void Screen_OnFrameBegin(object sender, FrameEventArgs e)
        {
            // Clear the screen.
            Gorgon.Screen.Clear();
            game.Draw(e.FrameDeltaTime * 1000.0f);
        }

        /// <summary>
        /// Handles the FormClosing event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Perform clean up.
            Gorgon.Terminate();
        }
        
        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            /*try
            {*/
                // Initialize the library.
                Gorgon.Initialize();

                // No muestra el logo ni las stats
                Gorgon.LogoVisible = false;
                Gorgon.FrameStatsVisible = false;

                // Set the video mode to match the form client area.
                Gorgon.SetMode(this, Constantes.resWidth, Constantes.resHeight, BackBufferFormats.BufferRGB888, true);

                // Assign rendering event handler.
                Gorgon.Idle += new FrameEventHandler(Screen_OnFrameBegin);

                // Set the clear color to something ugly.
                Gorgon.Screen.BackgroundColor = Drawing.Color.LightGray;

                //inicializaciones
                game = new Game();

                Sound.init();
                Song.PlaySong("ciudad");

                //Sound.PlaySound("city");
                // Begin execution.
                Gorgon.Go();
            /*}
            catch (Exception ex)
            {
                MessageBox.Show(this, "An unhandled error occured during execution, the program will now close.", ex.Message + "\n\n" + ex.StackTrace);
                Application.Exit();
            }*/
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }
    }
}
