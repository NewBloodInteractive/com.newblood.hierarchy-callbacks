using System;
using System.Reflection;

namespace NewBlood.Editor
{
    struct TreeViewController
    {
        static readonly Type s_TreeViewController = Type.GetType("UnityEditor.IMGUI.Controls.TreeViewController, UnityEditor", true);

        static readonly PropertyInfo s_GetData = s_TreeViewController.GetProperty("data");

        readonly object self;

        public ITreeViewDataSource data => new ITreeViewDataSource(s_GetData.GetValue(self));

        public TreeViewController(object self)
        {
            if (!s_TreeViewController.IsAssignableFrom(self.GetType()))
                throw new ArgumentException(nameof(self));

            this.self = self;
        }
    }
}
