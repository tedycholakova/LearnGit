namespace DOMTree
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class TreeNode<T>
    {
        private readonly List<TreeNode<T>> children = new List<TreeNode<T>>();

        public TreeNode(T value)
        {
            this.Value = value;
        }

        public TreeNode<T> Parent { get; private set; }
        public T Value { get; }

        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get { return this.children.AsReadOnly(); }
        }

        public TreeNode<T> AddChild(T value)
        {
            var node = new TreeNode<T>(value) { Parent = this };
            children.Add(node);
            return node;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
