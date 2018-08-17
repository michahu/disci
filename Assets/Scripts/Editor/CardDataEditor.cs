using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class CardDataEditor : EditorWindow  {

    public CardGroup cardGroup;
    private string cardDataProjectFilePath = "/StreamingAssets/card.json";

    [MenuItem ("Window/Card Editor")]
    static void Init()
    {
        CardDataEditor window = (CardDataEditor)EditorWindow.GetWindow(typeof(CardDataEditor));
        window.Show();
    }

    private void OnGUI()
    {
        if (cardGroup != null)
        {
            Debug.Log("Got here");
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("cardGroup");

            EditorGUILayout.PropertyField(serializedProperty, true);

            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Save data"))
            {
                SaveGameData();
            } 
        }

        if (GUILayout.Button("Load data"))
        {
            LoadGameData();
        }
    }

    private void LoadGameData()
    {
        string filePath = Application.dataPath + cardDataProjectFilePath;
        
        if (File.Exists (filePath))
        {
            Debug.Log("File exists");
            string dataAsJson = File.ReadAllText(filePath);
            cardGroup = JsonUtility.FromJson<CardGroup>(dataAsJson);
        }
        else
        {
            cardGroup = new CardGroup();
        }
    }

    private void SaveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(cardGroup);
        string filePath = Application.dataPath + cardDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }
	
}
