using System.Drawing;

namespace LangtonsAnt.Engine {

  public class Cell {

    #region Private Variables    
    #endregion

    #region Constructor

    public Cell(int xPos, int yPos, int aWidth, int aHeight) {
      CellColour = Color.White;
      Width = aWidth;
      Height = aHeight;
      X = xPos;
      Y = yPos;
      CellGraphic = new Rectangle(X * Width, Y * Height, Width, Height);
    }

    #endregion

    #region Properties

    public int X { get; set; }
    public int Y { get; set; }
    public Cell NorthCell { get; set; }
    public Cell SouthCell { get; set; }
    public Cell EastCell { get; set; }
    public Cell WestCell { get; set; }
    public Color CellColour { get; set; }
    public Rectangle CellGraphic { get; protected set;}
    public int Width { get; private set; }
    public int Height { get; private set; }

    #endregion
  }
}
