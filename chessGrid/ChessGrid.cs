namespace chessgrid{
    public class ChessGrid
    {
        public Position[,] Grid{get;}

        public const int MatrixLength = 8;

        public ChessGrid()
        {
            Grid = new Position[8,8];

            for(int i=0; i< MatrixLength; i++){
                 for(int j=0; j< MatrixLength; j++){
                     Grid[i,j] = new Position(i,j);
                }
            }
        }
    }
}