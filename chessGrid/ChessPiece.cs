namespace chessgrid
{
    public enum ChessPieceType {King, Queen, Rook, Bishop, Knight, Pon}
    public class ChessPiece
    {
        public ChessPiece(ChessPieceType chessPieceType)
        {
            this.ChessPieceType = chessPieceType;
        }

        public ChessPieceType ChessPieceType {get; private set;}
        public Position Position {get;set;} 
        
    }
}
