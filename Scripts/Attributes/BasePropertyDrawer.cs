using UnityEditor;
using UnityEngine;

namespace Juant0Tools
{
    public class BasePropertyDrawer : PropertyDrawer
    {
        protected string lastParameterName = "NoSelected";
        protected Rect CreateRect(Rect baseRect, float xOffset = 0, float yOffset = 0, float widthOffset = 0, float heightOffset = 0)
        {
            return new Rect()
            {
                x = baseRect.x + xOffset,
                y = baseRect.y + yOffset,
                width = baseRect.width + widthOffset,
                height = EditorGUIUtility.singleLineHeight + heightOffset,
            };
        }
        protected bool ParametersPopup(Rect position, string label, int selectedIndex, string[] parameters, out int newIndex)
        {
            newIndex = EditorGUI.Popup(position, "Parameter Name", selectedIndex, parameters);
            if (newIndex < selectedIndex)
                return false;
            if (newIndex < 0)
                return false;
            lastParameterName = parameters[newIndex];
            return true;
        }
    }
}
