using System;
using System.Windows.Forms;

namespace XYZ_Teleport_1._17._0
{
    public partial class Form1 : Form
    {
        public static Form1 handle;
        public Mem mem;
        public Form1()
        {
            InitializeComponent();
            handle = this;
            mem = new Mem();
        }

        public static string[] SPL_Compass = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mem != null) // check if mc is open then attach if its not already
            {
                if (mem.theProc == null || mem.theProc.HasExited)
                {
                    try
                    {
                        mem.OpenProcess(mem.GetProcIdFromName("Minecraft.Windows.exe"));
                    }
                    catch { }
                }
                else
                {
                    string newDa = "";
                    label1.Text = Game.Camera.ToString() + "\n" +
                        DegreesToCardinal(Game.Camera.x + 180) + "\n" +
                        DegreesToCardinalDetailed(Game.Camera.x + 180);
                }
            }
        }

        public static string DegreesToCardinal(double degrees) // Thanks https://gist.github.com/adrianstevens/8163205 i just learned my method sucks ;p
        {
            string[] caridnals = { "N", "NE", "E", "SE", "S", "SW", "W", "NW", "N" };
            return caridnals[(int)Math.Round(((double)degrees % 360) / 45)];
        }

        public static string DegreesToCardinalDetailed(double degrees)
        {
            string[] caridnals = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
            return caridnals[(int)Math.Round(((double)degrees * 10 % 3600) / 225)];
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
