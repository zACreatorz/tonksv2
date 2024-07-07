using System;
using System.Windows.Forms;
using System.Drawing;

namespace tanksv2.Interfaces
{
    public interface ILabelMaker
    {
        Point Location { get; set; }
        string PlayerName { get; set; }
        double MaxHp { get; set; }
        double CurrentHp { get; set; }


        void UpdateLabel(Form gameForm, string playername, Point location, double currentHp, double maxHp);
   

    }
			
			
			





		

	
		
}
