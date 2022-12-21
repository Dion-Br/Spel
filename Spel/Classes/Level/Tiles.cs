using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel.Classes.Level
{
    // Bron: https://www.youtube.com/watch?v=PKlHcxFAEk0
    public class Tiles
    {
        protected Texture2D texture;

		private Rectangle rectangle;
		public Rectangle Rectangle
		{
			get { return rectangle; }
			set { rectangle = value; }
		}

		private static ContentManager content;
		public static ContentManager Content
		{
			protected get { return content; }
			set { content = value; }
		}

		public void Draw(SpriteBatch spritebatch)
		{
			spritebatch.Draw(texture, rectangle, Color.White);
		}
	}

	public class CollisionTiles : Tiles
	{
		public CollisionTiles(int i, Rectangle newRectangle)
		{
			// Hier tile plaatsen
			texture = Content.Load<Texture2D>("Tile" + i);
			this.Rectangle = newRectangle;
		}
	}
}
