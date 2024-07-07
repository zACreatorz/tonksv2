using System;
using System.Drawing;
using System.Windows.Forms;
using tanksv2.Interfaces;


namespace TonksRUs.Classes
{

    public abstract class Units : ILabelMaker
    {
        public Point Location { get; set; }
        public string PlayerName { get; set; }
        public double MaxHp { get; set; }
        public double CurrentHp { get; set; }
        public Image UnitImage { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }

        // Add a property for the Label
        public Label UnitLabel { get; set; } = new Label();

        public abstract void Attack();

        public void UpdateLabel(Form gameForm, string playername, Point location, double currentHp, double maxHp)
        {
            // Check if a label for the object exists
            if (UnitLabel is null)
            {
                // Create a new label for the object
                UnitLabel = new Label();
                UnitLabel.AutoSize = true;
                gameForm.Controls.Add(UnitLabel);
            }
            else
          
            // Update the label with the object's PlayerName, CurrentHp, and MaxHp
            UnitLabel.Text = $"Player: {playername} HP: {currentHp}/{maxHp}";
            UnitLabel.Location = new Point(Location.X, (Location.Y - ImageHeight));
            UnitLabel.BackColor = Color.Transparent;
            UnitLabel.BringToFront();

        }
    }
    public class Ranger : Units
    {


        // Specific properties/methods for Ranger

        public override void Attack()
        {
            // Implementation for Warrior attack
        }


    }
    public class Tank : Units
    {
        // Specific properties/methods for Tank

        public override void Attack()
        {
            // Implementation for Tank attack
        }
    }

   

    public class Warrior : Units
    {
        // Specific properties/methods for Warrior
        public override void Attack()
        {
            // Implementation for Warrior attack
        }
    }

    // Tier 2 Classes
    public class Tier2Tank : Tank
    {
        // Additional properties/methods or overrides for Tier2Tank
    }

    public class Tier2Ranger : Ranger
    {
        // Additional properties/methods or overrides for Tier2Ranger
    }

    public class Tier2Warrior : Warrior
    {
        // Additional properties/methods or overrides for Tier2Warrior
    }
}
