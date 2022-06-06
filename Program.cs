using BacktrackingSearch;
using chessgrid;
using chessServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Chess Knigh tour Problem Resolver");

        BackTrackingSearchService searchService = new BackTrackingSearchService();

        Node firstNode = new Node();

        firstNode.Level = 0;        
        firstNode.Parent = null;

        var piece = new ChessPiece(ChessPieceType.Knight);
        
        var chessGrid = new ChessGrid();

        piece.Position = chessGrid.Grid[0,0];

        ChessMoveService chessMoveService = new ChessMoveService(chessGrid);

        firstNode.Content = new ChessNodeContent(piece,chessMoveService);    


        var result = searchService.SearchSolutionLastNode(firstNode); 

       
        /// writing result

        var currentNode = result;

        while(currentNode != null){

            Console.Write((currentNode.Content as ChessNodeContent).piece.Position + " ->");
            currentNode = currentNode.Parent;
        }
    }
}