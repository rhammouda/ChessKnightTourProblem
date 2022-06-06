namespace BacktrackingSearch{
    public interface INodeContent
    {
        bool Process();
        void UnProcess();
        IEnumerable<INodeContent> ExpandChildNodesContents();

    }
}