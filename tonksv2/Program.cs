using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using tanksv2.Interfaces;
using TonksRUs.Classes;

namespace tonksv2
{
    // lança o regular form1 que pra ja ignoramos para depois ficar a ser o main screen somehow
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm());
        }
       
    }


    //playable gameform
    public class GameForm : Form
    {
        // The size of the game world
        private Size gameWorldSize = new Size(3000, 3000);
        // The size of the viewport
        private Size viewportSize = new Size(1280, 720);
        // The start position of the viewport in the game world
        private Point viewportPosition = new Point(0, 0);

        private bool IsHoldingDown = false;
        private Point lastMousePosition;

        private Timer gameTimer;

        // private List<Basecastle> castles = new List<Basecastle>();
        // List<ILabelUpdatable> labelUpdatableEntities = new List<ILabelUpdatable>();

        private List<BaseCastle> castles = new List<BaseCastle>();
        private List<Units> units = new List<Units>();


        public GameForm()
        {
            InitializeComponent();
            InitializeGame();
            this.DoubleBuffered = true;
            this.Size = viewportSize;
            this.MouseDown += GameForm_MouseDown;
            this.MouseMove += GameForm_MouseMove;
            this.MouseUp += GameForm_MouseUp;
            
        }

        public void UpdateViewportPosition(Point newPosition)
        {
            // Ensure the viewport's left edge is not less than 0
            int newX = Math.Max(newPosition.X, 0);
            // Ensure the viewport's top edge is not less than 0
            int newY = Math.Max(newPosition.Y, 0);

            // Ensure the viewport's right edge does not exceed the game world's width
            newX = Math.Min(newX, gameWorldSize.Width - viewportSize.Width);
            // Ensure the viewport's bottom edge does not exceed the game world's height
            newY = Math.Min(newY, gameWorldSize.Height - viewportSize.Height);

            // Update the viewport position with the corrected values
            viewportPosition = new Point(newX, newY);

            // Trigger a repaint of the form to reflect the updated viewport position
            this.Invalidate();
        }
        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsHoldingDown = true;
                lastMousePosition = e.Location; // Record the starting point of the drag
            }
        }

        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsHoldingDown)
            {
                // Calculate the difference between the last position and the current mouse position
                Point difference = new Point(e.X - lastMousePosition.X, e.Y - lastMousePosition.Y);

                // Update the viewport position based on the difference
                // Invert the difference to make the drag direction intuitive (dragging mouse left moves viewport right)
                UpdateViewportPosition(new Point(viewportPosition.X - difference.X, viewportPosition.Y - difference.Y));

                lastMousePosition = e.Location; // Update the last position for the next move event
            }
        }

        private void GameForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsHoldingDown = false;
            }
        }

        private void InitializeComponent()
        {
            this.ClientSize = new Size(1280, 720);
            this.Text = "TonksRUs";


        }

        private void InitializeGame()
        {

            gameTimer = new Timer();
            gameTimer.Interval = 16; // about 60 FPS

            BaseCastle player1Castle = new BaseCastle();
            player1Castle.Location = new Point(500, 300);
            player1Castle.PlayerName = "ACreator";
         //   player1Castle.UpdateLabel(this, player1Castle.PlayerName, player1Castle.Location, player1Castle.CurrentHp, player1Castle.MaxHp);
            castles.Add(player1Castle);
           


            BaseCastle player2Castle = new BaseCastle();
            player2Castle.Location = new Point(2500, 300);
            player2Castle.PlayerName = "BadMan";
         //   player2Castle.UpdateLabel(this, player2Castle.PlayerName, player2Castle.Location, player2Castle.CurrentHp, player2Castle.MaxHp);
            castles.Add(player2Castle);




            gameTimer.Tick += GameLoop;      
            gameTimer.Start();
        }




        
void GameLoop(object sender, EventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
              
              
            }
        }

        void DrawCastleLabel(Graphics g, BaseCastle castle)
        {
            // Calculate the adjusted position for the castle
            int adjustedX = castle.Location.X - viewportPosition.X;
            int adjustedY = castle.Location.Y - viewportPosition.Y;

            // Assuming the label should appear just above the castle
            Point labelPosition = new Point(adjustedX, adjustedY + castle.ImageHeight); 

            // Draw the label
            if (castle.CastleLabel != null)
            {
                castle.UpdateLabel(this, castle.PlayerName, castle.Location, castle.CurrentHp, castle.MaxHp);
                g.DrawString(castle.CastleLabel.Text, this.Font, Brushes.Black, labelPosition);
            }
            
        }

        void DrawUnitsLabel(Graphics g, Units units)
        {
            // Calculate the adjusted position for the castle
            int adjustedX = units.Location.X - viewportPosition.X;
            int adjustedY = units.Location.Y - viewportPosition.Y;

            // Assuming the label should appear just above the castle
            Point labelPosition = new Point(adjustedX, adjustedY - units.ImageHeight); 

            // Draw the label
            g.DrawString(units.UnitLabel.Text, this.Font, Brushes.Black, labelPosition);
        }







        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // Call the base class method to ensure standard painting operations are performed

            Graphics g = e.Graphics; // Use the Graphics object provided by PaintEventArgs

            foreach (BaseCastle castle in castles)
            {
                if (castles.Count > 0)
                {
                    // Adjust castle location based on the viewport position
                    int adjustedX = castle.Location.X - viewportPosition.X;
                    int adjustedY = castle.Location.Y - viewportPosition.Y;
                    g.DrawImage(castle.CastleImage, adjustedX, adjustedY, castle.ImageWidth, castle.ImageHeight);
                    DrawCastleLabel(g, castle);
                   
                }
            }
            foreach (Units unit in units)
            {
                if (units.Count > 0)
                {
                    // Adjust castle location based on the viewport position
                    int adjustedX = unit.Location.X - viewportPosition.X;
                    int adjustedY = unit.Location.Y - viewportPosition.Y;          
                    g.DrawImage(unit.UnitImage, adjustedX, adjustedY, unit.ImageWidth, unit.ImageHeight);
                    DrawUnitsLabel(g, unit);
                  
                }
            }






        }

 








    }

}
