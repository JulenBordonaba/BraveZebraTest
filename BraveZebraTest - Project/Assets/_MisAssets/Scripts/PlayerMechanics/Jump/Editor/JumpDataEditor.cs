using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
[CanEditMultipleObjects]
[CustomEditor(typeof(JumpData))]
public class JumpDataEditor : Editor
{
    protected Texture logo;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        JumpData jumpData = MyJump;
        
        ManageLogo();
        
        jumpData.dataType = (JumpDataInputMode)EditorGUILayout.EnumPopup("Data Input Mode",jumpData.dataType);

        GUILayout.Space(10);

        switch (jumpData.dataType)
        {
            case JumpDataInputMode.VelocityGravity:
                DisplayGravityVelocityMode(jumpData);
                break;
            case JumpDataInputMode.HeightTime:
                DisplayHeightTimeMode(jumpData);
                break;
            default:
                break;
        }

        GUILayout.Space(10);

        Save(jumpData);

        serializedObject.ApplyModifiedProperties();


    }

    private void Save(JumpData jumpData)
    {
        if (GUI.changed)
        {
            Undo.RecordObject(jumpData, "save");
            EditorUtility.SetDirty(jumpData);
            AssetDatabase.SaveAssets();
            Repaint();
            Debug.Log("SAVED");
        }
    }
    
    private void ManageLogo()
    {
        CheckLogo();

        DisplayLogo();

        GUILayout.Space(20);
    }

    private void DisplayLogo()
    {
        if (logo == null)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, fontSize = 20, stretchHeight = true, clipping = TextClipping.Overflow, border = new RectOffset() };
            EditorGUILayout.LabelField("---Jump Data---", style, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
        }
        else
        {
            GUIStyle style = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, imagePosition = ImagePosition.ImageOnly, clipping = TextClipping.Clip };
            GUILayout.Label(logo, style);
        }

    }

    private void CheckLogo()
    {
        if (logo != null) return;

        logo = (Texture)EditorGUIUtility.Load("Jump/JumpData_Logo.png");

    }

    private void DisplayHeightTimeMode(JumpData jumpData)
    {
        jumpData.maxHeight = EditorGUILayout.FloatField("Max Height", jumpData.maxHeight);
        jumpData.timeToMaxHeight = EditorGUILayout.FloatField("Time to reach Max Height", jumpData.timeToMaxHeight);

        GUILayout.Space(10);

        jumpData.keyReleaseGravity = EditorGUILayout.FloatField("Key Release Gravity", jumpData.keyReleaseGravity);
        jumpData.fallGravity = EditorGUILayout.FloatField("Falling Gravity", jumpData.fallGravity);

        GUILayout.Space(10);
        
        jumpData.coyoteTime = EditorGUILayout.FloatField("Coyote Time", jumpData.coyoteTime);

        SetValuesHeightTimeMode(jumpData);

        ClampGravity(jumpData);

        GUILayout.Space(20);

        GUIStyle style = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, fontSize = 15, stretchHeight = true, clipping = TextClipping.Overflow };
        EditorGUILayout.LabelField("Max Height: " + jumpData.maxHeight, style, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
    }

    private void DisplayGravityVelocityMode(JumpData jumpData)
    {

        jumpData.initialVelicity = EditorGUILayout.FloatField("Initial Velocity", jumpData.initialVelicity);
        jumpData.baseGravity = EditorGUILayout.FloatField("Base Gravity", jumpData.baseGravity);
        jumpData.fallGravity = EditorGUILayout.FloatField("Falling Gravity", jumpData.fallGravity);
        jumpData.keyReleaseGravity = EditorGUILayout.FloatField("Key Release Gravity", jumpData.keyReleaseGravity);
        jumpData.coyoteTime = EditorGUILayout.FloatField("Coyote Time", jumpData.coyoteTime);

        ClampGravity(jumpData);

        SetValuesGravityVelocityMode(jumpData);

        GUILayout.Space(20);

        GUIStyle style = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, fontSize = 15, stretchHeight = true, clipping = TextClipping.Overflow };
        EditorGUILayout.LabelField("Max Height: " + jumpData.maxHeight, style, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
    }

    private void SetValuesGravityVelocityMode(JumpData jumpData)
    {
        float h0 = 0;
        float v = jumpData.initialVelicity;
        float g = Mathf.Abs(jumpData.baseGravity);
        float t = Mathf.Abs(v / g);
        jumpData.timeToMaxHeight = t;

        float hmax = h0 + v * t - ((0.5f * g) * Mathf.Pow(t, 2));


        if (v == 0) hmax = 0;

        if (g == 0) hmax = float.PositiveInfinity;

        jumpData.maxHeight = hmax;
    }

    private void SetValuesHeightTimeMode(JumpData jumpData)
    {
        float h = jumpData.maxHeight;
        float t = jumpData.timeToMaxHeight;

        float g = (2 * h) / Mathf.Pow(t, 2);

        float v = Mathf.Sqrt(2 * g * h);

        jumpData.initialVelicity = v;
        jumpData.baseGravity = g;


    }

    private void ClampGravity(JumpData jumpData)
    {
        bool isPositive = jumpData.baseGravity >= 0;

        if (isPositive)
        {
            jumpData.keyReleaseGravity = Mathf.Max(jumpData.keyReleaseGravity, jumpData.baseGravity);
            jumpData.fallGravity = Mathf.Max(jumpData.fallGravity, jumpData.baseGravity);
        }
        else
        {
            jumpData.keyReleaseGravity = Mathf.Min(jumpData.keyReleaseGravity, jumpData.baseGravity);
            jumpData.fallGravity = Mathf.Min(jumpData.fallGravity, jumpData.baseGravity);
        }
    }

    public JumpData MyJump
    {
        get
        {
            return (JumpData)target;
        }
    }
}
