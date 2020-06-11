using System;
using System.Reflection;

namespace NewBlood.Editor
{
    struct SceneHierarchy
    {
        static readonly Type s_SceneHierarchy = Type.GetType("UnityEditor.SceneHierarchy, UnityEditor", true);

        static readonly PropertyInfo s_GetTreeView = s_SceneHierarchy.GetProperty("treeView", BindingFlags.NonPublic | BindingFlags.Instance);

        readonly object self;

        public TreeViewController treeView => new TreeViewController(s_GetTreeView.GetValue(self));

        public SceneHierarchy(object self)
        {
            if (!s_SceneHierarchy.IsAssignableFrom(self.GetType()))
                throw new ArgumentException(nameof(self));

            this.self = self;
        }
    }
}
