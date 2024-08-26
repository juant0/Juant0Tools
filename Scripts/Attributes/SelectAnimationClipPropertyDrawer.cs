#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace Juant0Tools
{
    [CustomPropertyDrawer(typeof(SelectAnimationClipAttribute))]
    public class SelectAnimationClipPropertyDrawer : BasePropertyDrawer
    {
        private AnimatorController _animator;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {

            float propertyHeight = base.GetPropertyHeight(property, label);
            if (property.isExpanded)
                propertyHeight += EditorGUIUtility.singleLineHeight * 3;
            return propertyHeight;
        }
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(rect, GUIContent.none, property);
            rect.height = EditorGUIUtility.singleLineHeight;
            property.isExpanded = EditorGUI.Foldout(rect, property.isExpanded, label, toggleOnLabelClick: true);
            if (property.isExpanded)
            {
                Rect animatorRect = CreateRect(rect, yOffset: rect.height * 2);
                _animator = (AnimatorController)EditorGUI.ObjectField(animatorRect, _animator, typeof(AnimatorController), true);
                string clipName = GetClip(property, animatorRect, _animator);
                rect.y += animatorRect.height;
                label.text = $"{clipName}Hash";
            }
            using (new EditorGUI.DisabledScope(true))
                EditorGUI.PropertyField(rect, property, label, false);
            EditorGUI.EndProperty();
        }

        private string GetClip(SerializedProperty property, Rect rect, AnimatorController animatorController)
        {
            Rect popUpRect = CreateRect(rect, yOffset: rect.height);
            if (_animator == null)
            {
                EditorGUI.HelpBox(popUpRect, $"Please select an animatorContoller", MessageType.Warning);
                return lastParameterName;
            }
            AnimationClip[] animatorControllerparameters = GetAnimationClips(animatorController);
            if (animatorControllerparameters.Length == 0)
            {
                EditorGUI.HelpBox(popUpRect, $"Animator Controller {_animator.name} does not have any Clip", MessageType.Warning);
                return lastParameterName;
            }
            string[] parameters = new string[animatorControllerparameters.Length];
            for (int i = 0; i < animatorControllerparameters.Length; i++)
                parameters[i] = animatorControllerparameters[i].name;
            int currentIndex = GetIndex(parameters, property.intValue);
            if (ParametersPopup(popUpRect, "Parameter Name", currentIndex, parameters, out int newIndex))
                property.intValue = Animator.StringToHash(parameters[newIndex]);
            return lastParameterName;
        }
        private int GetIndex(string[] parameters, int currentSelection)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (Animator.StringToHash(parameters[i]) == currentSelection)
                    return i;
            }
            return -1;
        }
        private AnimationClip[] GetAnimationClips(AnimatorController animatorController)
        {
            List<AnimationClip> clips = new List<AnimationClip>();
            foreach (AnimatorControllerLayer layer in animatorController.layers)
            {
                foreach (ChildAnimatorState state in layer.stateMachine.states)
                {
                    if (state.state.motion is AnimationClip clip)
                        clips.Add(clip);
                }
            }
            return clips.ToArray();
        }

    }
}
#endif
