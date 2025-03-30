using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame.NewFolder;


struct Tile
{
    public Rectangle DrawRectangle; // The piece of the tileset image the tiles uses
}

internal class Map
{
    public int Size;
    public int TileSize; // The size of a tile (in pixels)
    public Texture2D Tileset; // The image we'll use as a tileset

    Tile[][] Grid; // 2D array of tiles
    Tile[] FloorTiles; // The list of possible floor tiles

    Random r = new Random();

    // Constructor
    public Map(int Size, Texture2D Tileset)
    {
        this.Size = Size;
        this.Tileset = Tileset;
        TileSize = 16;

        // Every possible floor tile
        FloorTiles = new Tile[4];
        FloorTiles[0] = new Tile();
        FloorTiles[0].DrawRectangle = new Rectangle(224, 16, 16, 16);
        FloorTiles[1] = new Tile();
        FloorTiles[1].DrawRectangle = new Rectangle(240, 16, 16, 16);
        FloorTiles[2] = new Tile();
        FloorTiles[2].DrawRectangle = new Rectangle(224, 32, 16, 16);
        FloorTiles[3] = new Tile();
        FloorTiles[3].DrawRectangle = new Rectangle(240, 32, 16, 16);

        // Generating the map array 
        Grid = new Tile[Size][];

        for (int i = 0; i < Size; i++)
        {
            Grid[i] = new Tile[Size];
            for (int j = 0; j < Size; j++)
            {
                Grid[i][j] = FloorTiles[r.Next(FloorTiles.Length)];
            }
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                spriteBatch.Draw(Tileset, new Rectangle(i * TileSize, j * TileSize, TileSize, TileSize), Grid[i][j].DrawRectangle, Color.White);
            }
        }
    }
}
