using System.IO;
using UnityEngine;

public class SaveTools : Singleton<SaveTools>
{
    public void Save<T>(T saveData)
    {
        string saveString = JsonUtility.ToJson(saveData);

        StreamWriter file = new StreamWriter(Path.Combine(Application.streamingAssetsPath, "MusicBase"));
        file.Write(saveString);
        file.Close();
        file.Dispose();
    }
}
