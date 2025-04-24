using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class Storage : IStorage
{
    public void Save<T>(string key, T data, Action<bool> callback = null)
    {
        string path = BuildPath(key);
        string json = JsonConvert.SerializeObject(data);

        using (StreamWriter fileStream = new StreamWriter(path))
        {
            fileStream.Write(json);
        }

        callback?.Invoke(true);
    }

    public T Load<T>(string key)
    {
        string path = BuildPath(key);

        if (!IsFileExists(key))
        {
            return default;
        }

        using (StreamReader fileStream = new StreamReader(path))
        {
            string json = fileStream.ReadToEnd();
            T data = JsonConvert.DeserializeObject<T>(json);

            return data;
        }
    }

    public bool IsFileExists(string key)
    {
        string path = BuildPath(key);
        return File.Exists(path);
    }

    private string BuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}
