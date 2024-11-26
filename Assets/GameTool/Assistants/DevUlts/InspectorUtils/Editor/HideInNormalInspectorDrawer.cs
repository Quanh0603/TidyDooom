using UnityEditor;
using UnityEngine;

namespace DevUlts.InspectorUtils.Editor
{
    [CustomPropertyDrawer(typeof(HideInNormalInspector))]
    public class HideInNormalInspectorDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return -2; // To compensate the gap between inspector's properties
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
        }
    }
}