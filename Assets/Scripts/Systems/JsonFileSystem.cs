using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonFileSystem : ISaveFileSystem, ILoadFileSystem, IDeleteFileSystem
{
    private readonly string _filePath;
    private readonly JsonSerializer _serializer;

    public JsonFileSystem()
    {
        _filePath = Application.persistentDataPath + "/Save.json";
        _serializer = new JsonSerializer();
    }

    public void Save(SaveData saveData)
    {
        using var sw = new StreamWriter(_filePath);
        using JsonWriter writer = new JsonTextWriter(sw);
        _serializer.Serialize(writer, saveData);
    }

    public SaveData Load()
    {
        if (!File.Exists(_filePath))
        {
            return null;
        }

        using var sr = new StreamReader(_filePath);
        using JsonReader reader = new JsonTextReader(sr);
        var saveData = _serializer.Deserialize<SaveData>(reader);

        return saveData;
    }

    public void Delete()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
        }
    }
}