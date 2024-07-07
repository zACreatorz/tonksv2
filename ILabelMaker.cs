using System;
using System.Windows.Forms;
using System.Drawing;

namespace tanksv2.Interfaces
{
    public interface ILabelMaker
    {
        void UpdateLabel(string playerName, double currentHp, Point location, int imageHeight)
        {
            Label label;
            if (label == null)
            {
                label = new Label();
                label.Text = playerName + "\n" + currentHp;
                label.Location = location;
                label.AutoSize = true;
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.White;
                label.Font = new Font("Arial", 12);
               
            }
            else
            {
                label.Text = playerName + "\n" + currentHp;
                label.Location = location;
                label.AutoSize = true;
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.White;
                label.Font = new Font("Arial", 12);
                
              
            }
        }

    }
			
			
			





		

	
		
}
