using System;

public interface IStorage
{
    public void Save<T>(string key, T data, Action<bool> callback = null);
    public T Load<T>(string key);
    public bool IsFileExists(string key);
}
