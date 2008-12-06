using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GorgonLibrary;
using GorgonLibrary.Graphics;
using System.Windows.Forms;

namespace TVTIProject
{
	class PresentationHandler
	{
		#region Variables
		private Sprite CellphoneSprite = null;
		private Image cellphoneImage = null;
		private Sprite optionsSprite = null;
		private Image optionsImage = null;
		private string cellphoneAnimationString = "";
		private string optionsAnimationString = "";
		private bool showOptions = false;

		private int activeOption = 1;
		private string optionDirection = "none";
		#endregion

		#region EventHandlersAndMainForm
		private KeyEventHandler keyDownEventHandler = null;
		private FrameEventHandler drawEventHandler = null;
		private Form1 superForm = null;
		#endregion

		public PresentationHandler(Form1 superForm)
		{
			//guardo la referencia al formulario principal
			this.superForm = superForm;

			//instanciación de los eventHandlers
			this.keyDownEventHandler = new System.Windows.Forms.KeyEventHandler(this.Presentation_OnKeyDown);
			this.drawEventHandler = new FrameEventHandler(this.Presentation_OnFrameBegin);

			this.cellphoneImage = Image.FromFile(@"..\..\Resources\Images\cellphone.png");
			this.CellphoneSprite = Sprite.FromFile(@"..\..\Resources\Sprites\cellphoneImage.gorSprite");
			this.optionsImage = Image.FromFile(@"..\..\Resources\Images\options.png");
			this.optionsSprite = Sprite.FromFile(@"..\..\Resources\Sprites\options.gorSprite");
			this.CellphoneSprite.Animations["fadein"].AnimationStopped += new EventHandler(this.FadeInAnimationStopped);
			this.CellphoneSprite.Animations["wait"].AnimationStopped += new EventHandler(this.WaitAnimationStopped);

			foreach (Animation anim in this.optionsSprite.Animations)
			{
				anim.AnimationStopped += new EventHandler(this.optionsAnimationStopped);
			}
		}

		public void attachToEvents()
		{
			// Evento de empezar a renderizar
			Gorgon.Idle += this.drawEventHandler;
		}

		public void deattachToEvents(Form1 superForm)
		{
			// Evento de apretar una tecla
			superForm.KeyDown -= this.keyDownEventHandler;

			// Evento de empezar a renderizar
			Gorgon.Idle -= this.drawEventHandler;
		}

		private void Presentation_OnFrameBegin(object sender, FrameEventArgs e)
		{
			// Clear the screen.
			Gorgon.Screen.Clear();
			this.CellphoneSprite.Animations[this.cellphoneAnimationString].Advance(e.FrameDeltaTime * 1000.0f);
			this.CellphoneSprite.Draw();
			if (this.showOptions)
			{
				this.drawOptions(e.FrameDeltaTime);
			}
		}

		private void Presentation_OnKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				this.optionDirection = "up";
				this.optionsSprite.Animations["op" + this.activeOption + this.optionDirection].Reset();
				this.optionsSprite.Animations["op" + this.activeOption + this.optionDirection].AnimationState = AnimationState.Playing;
				this.superForm.KeyDown -= this.keyDownEventHandler;
			}
			else if (e.KeyCode == Keys.Down)
			{
				this.optionDirection = "down";
				this.optionsSprite.Animations["op" + this.activeOption + this.optionDirection].Reset();
				this.optionsSprite.Animations["op" + this.activeOption + this.optionDirection].AnimationState = AnimationState.Playing;
				this.superForm.KeyDown -= this.keyDownEventHandler;
			}
			else if (e.KeyCode == Keys.Enter)
			{
				//TODO: ver que opción tengo seleccionada y realizar el pasaje de pantalla
			}
		}

		internal void getReady()
		{
			this.cellphoneAnimationString = "fadein";
			this.CellphoneSprite.Animations[this.cellphoneAnimationString].Reset();
			this.CellphoneSprite.Animations[this.cellphoneAnimationString].AnimationState = AnimationState.Playing;
		}

		private void FadeInAnimationStopped(object sender, EventArgs e)
		{
			this.cellphoneAnimationString = "wait";
			this.CellphoneSprite.Animations[this.cellphoneAnimationString].Reset();
			this.CellphoneSprite.Animations[this.cellphoneAnimationString].AnimationState = AnimationState.Playing;
		}
		private void WaitAnimationStopped(object sender, EventArgs e)
		{
			this.cellphoneAnimationString = "showmenu";
			this.CellphoneSprite.Animations[this.cellphoneAnimationString].Reset();
			this.CellphoneSprite.Animations[this.cellphoneAnimationString].AnimationState = AnimationState.Playing;

			this.superForm.KeyDown += this.keyDownEventHandler;
			this.activeOption = 1;
			this.optionDirection = "none";
			this.optionsSprite.Animations["op" + this.activeOption + this.optionDirection].Reset();
			this.optionsSprite.Animations["op" + this.activeOption + this.optionDirection].AnimationState = AnimationState.Playing;
			this.showOptions = true;
		}

		private void drawOptions(float deltaTime)
		{
			this.optionsSprite.Animations["op" + this.activeOption + this.optionDirection].Advance(deltaTime * 1000.0f);
			this.optionsSprite.Draw();
		}

		private void optionsAnimationStopped(object sender, EventArgs e)
		{
			if (this.optionDirection.ToLower().Equals("up"))
			{
				if (this.activeOption == 1)
				{
					this.activeOption = (this.optionsSprite.Animations.Count - 1) / 2;
				}
				else
				{
					this.activeOption--;
				}
			}
			else if (this.optionDirection.ToLower().Equals("down"))
			{
				if (this.activeOption == (this.optionsSprite.Animations.Count - 1) / 2) //-1 porque hay una opción "op1none" y "/2" porque hay una animación hacia arriba y otra hacia abajo
				{
					this.activeOption = 1;
				}
				else
				{
					this.activeOption++;
				}
			}
			this.superForm.KeyDown += this.keyDownEventHandler;
		}
	}
}
