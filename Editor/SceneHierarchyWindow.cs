using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace NewBlood.Editor
{
    struct SceneHierarchyWindow
    {
        static readonly Type s_SceneHierarchyWindow = Type.GetType("UnityEditor.SceneHierarchyWindow, UnityEditor", true);

        static readonly Func<IList> s_GetAllSceneHierarchyWindows = (Func<IList>)s_SceneHierarchyWindow
            .GetMethod("GetAllSceneHierarchyWindows")
            .CreateDelegate(typeof(Func<IList>));

        static readonly PropertyInfo s_GetSceneHierarchy = s_SceneHierarchyWindow.GetProperty("sceneHierarchy");

        readonly object self;

        public SceneHierarchy sceneHierarchy => new SceneHierarchy(s_GetSceneHierarchy.GetValue(self));

        public SceneHierarchyWindow(object self)
        {
            if (!s_SceneHierarchyWindow.IsAssignableFrom(self.GetType()))
                throw new ArgumentException(nameof(self));

            this.self = self;
        }

        public static List<SceneHierarchyWindow> GetAllSceneHierarchyWindows()
        {
            var windows = s_GetAllSceneHierarchyWindows();
            var wrapper = new List<SceneHierarchyWindow>(windows.Count);

            foreach (var window in windows)
                wrapper.Add(new SceneHierarchyWindow(window));

            return wrapper;
        }
    }
}
