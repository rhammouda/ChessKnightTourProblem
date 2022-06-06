namespace chessgrid
{
    public class Position 
    {
        char[] columnNames = new char[]{'a', 'b', 'c','d','e','f','g','h'};
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X {get;set;}
        public int Y {get;set;}

        public override string ToString()
        {
            return $"{columnNames[X]}{Y+1}";
        }
    }
}
