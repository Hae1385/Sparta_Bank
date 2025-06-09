using System.IO;
using UnityEngine;

public static class UserDataManager
{
    private static string filePath => Path.Combine(Application.persistentDataPath, "UserData.json");

    public static void SaveUsers(UserDataList userList)
    {
        string json = JsonUtility.ToJson(userList, true);
        File.WriteAllText(filePath, json);
    }

    public static UserDataList LoadUsers()
    {
        if (!File.Exists(filePath))
            return new UserDataList();

        string json = File.ReadAllText(filePath);
        return JsonUtility.FromJson<UserDataList>(json);
    }
}
