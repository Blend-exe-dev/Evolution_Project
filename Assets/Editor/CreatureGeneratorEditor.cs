using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CreatureGenerator))]
public class CreatureGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            CreatureGenerator generator = (CreatureGenerator)target;
            generator.GenerateCreature();
        }
    }
}
