using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(ToggleScript)), CanEditMultipleObjects]
public class ToggleScriptEditor : Editor {
    public SerializedProperty
        action_Prop,

        //animation variables
        anim_Prop,
        animParameter_Prop,
        animDelay_Prop,

        //BoolChange variables
        targetScript_Prop,
        methodName_Prop,
        boolDelay_Prop,

        //Instantiate variables
        spawnable_Prop,
        position_Prop,
        rotation_Prop,
        spawnDelay_Prop;

    void OnEnable()
    {
        action_Prop = serializedObject.FindProperty("action");

        anim_Prop = serializedObject.FindProperty("anim");
        animParameter_Prop = serializedObject.FindProperty("animParameter");
        animDelay_Prop = serializedObject.FindProperty("animDelay");

        targetScript_Prop = serializedObject.FindProperty("targetScript");
        methodName_Prop = serializedObject.FindProperty("methodName");
        boolDelay_Prop = serializedObject.FindProperty("boolDelay");

        spawnable_Prop = serializedObject.FindProperty("spawnable");
        position_Prop = serializedObject.FindProperty("position");
        rotation_Prop = serializedObject.FindProperty("rotation");
        spawnDelay_Prop = serializedObject.FindProperty("spawnDelay");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ToggleScript script = (ToggleScript)target;
        script.action = (ToggleScript.Actions)EditorGUILayout.EnumPopup("Action", script.action);

        switch (script.action)
        {
            case ToggleScript.Actions.Animation:
                EditorGUILayout.PropertyField(anim_Prop, new GUIContent("Animator"));
                EditorGUILayout.PropertyField(animParameter_Prop, new GUIContent("Animation Parameter"));
                EditorGUILayout.PropertyField(animDelay_Prop, new GUIContent("Animation Delay"));
                break;
            case ToggleScript.Actions.BoolChange:
                EditorGUILayout.PropertyField(targetScript_Prop, new GUIContent("Target Script"));
                EditorGUILayout.PropertyField(methodName_Prop, new GUIContent("Method Name"));
                EditorGUILayout.PropertyField(boolDelay_Prop, new GUIContent("Bool Change Delay"));
                break;
            case ToggleScript.Actions.Instantiate:
                EditorGUILayout.PropertyField(spawnable_Prop, new GUIContent("Spawnable"));
                EditorGUILayout.PropertyField(position_Prop, new GUIContent("Position"));
                EditorGUILayout.PropertyField(rotation_Prop, new GUIContent("Rotation"));
                EditorGUILayout.PropertyField(spawnDelay_Prop, new GUIContent("Spawn Delay"));
                break;
        }

        serializedObject.ApplyModifiedProperties();
        
    }
}