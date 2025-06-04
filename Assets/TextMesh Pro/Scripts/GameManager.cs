using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;
    public string name;
    public int cash;
    public int banlance;
    public string ID;
    public string PW;

    private void Start()
    {
        Instance = this;
        userData = ScriptableObject.CreateInstance<UserData>();
        //userData = new UserData(name, cash, banlance, ID, PW);
        userData.UserInit(name, banlance, cash, ID, PW);
    }

    private void Update()
    {
        userDataChange();
    }

    private void userDataChange(bool dataChange = false)
    {
        bool change = dataChange;
        if (name != userData.UserName || banlance != userData.Banlance || cash != userData.Cash || ID != userData.ID || PW != userData.PW)
        {
            change = true;
        }

        if (change)
        {
            name = userData.UserName;
            banlance = userData.Banlance;
            cash = userData.Cash;
            ID = userData.ID;
            PW = userData.PW;
        }
    }
}
