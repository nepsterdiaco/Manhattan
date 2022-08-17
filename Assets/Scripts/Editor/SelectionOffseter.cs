using UnityEngine;
using UnityEditor;

class SelectionOffseter : EditorWindow
{
    static float transformOffset = 0;

    class SelectionActiveTransform : ScriptableObject
    {
        [MenuItem("Example/Duplicate at Origin _d")]
        static void DuplicateSelected()
        {
            var selection = Selection.transforms;
            foreach (var selected in selection)
            {
                var tf = selected.transform;
                selected.Translate(Vector3.right * transformOffset);
                transformOffset += 50f;
            }
        }
    }

    //The menu item will be disabled if nothing, is selected.
    [MenuItem("Example/Duplicate at Origin _d", true)]
    static bool ValidateSelection()
    {
        return Selection.activeTransform != null;
    }
}