using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{
    [Header("UserInfo")]
    public static GameManager Instance;
    public UserData[] userDatas;
    public UserData userdata;
    public string name;
    public int cash;
    public int banlance;
    public string ID;
    public string PW;

    public TMP_InputField InputID;
    public TMP_InputField InputPW;
    public Button loginButton;

    public Button addUserButton;
    public GameObject AddUserPopup;
    public Button loginPopupButton;
    public GameObject LoginPopup;
    public Button loginCancle;

    public WarningSign warningSign;

    private void Awake()
    {
        userDatas = Resources.LoadAll<UserData>("Data/UserData");
        warningSign = FindObjectOfType<WarningSign>();
        //warningSign = FindObjectOfType<WarningSign>();
    }
    private void Start()
    {
        Instance = this;
        userdata = null;

        LoginPopup.SetActive(false);
        
        loginPopupButton.onClick.AddListener(SetPopupLogin);
        loginButton.onClick.AddListener(OnClickLogin);
        loginCancle.onClick.AddListener(SetPopupLoginCancle);
        addUserButton.onClick.AddListener(SetPopupAddUser);
    }

    private void Update()
    {
        userDataChange();
    }

    private void userDataChange(int i = 0, bool dataChange = false)
    {
        if (userDatas == null || userDatas.Length <= i)
        {
            return;
        }

        bool change = dataChange;
        if (name != userDatas[i].UserName || banlance != userDatas[i].Banlance || cash != userDatas[i].Cash || ID != userDatas[i].ID || PW != userDatas[i].PW)
        {
            change = true;
        }

        if (change)
        {
            name = userDatas[i].UserName;
            banlance = userDatas[i].Banlance;
            cash = userDatas[i].Cash;
            ID = userDatas[i].ID;
            PW = userDatas[i].PW;
        }
    }

    public void OnClickLogin()
    {
        string inputID = InputID.text;
        string inputPW = InputPW.text;

        UserData foundUser;
        int userNumber;

        if (TryLogin(inputID, inputPW, out foundUser, out userNumber))
        {
            userDataChange(userNumber);
        }
    }

    public bool TryLogin(string inputID, string inputPW, out UserData match, out int matchNumber)
    {
        match = null;
        matchNumber = -1;

        if (userDatas == null || userDatas.Length == 0)
        {
            return false;
        }

        for (int i = 0; i < userDatas.Length; i++)
        {
            if (userDatas[i].ID == inputID)
            {
                if (userDatas[i].PW == inputPW)
                {
                    match = userDatas[i];
                    matchNumber = i;
                    userdata = userDatas[i];
                    return true;
                }
                else
                {
                    warningSign.SetTextWrarning("비밀번호가\n틀렸습니다");
                    return false;
                }
            }
        }
        warningSign.SetTextWrarning("없는\n아이디입니다");
        return false;
    }

    public void SetPopupAddUser()
    {
        AddUserPopup.SetActive(true);
    }

    public void SetPopupLogin()
    {
        LoginPopup.SetActive(true);
    }

    public void SetPopupLoginCancle()
    {
        LoginPopup.SetActive(false);
    }

    public void UpdateUserData()
    {
        userDatas = Resources.LoadAll<UserData>("Data/UserData");
    }
}
