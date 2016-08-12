using System;
using UnityEditor;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects {
    [CustomEditor(typeof(EdgeDetectionColor))]
    class EdgeDetectionColorsEditor : Editor {
        SerializedObject serObj;

        SerializedProperty sensitivityDepth;
        SerializedProperty sensitivityNormals;


        SerializedProperty edgesOnlyBgColor;

        SerializedProperty sampleDist;

        SerializedProperty edgesColor;


        void OnEnable() {
            serObj = new SerializedObject(target);

            sensitivityDepth = serObj.FindProperty("sensitivityDepth");
            sensitivityNormals = serObj.FindProperty("sensitivityNormals");


            edgesOnlyBgColor = serObj.FindProperty("edgesOnlyBgColor");
            edgesColor = serObj.FindProperty("edgesColor");
            sampleDist = serObj.FindProperty("sampleDist");
        }


        public override void OnInspectorGUI() {
            serObj.Update();

            GUILayout.Label("Detects spatial differences and converts into black outlines", EditorStyles.miniBoldLabel);
            GUILayout.Label("Works for triangle depth and robert cross only", EditorStyles.miniBoldLabel);

            EditorGUILayout.PropertyField(sensitivityDepth, new GUIContent(" Depth Sensitivity"));
            EditorGUILayout.PropertyField(sensitivityNormals, new GUIContent(" Normals Sensitivity"));
            EditorGUILayout.PropertyField(sampleDist, new GUIContent(" Sample Distance"));

            EditorGUILayout.Separator();

            GUILayout.Label("Background Options");
            EditorGUILayout.PropertyField(edgesOnlyBgColor, new GUIContent("Bg Color"));
            EditorGUILayout.PropertyField(edgesColor, new GUIContent(" Edge Color"));

            serObj.ApplyModifiedProperties();
        }
    }
}