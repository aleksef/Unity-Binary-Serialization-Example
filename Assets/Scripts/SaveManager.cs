using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static string directory = "SaveData";
    public static string filename = "MySave";

    public static void Save(SaveObject so)
    {
        if(!DirectoryExists()) Directory.CreateDirectory(Application.persistentDataPath 
            + "/" + directory);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetFullPath());
        bf.Serialize(file, so);
        file.Close();
        Debug.Log("Object saved.");
    }

    public static SaveObject Load()
    {
        if(SaveExists()) 
        {
            try 
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(GetFullPath(), FileMode.Open);
                SaveObject so = (SaveObject)bf.Deserialize(file);
                file.Close();
                Debug.Log("Object loaded.");
                return so;
            }
            catch (SerializationException)
            {
                Debug.Log("Failed to load file.");
            }
        }
        return null;
    }

    private static bool SaveExists() => File.Exists(GetFullPath());

    private static bool DirectoryExists() => Directory.Exists(Application.persistentDataPath 
        + "/" + directory);

    private static string GetFullPath() => Application.persistentDataPath 
        + "/" + directory + "/" + filename;
}
