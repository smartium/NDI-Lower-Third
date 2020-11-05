using UnityEditor;
using UnityEditor.UI;
using KodoLinija.UI;

namespace KodoLinija.Editor.UI
{
    [CustomEditor(typeof(ButtonLongPress), true)]
    [CanEditMultipleObjects]
    public class ButtonLongPressEditor : SelectableEditor
    {
        SerializedProperty m_OnClickLongStartProperty;
        SerializedProperty m_OnClickLongCancelProperty;
        SerializedProperty m_OnClickLongCompleteProperty;
        SerializedProperty m_HoldTimeProperty;
        SerializedProperty m_ExecuteOnReleaseProperty;
        SerializedProperty m_RetriggerProperty;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_OnClickLongStartProperty = serializedObject.FindProperty("m_OnClickLongStart");
            m_OnClickLongCancelProperty = serializedObject.FindProperty("m_OnClickLongCancel");
            m_OnClickLongCompleteProperty = serializedObject.FindProperty("m_OnClickLongComplete");
            m_HoldTimeProperty = serializedObject.FindProperty("m_RequiredHoldTime");
            m_ExecuteOnReleaseProperty = serializedObject.FindProperty("m_ExecuteOnRelease");
            m_RetriggerProperty = serializedObject.FindProperty("m_Retrigger");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Long Press Options", EditorStyles.boldLabel);

            serializedObject.Update();
            EditorGUILayout.PropertyField(m_HoldTimeProperty);
            EditorGUILayout.PropertyField(m_ExecuteOnReleaseProperty);
            if (!m_ExecuteOnReleaseProperty.boolValue) {
                EditorGUILayout.PropertyField(m_RetriggerProperty);
            }
            EditorGUILayout.PropertyField(m_OnClickLongStartProperty);
            EditorGUILayout.PropertyField(m_OnClickLongCancelProperty);
            EditorGUILayout.PropertyField(m_OnClickLongCompleteProperty);
            serializedObject.ApplyModifiedProperties();
        }
    }
}