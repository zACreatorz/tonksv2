using System;
using System.Drawing;
using System.Windows.Forms;
using tanksv2.Interfaces;

public class BaseCastle : ILabelMaker
{
    public Point Location { get; set; }
    public string PlayerName { get; set; }
    public double MaxHp { get; set; } = 1000;
    public double CurrentHp { get; set; } = 100;
    public Image CastleImage { get; set; } = Image.FromFile(@"C:\Users\ACrea\source\repos\tonksv2\tonksv2\Resources\castle.png");
    public int ImageWidth { get; set; } = 128;
    public int ImageHeight { get; set; } = 128;
    public Label CastleLabel { get; set; } = new Label();



    public void UpdateLabel(Form gameForm, string playername, Point location, double currentHp, double maxHp)
    {

        CastleLabel.Text = $"Player: {playername} HP: {currentHp}/{maxHp}";
        CastleLabel.Location = new Point(Location.X, (Location.Y - ImageHeight));
        CastleLabel.BackColor = Color.Transparent;
        CastleLabel.BringToFront();

    }






}
