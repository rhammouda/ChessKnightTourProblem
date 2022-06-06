using chessgrid;
using chessServices;

namespace BacktrackingSearch
{
    public class ChessNodeContent : INodeContent
    {
        private static bool[,] visitedChessPositions = new bool[8,8];

        static ChessNodeContent()
        {
            for (int i=0; i<8; i++)
            {
                for (int j = 0; j < 8; j++)
                    visitedChessPositions[i,j] = false;
            }
        }
        public ChessPiece piece{get;}
        private ChessMoveService chessMoveService;
       
        public bool isVisited {get;set;}

         public bool Process(){
             if(visitedChessPositions[piece.Position.X, piece.Position.Y])
                return false;

            visitedChessPositions[piece.Position.X, piece.Position.Y] =true;

            return true;
         }

        public void UnProcess(){
            visitedChessPositions[piece.Position.X, piece.Position.Y] = false;
        }

        public ChessNodeContent(ChessPiece piece, ChessMoveService chessMoveService)
        {
            this.piece = piece;
            this.chessMoveService = chessMoveService;
        }

        public IEnumerable<INodeContent> ExpandChildNodesContents()
        {
            foreach( var possibleMove in chessMoveService.GetPossibleMoves(piece)){
                var newPiece = new ChessPiece(piece.ChessPieceType);
                newPiece.Position = possibleMove;
                ChessNodeContent nodeContent = new ChessNodeContent(newPiece, chessMoveService);
                yield return nodeContent;
            }
        }

    }
}