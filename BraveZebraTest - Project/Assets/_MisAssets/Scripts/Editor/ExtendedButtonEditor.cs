using UnityEditor;
using UnityEditor.UI;

[CanEditMultipleObjects]
[CustomEditor(typeof(ExtendedButton))]
public class ExtendedButtonEditor : ButtonEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ExtendedButton extendedButton = (ExtendedButton)target;
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_onPointerEnter"), true);
        serializedObject.ApplyModifiedProperties();
    }
}
