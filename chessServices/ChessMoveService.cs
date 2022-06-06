using chessgrid;

namespace chessServices
{
    public class ChessMoveService
    {
        private ChessGrid chessGrid;
        public ChessMoveService(ChessGrid chessGrid)
        {
            this.chessGrid = chessGrid;
        }

        public IEnumerable<Position> GetPossibleMoves(ChessPiece piece){
            if(piece == null || piece.Position == null){
                throw new InvalidOperationException("Piece is not in the grid ");
            }

            switch(piece.ChessPieceType){
                case ChessPieceType.Knight:
                    return GetKnightPossibleMoves(piece.Position);
                default:
                    return Enumerable.Empty<Position>();
            }
        }


        /// <summary>
        /// orders should not be changed, 
        /// from https://www.geeksforgeeks.org/the-knights-tour-problem-backtracking-1/
        /// They will affect the running time of the algorithm drastically
        /// </summary>
        int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
		int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

        private IEnumerable<Position> GetKnightPossibleMoves(Position position)
        {
           
            for(int i=0; i<8; i++){
                if(IsInGrid(position.X +xMove[i], position.Y +yMove[i]))
                    yield return  chessGrid.Grid[position.X +xMove[i], position.Y +yMove[i]];                
            }
        }

        private bool IsInGrid(int x, int y){
            return x >= 0 && y >= 0 && x < ChessGrid.MatrixLength && y < ChessGrid.MatrixLength;
        }
    }
}