using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RequiredAttribute))]
public class RequiredAttributePropertyDrawer : PropertyDrawer
{
    readonly Color errorColor = new Color(1, .2f, .2f, .1f);

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (IsFieldEmpty(property))
        {
            float height = EditorGUIUtility.singleLineHeight * 2;
            height += base.GetPropertyHeight(property, label);

            return height;
        }
        else return base.GetPropertyHeight(property, label);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (!IsFieldSupported(property))
        {
            Debug.LogError("Required Attribute placed on incompatible field type");
            return;
        }

        if (IsFieldEmpty(property))
        {
            position.height = EditorGUIUtility.singleLineHeight * 2;
            position.height += base.GetPropertyHeight(property, label);

            EditorGUI.HelpBox(position, "Required", UnityEditor.MessageType.Error);
            EditorGUI.DrawRect(position, errorColor);

            position.height = base.GetPropertyHeight(property, label);
            position.y = EditorGUIUtility.singleLineHeight * 2;
        }

        EditorGUI.PropertyField(position, property, label);
    }

    private bool IsFieldEmpty(SerializedProperty property)
    {
        if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue == null)
            return true;

        if (property.propertyType == SerializedPropertyType.String && string.IsNullOrEmpty(property.stringValue))
            return true;

        return false;
    }

    private bool IsFieldSupported(SerializedProperty property)
    {
        if (property.propertyType == SerializedPropertyType.ObjectReference)
            return true;

        if (property.propertyType == SerializedPropertyType.String)
            return true;

        return false;
    }
}