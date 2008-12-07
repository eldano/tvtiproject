using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;
using GorgonLibrary.Graphics;

namespace TVTIProject
{
    public class Level1
    {
        /// <summary>
        /// Representa el grafo de escena.
        /// </summary>
        private LinkedList<SceneNode> nodes;
        
        private Character character;
        
        private Image background;

        /// <summary>
        /// Offset para mover la pantalla y los elementos.
        /// El personaje debería permanecer siempre entre el 1er cuarto de la pantalla (200) y la mitad (400).
        /// </summary>
        public int offsetX = 0;

        public Level1(string backgroundPath) {
            this.background = Image.FromFile("..\\..\\fondo1.PNG");
            nodes = new LinkedList<SceneNode>();
            Initialize();

            _screen = new RenderImage("Screen", 800, 600, ImageBufferFormats.BufferRGB888A8, false, false);
            blitter = new Sprite("Blitter", _screen);            
        }

        private RenderImage _screen;
        private Sprite blitter;


        int blittingOffset = 0;
        int blittingLimit = 200;
        /// <summary>
        /// Ajusta el blitter para que el personaje no se pase del 1º cuarto de la pantalla
        /// </summary>
        private void AjustarBlitter() {
            if (character.Position.X - blittingOffset > blittingLimit) {
                blittingOffset++;
                blitter.Position = new Vector2D(-blittingOffset, 0);
            }
            blitter.Draw();
        }
        

        public void Draw(float deltaTime) {
            _screen.Clear();
            _screen.BeginDrawing();

            background.Blit();
            character.Draw(deltaTime);
            foreach (SceneNode node in nodes) {
                node.Draw(deltaTime);
            }
            
            _screen.EndDrawing();

            AjustarBlitter();
        }

        /// <summary>
        /// Inicializo los elementos del nivel
        /// </summary>
        private void Initialize() {
            Image.FromFile(@"..\..\Resources\Sprites\spritesv0.bmp");

            Sprite spriteNode1 = Sprite.FromFile(@"..\..\Resources\Sprites\turningNode.gorSprite");
            Sprite spriteNode2 = Sprite.FromFile(@"..\..\Resources\Sprites\turningNode.gorSprite");
            Sprite spriteNode3 = Sprite.FromFile(@"..\..\Resources\Sprites\turningNode.gorSprite");
            Sprite spriteNode4 = Sprite.FromFile(@"..\..\Resources\Sprites\turningNode.gorSprite");

            Sprite spriteCharacter = Sprite.FromFile(@"..\..\Resources\Sprites\character.gorSprite");

            TurningNode node1 = new TurningNode(new Vector2D(300, 300), spriteNode1);
            node1.addPossibleTurningDirection(Direction.south);
            nodes.AddLast(node1);

            TurningNode node2 = new TurningNode(new Vector2D(200, 400), spriteNode2);
            node2.addPossibleTurningDirection(Direction.east);
            nodes.AddLast(node2);

            TurningNode node3 = new TurningNode(new Vector2D(300, 400), spriteNode3);
            node3.addPossibleTurningDirection(Direction.north);
            nodes.AddLast(node3);

            TurningNode node4 = new TurningNode(new Vector2D(400, 300), spriteNode4);
            node4.addPossibleTurningDirection(Direction.east);
            nodes.AddLast(node4);

            node1.NeighborNodes[Direction.south] = node2;
            node2.NeighborNodes[Direction.east] = node3;
            node3.NeighborNodes[Direction.north] = node4;

            this.character = new Character(spriteCharacter);
            this.character.Position = new Vector2D(100, 300);

            this.character.NodeDest = node1;
            
        }

    }
}
