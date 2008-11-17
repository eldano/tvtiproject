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
        
        public Level1(string backgroundPath) {
            //this.background = Image.FromFile("backgroundPath");
            nodes = new LinkedList<SceneNode>();
            Initialize();
        }

        public void Draw(float deltaTime) {
            //background.Blit();

            character.Draw(deltaTime);

            foreach (SceneNode node in nodes) {
                node.Draw(deltaTime);
            }
        }

        /// <summary>
        /// Inicializo los elementos del nivel
        /// </summary>
        private void Initialize() {
            Sprite spriteNode1 = new Sprite("..\\..\\Resources\\Sprites\\turningNodeSprite.gorSprite");
            Sprite spriteNode2 = new Sprite("..\\..\\Resources\\Sprites\\turningNodeSprite.gorSprite");
            Sprite spriteNode3 = new Sprite("..\\..\\Resources\\Sprites\\turningNodeSprite.gorSprite");
            Sprite spriteNode4 = new Sprite("..\\..\\Resources\\Sprites\\turningNodeSprite.gorSprite");

            Sprite spriteCharacter = new Sprite("..\\..\\Resources\\Sprites\\characterSprite.gorSprite");

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
