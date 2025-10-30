using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapMaker))]
public class MapMakerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MapMaker generator = (MapMaker)target;

        if (GUILayout.Button("Generar Tilemap"))
        {
            generator.GenerateMap();
        }
    }
}
