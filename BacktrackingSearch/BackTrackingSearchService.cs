namespace BacktrackingSearch
{
    public class BackTrackingSearchService
    {
        const int maxLevel = 63; //64 chess squares , index starts form 0

        System.Diagnostics.Stopwatch watch;

        public Node SearchSolutionLastNode(Node firstNode){

            watch = System.Diagnostics.Stopwatch.StartNew();
            var currentNode = firstNode;

            while (true)
            {
                if (!currentNode.Process())
                {
                    //Backtrack with no unprocess
                    if (currentNode.Parent != null)
                    {
                        currentNode.Parent.ActiveChildIndex++;
                        currentNode = currentNode.Parent;
                        continue;
                    }
                    else
                    {
                        throw new Exception(" No solution found");
                    }
                }

                if (currentNode.Level == maxLevel)
                {
                    DisplayResut(currentNode);
                    return currentNode;
                }


                if (currentNode.ChildNodes == null)
                    currentNode.ExpandChidlNodes();

                if (currentNode.ActiveChildIndex < currentNode.ChildNodes.Count)
                {
                    currentNode = currentNode.ChildNodes[currentNode.ActiveChildIndex];
                }
                else
                {
                    //Backtrack with unprocess // no found solution in all child nodes 
                    if (currentNode.Parent != null)
                    {
                        currentNode.UnProcess();
                        currentNode.Parent.ActiveChildIndex++;
                        currentNode = currentNode.Parent;
                    }
                    else
                    {
                        throw new Exception(" No solution found");
                    }
                }
            }
        } 


        void DisplayResut(Node result)
        {
            Console.WriteLine($"Sherching in node level = {result.Level} position " + (result.Parent.Content as ChessNodeContent).piece.Position + " -> " + (result.Content as ChessNodeContent).piece.Position);

            var currentNode = result;

            List<int> cloumnIndexes = new List<int>();

            Console.WriteLine("========================================");
            while (currentNode != null)
            {
                cloumnIndexes.Add(currentNode.ActiveChildIndex+1);
               
                Console.Write((currentNode.Content as ChessNodeContent).piece.Position + " ->");

                currentNode = currentNode.Parent;
            }
            Console.WriteLine();
            Console.WriteLine("========================================");
            cloumnIndexes.Reverse();
            Console.WriteLine("ColIndex = " + string.Join('-', cloumnIndexes));

            Console.WriteLine("Execution Time in minutes: " + watch.Elapsed.TotalMinutes);
        }
    }
}