namespace HtmlDOMTree
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class TreeNode<T>
    {
        private readonly T _value;
        private readonly List<TreeNode<T>> _children = new List<TreeNode<T>>();

        public TreeNode(T value)
        {
            _value = value;
        }

        public TreeNode<T> this[int i] => _children[i];

        public TreeNode<T> Parent { get; private set; }

        public T Value => _value;

        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get
            {
                return this._children.AsReadOnly();
            }
        }

        public TreeNode<T> AddChild(T value)
        {
            var node = new TreeNode<T>(value) { Parent = this };
            _children.Add(node);
            return node;
        }

        public bool RemoveChild(TreeNode<T> node)
        {
            return _children.Remove(node);
        }
    }
}
