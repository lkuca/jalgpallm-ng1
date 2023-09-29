namespace jalgpallmäng
{
    public class Build
    {
        public Build() { }
        
        public void Draw(int x, int y, string sym)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        public void Drawdirection(int x, int y, int dire, int times, string sym)
        {
            int i = 0;

            while (i < times)
            {
                if (dire == 2)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(sym + "");
                    x++;
                }
                if (dire == 3)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(sym + "");
                    y++;
                }
            }
            i++;

        }
        public void SetPlayer(double x, double y, string sym)
        { 
            int a = Convert.ToInt32(x);
            int b = Convert.ToInt32(y);
            Draw(a, b, sym);
        }
        
    }
}