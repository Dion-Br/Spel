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
		private Rectangle rectangle, srcRectangle;

		public Rectangle Rectangle
		{
			get { return rectangle; }
			set { rectangle = value; }
		}

        public Rectangle SrcRectangle
        {
            get { return srcRectangle; }
            set { srcRectangle = value; }
        }

        private static ContentManager content;
		public static ContentManager Content
		{
			protected get { return content; }
			set { content = value; }
		}

		public void Draw(SpriteBatch spritebatch)
		{
			spritebatch.Draw(texture, rectangle, srcRectangle, Color.White);
		}
	}

	public class CollisionTiles : Tiles
	{
		public CollisionTiles(int i, Rectangle newRectangle)
		{
			// Hier tile plaatsen
			texture = Content.Load<Texture2D>("tileset");

			// Juiste blok texture
			switch (i)
			{
				// 1 = Cobble met mos
				// 2 = Cobble
				// 3 = Steen
				case 1: this.SrcRectangle = new Rectangle(5 * 64, 2 * 64, 64, 64); break;
				case 2: this.SrcRectangle = new Rectangle(6 * 64, 2 * 64, 64, 64); break;
				case 3: this.SrcRectangle = new Rectangle(6 * 64, 1 * 64, 64, 64); break;
            }
			
			this.Rectangle = newRectangle;
		}
	}
}
