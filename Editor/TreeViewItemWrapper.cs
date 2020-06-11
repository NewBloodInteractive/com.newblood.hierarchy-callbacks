using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace NewBlood.Editor
{
    class WrappedTreeViewItem : TreeViewItem
    {
        public TreeViewItem baseItem { get; }

        public WrappedTreeViewItem(TreeViewItem baseItem)
        {
            this.baseItem = baseItem;
        }
        
        public override bool hasChildren => baseItem.hasChildren;

        public override List<TreeViewItem> children
        {
            get => baseItem.children;
            set => baseItem.children = value;
        }

        public override int depth
        {
            get => baseItem.depth;
            set => baseItem.depth = value;
        }

        public override string displayName
        {
            get => baseItem.displayName;
            set => baseItem.displayName = value;
        }

        public override Texture2D icon
        {
            get => baseItem.icon;
            set => baseItem.icon = value;
        }

        public override int id
        {
            get => baseItem.id;
            set => baseItem.id = value;
        }

        public override TreeViewItem parent
        {
            get => baseItem.parent;
            set => baseItem.parent = value;
        }

        public override int CompareTo(TreeViewItem other)
        {
            return baseItem.CompareTo(other);
        }

        public override bool Equals(object obj)
        {
            return baseItem.Equals(obj);
        }

        public override int GetHashCode()
        {
            return baseItem.GetHashCode();
        }

        public override string ToString()
        {
            return baseItem.ToString();
        }
    }
}
