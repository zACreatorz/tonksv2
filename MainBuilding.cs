using System;
using System.Drawing;
using System.Windows.Forms;
using tanksv2.Interfaces;




public class BaseCastle : ILabelMaker
{
    public BaseCastle()
    {
    public Point Location { get; set; }
    public string PlayerName { g et; set; }
    public double CurrentHp = 100;
    public double MaxHp { get; set; } = 1000;
    public double CurrentHp { get; set; } = 1000;
    public Image CastleImage { get; set; } = Image.FromFile(@"C:\Users\ACrea\source\repos\TonksRUs\TonksRUs\Resources\castle.png");
    public int ImageWidth { get; set; } = 128;
    public int ImageHeight { get; set; } = 128;


    public BaseCastle()
    {

    }

    // Hypothetical implementation of ILabelMaker's required method
    public string UpdateLabel()
    {

    }


}






}
