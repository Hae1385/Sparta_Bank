using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserDataList
{
    public List<UserData> users = new List<UserData>();
}
[System.Serializable]
public class UserData
{
    [Header("UserInfo")]
    public string UserName;
    public int Banlance;
    public int Cash;

    [Header("PrivateInfo")]
    public string ID;
    public string PW;


    public void UserInit(string userName, int banlance, int cash, string id, string pw)
    {
        UserName = userName;
        Banlance = banlance;
        Cash = cash;
        ID = id;
        PW = pw;
    }

    public bool InputMoney(int inputCash)
    {
        if (inputCash <= Cash)
        {
            Cash -= inputCash;
            Banlance += inputCash;
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool OutputMoney(int outputCash) 
    {
        if (outputCash <= Banlance)  
        {
            Banlance -= outputCash;
            Cash += outputCash;  
            return true;
        }
        else
        {
            return false;
        }
    }
}
