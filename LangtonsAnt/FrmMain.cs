using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LangtonsAnt.Engine;

namespace LangtonsAnt {
  public partial class FrmMain : Form {
    
    #region Private Variables

    private BackgroundWorker bgWorker;
    private bool invokeClose;
    private World world;

    #endregion

    public FrmMain() {
      InitializeComponent();
      this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
      this.UpdateStyles();
      int size = 100;
      world = new World(size, Width / size, Height / size);
      bgWorker = new BackgroundWorker();
      bgWorker.DoWork += bgWorker_DoWork;
      bgWorker.WorkerSupportsCancellation = true;
      bgWorker.RunWorkerAsync();
      invokeClose = false;
      FormClosing += FrmMain_FormClosing;
    }

    void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
      bgWorker.CancelAsync();
      invokeClose = true;
    }

    void bgWorker_DoWork(object sender, DoWorkEventArgs e) {
      while (!bgWorker.CancellationPending) {        
        Bitmap BackBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        Graphics g = Graphics.FromImage(BackBuffer);
        world.MoveAnt();
        world.Draw(g);
        Graphics Viewable = CreateGraphics();
        Viewable.DrawImageUnscaled(BackBuffer, 0, 0);
        System.Threading.Thread.Sleep(1);
      }
    }
  }
}
