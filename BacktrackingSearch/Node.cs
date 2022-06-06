namespace BacktrackingSearch
{
    public class Node
    {
        public Node Parent{get;set;}
        public List<Node> ChildNodes {get; private set;}

        public INodeContent Content {get;set;}

        public bool isVisited {get; private set;}
        
        public int Level {get;set;}

        public int ActiveChildIndex {get;set;}

        private bool processed = false;
        public bool Process(){
            if (!processed)
            {
                isVisited = true;
                processed = Content.Process();
            }

            return processed;
        }
        public void UnProcess()
        {
            Content.UnProcess();
            ChildNodes = null;
        }

        public void ExpandChidlNodes(){
            ChildNodes = new List<Node>();
            foreach(var contentNode in Content.ExpandChildNodesContents()){
                Node newNode = new Node();

                newNode.Parent = this;
                newNode.Content = contentNode;
                newNode.Level = this.Level +1;
                
                ChildNodes.Add(newNode);
            }
        }
    }
}