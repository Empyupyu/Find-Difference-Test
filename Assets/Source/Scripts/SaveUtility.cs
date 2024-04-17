using UnityEngine;

public class SaveUtility
{
    private static SaveUtility _instance;

    public static SaveUtility Instance()
    {
        if (_instance == null)
        {
            _instance = new SaveUtility();
        }

        return _instance;
    }

    public void Save<T>(string key, T value)
    {
        var save = JsonUtility.ToJson(value);

        PlayerPrefs.SetString(key, save);
        PlayerPrefs.Save();
    }

    public T Load<T>(string key)
    {
        var save = PlayerPrefs.GetString(key);

        return JsonUtility.FromJson<T>(save);
    }

    public bool HasSave(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
}

