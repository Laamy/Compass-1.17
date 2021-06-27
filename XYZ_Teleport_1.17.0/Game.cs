using System;

namespace XYZ_Teleport_1._17._0
{
    class Game
    {
        public static string localPlayer = "base+04020228,0,18,B8,";
        public static string localPlayer_CCamera = "140";

        public static Vec2 Camera
        { 
            get => new Vec2(Form1.handle.mem.ReadFloat(localPlayer + HexHandler.ath(localPlayer_CCamera, 4)) + "," +
                Form1.handle.mem.ReadFloat(localPlayer + HexHandler.ath(localPlayer_CCamera, 0)));
        }
    }

    public class Vec2
    {
        public float x;
        public float y;
        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vec2(string position)
        {
            try
            {
                string[] parsedStr = position.Replace(" ", "").Split(',');
                this.x = Convert.ToSingle(parsedStr[0]);
                this.y = Convert.ToSingle(parsedStr[1]);
            }
            catch
            {
                string[] parsedStr = position.Replace(" ", "").Split(',');
                this.x = HexHandler._toInt(parsedStr[0]);
                this.y = HexHandler._toInt(parsedStr[1]);
            }
        }
        public override string ToString()
        {
            return x + "," + y;
        }
    }
}
