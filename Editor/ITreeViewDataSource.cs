using System;
using System.Reflection;
using UnityEditor.IMGUI.Controls;

namespace NewBlood.Editor
{
    struct ITreeViewDataSource
    {
        static readonly Type s_ITreeViewDataSource = Type.GetType("UnityEditor.IMGUI.Controls.ITreeViewDataSource, UnityEditor", true);

        static readonly MethodInfo s_FindItem = s_ITreeViewDataSource.GetMethod("FindItem", BindingFlags.Public | BindingFlags.Instance);

        static readonly MethodInfo s_IsExpanded = s_ITreeViewDataSource.GetMethod("IsExpanded", new[] { typeof(int) });

        readonly object self;

        public ITreeViewDataSource(object self)
        {
            if (!s_ITreeViewDataSource.IsAssignableFrom(self.GetType()))
                throw new ArgumentException(nameof(self));

            this.self = self;
        }

        public TreeViewItem FindItem(int id)
        {
            return s_FindItem.Invoke(self, new object[] { id }) as TreeViewItem;
        }

        public bool IsExpanded(int id)
        {
            return (bool)s_IsExpanded.Invoke(self, new object[] { id });
        }
    }
}
