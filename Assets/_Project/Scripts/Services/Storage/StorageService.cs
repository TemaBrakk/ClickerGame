using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class StorageService : IStorageService
{
    public void Save(string key, object data, Action<bool> callback = null)
    {
        string path = BuildPath(key);
        string json = JsonConvert.SerializeObject(data);

        using (StreamWriter fileStream = new StreamWriter(path))
        {
            fileStream.Write(json);
        }

        callback?.Invoke(true);
    }

    public void Load<T>(string key, Action<T> callback)
    {
        string path = BuildPath(key);

        if (!File.Exists(path))
        {
            callback?.Invoke(default);
            return;
        }

        using (StreamReader fileStream = new StreamReader(path))
        {
            string json = fileStream.ReadToEnd();
            T data = JsonConvert.DeserializeObject<T>(json);

            callback?.Invoke(data);
        }
    }

    private string BuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}
