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
        private Sprite zeroWalkingSprite = null;
        private Image zeroImage = null;
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
            if (e.KeyCode == Keys.M)
            {
                this.zeroWalkingSprite.Animations["walk"].Reset();

            }
        }

        /// <summary>
        /// Handles the OnFrameBegin event of the Screen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GorgonLibrary.FrameEventArgs"/> instance containing the event data.</param>
        private void Screen_OnFrameBegin(object sender, FrameEventArgs e)
        {
            // Clear the screen.
            Gorgon.Screen.Clear();


            this.zeroWalkingSprite.Animations["walk"].Advance(e.FrameDeltaTime * 1000.0f);
            this.zeroWalkingSprite.Draw();
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
        /// Function to provide initialization for our example.
        /// </summary>
        private void Initialize()
        {
            this.zeroImage = Image.FromFile(@"..\..\Resources\Images\zerox4sheet.png");
            this.zeroWalkingSprite = Sprite.FromFile(@"..\..\Resources\Sprites\walk.gorSprite");
            //this.zeroImage = Image.FromFile(@"Resources\Images\zerox4sheet.png");
            //this.zeroWalkingSprite = Sprite.FromFile(@"Resources\Sprites\walk.gorSprite");

            this.zeroWalkingSprite.Animations["walk"].AnimationState = AnimationState.Playing;
            this.zeroWalkingSprite.Position = new Vector2D(135f, 200f);
            
        }

        
        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize the library.
                Gorgon.Initialize();

                // No muestra el logo ni las stats
                Gorgon.LogoVisible = false;
                Gorgon.FrameStatsVisible = false;

                // Set the video mode to match the form client area.
                // Set the video mode to match the form client area.
                Gorgon.SetMode(this, Constantes.resWidth, Constantes.resHeight, BackBufferFormats.BufferRGB888, true);

                // Assign rendering event handler.
                Gorgon.Idle += new FrameEventHandler(Screen_OnFrameBegin);

                //inicializaciones
                Initialize();


                // Set the clear color to something ugly.
                Gorgon.Screen.BackgroundColor = Drawing.Color.LightGray;


                Song.PlaySong("city");

                // Begin execution.
                Gorgon.Go();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "An unhandled error occured during execution, the program will now close.", ex.Message + "\n\n" + ex.StackTrace);
                Application.Exit();
            }
        }
        #endregion


        public Form1()
        {
            InitializeComponent();
        }


        private void onClick(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                MouseEventArgs clickArgs = (MouseEventArgs)e;
                this.zeroWalkingSprite.Position = new Vector2D(clickArgs.Location);
            }
        }
    }
}
