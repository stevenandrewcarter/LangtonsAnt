
using System.Drawing;
using System.Drawing.Drawing2D;
namespace LangtonsAnt.Engine {
  public class World {
    #region Private Variables
    private Cell[,] cells;
    private Ant ant;
    private int size;
    #endregion

    #region Constructor

    public World(int aSize, int cellWidth, int cellHeight) {      
      size = aSize;
      cells = new Cell[size, size];
      for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
          cells[i, j] = new Cell(i, j, cellWidth, cellHeight);
        }
      }
      for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
          cells[i, j].NorthCell = i == 0 ? cells[size - 1, j] : cells[i - 1, j];
          cells[i, j].SouthCell = i == size - 1 ? cells[0, j] : cells[i + 1, j];
          cells[i, j].EastCell = j == 0 ? cells[i, size - 1] : cells[i, j - 1];
          cells[i, j].WestCell = j == size - 1 ? cells[i, 0] : cells[i, j + 1];
        }
      }
      ant = new Ant(size / 2, size / 2, cellWidth, cellHeight, cells[size / 2, size / 2]);
    }

    #endregion

    #region Public Methods

    public void MoveAnt() {
      ant.Move();
    }

    public void Draw(Graphics g) {
      g.Clear(Color.White);
      for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
          Cell cell = cells[i, j];
          LinearGradientBrush cellBrush = new LinearGradientBrush(cell.CellGraphic, cell.CellColour, cell.CellColour, LinearGradientMode.BackwardDiagonal);
          g.FillRectangle(cellBrush, cell.CellGraphic);
        }
      }
      LinearGradientBrush antBrush = new LinearGradientBrush(ant.CellGraphic, Color.Blue, Color.Green, LinearGradientMode.BackwardDiagonal);
      g.FillRectangle(antBrush, ant.CellGraphic);
    }

    #endregion
  }
}
