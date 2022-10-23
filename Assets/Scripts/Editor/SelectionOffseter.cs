using UnityEngine;
using UnityEditor;

class SelectionOffseter : EditorWindow
{
    static float transformOffset = 0;

    class SelectionActiveTransform : ScriptableObject
    {
        [MenuItem("Example/Offset Selection")]
        static void OffsetSelected()
        {
            transformOffset = 0;
            int offset = 0;
            var name = EditorInputDialog.Show("Question", "Please enter your name", "");
            if (!string.IsNullOrEmpty(name))
            {
                offset = ConvertToInt(name);
            }
            else
            {
                return;
            }

            var selection = Selection.transforms;
            foreach (var selected in selection)
            {
                var tf = selected.transform;
                selected.Translate(Vector3.right * transformOffset);
                transformOffset += offset;
            }
        }
    }

    //The menu item will be disabled if nothing, is selected.
    [MenuItem("Example/Duplicate at Origin", true)]
    static bool ValidateSelection()
    {
        return Selection.activeTransform != null;
    }

    public static int ConvertToInt(string inputString)
    {
        int result;
        string input;
        if (int.TryParse(inputString, out result))
        {
            return result;
        }
        else
        {
            Debug.Log("Not a valid int");
            return 0;
        }
    }
}