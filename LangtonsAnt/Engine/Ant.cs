using System.Drawing;

namespace LangtonsAnt.Engine {
  public class Ant : Cell {

    #region Private Varaibles

    private Cell forwardDirection;
    private Cell currentLocation;

    #endregion

    #region Constructor

    public Ant(int xPos, int yPos, int aWidth, int aHeight, Cell startLocation) : base(xPos, yPos, aWidth, aHeight) {
      currentLocation = startLocation;
      forwardDirection = currentLocation.NorthCell;
    }

    #endregion

    public Cell Move() {
      Cell newLocation = currentLocation.CellColour == Color.White ?
        Turn90DegreesRight(currentLocation) :
        Turn90DegreesLeft(currentLocation);
      currentLocation = newLocation;
      CellGraphic = new Rectangle(currentLocation.X * Width, currentLocation.Y * Height, Width, Height);
      return newLocation;
    }

    #region Private Methods

    private Cell Turn90DegreesRight(Cell currentLocation) {
      Cell newLocation = null;
      currentLocation.CellColour = Color.Black;
      if (forwardDirection == currentLocation.NorthCell) {
        newLocation = currentLocation.WestCell;
        forwardDirection = newLocation.WestCell;
      }
      else if (forwardDirection == currentLocation.SouthCell) {
        newLocation = currentLocation.EastCell;
        forwardDirection = newLocation.EastCell;
      }
      else if (forwardDirection == currentLocation.EastCell) {
        newLocation = currentLocation.NorthCell;
        forwardDirection = newLocation.NorthCell;
      }
      else if (forwardDirection == currentLocation.WestCell) {
        newLocation = currentLocation.SouthCell;
        forwardDirection = newLocation.SouthCell;
      }
      return newLocation;
    }

    private Cell Turn90DegreesLeft(Cell currentLocation) {
      Cell newLocation = null;
      currentLocation.CellColour = Color.White;
      if (forwardDirection == currentLocation.NorthCell) {
        newLocation = currentLocation.EastCell;
        forwardDirection = newLocation.EastCell;
      }
      else if (forwardDirection == currentLocation.SouthCell) {
        newLocation = currentLocation.WestCell;
        forwardDirection = newLocation.WestCell;
      }
      else if (forwardDirection == currentLocation.EastCell) {
        newLocation = currentLocation.SouthCell;
        forwardDirection = newLocation.SouthCell;
      }
      else if (forwardDirection == currentLocation.WestCell) {
        newLocation = currentLocation.NorthCell;
        forwardDirection = newLocation.NorthCell;
      }
      return newLocation;
    }

    #endregion
  }
}
