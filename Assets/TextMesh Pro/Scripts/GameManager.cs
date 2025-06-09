using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UserInfo")]
    public static GameManager Instance;
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

    public UserDataList userDataList;
    public WarningSign warningSign;
    public UserInfo userInfo;

    private void Awake()
    {
        userDataList = UserDataManager.LoadUsers();
        warningSign = FindObjectOfType<WarningSign>();
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
        if (userDataList.users == null || userDataList.users.Count <= i)
        {
            return;
        }

        bool change = dataChange;
        if (name != userDataList.users[i].UserName || banlance != userDataList.users[i].Banlance || cash != userDataList.users[i].Cash || ID != userDataList.users[i].ID || PW != userDataList.users[i].PW)
        {
            change = true;
        }

        if (change)
        {
            name = userDataList.users[i].UserName;
            banlance = userDataList.users[i].Banlance;
            cash = userDataList.users[i].Cash;
            ID = userDataList.users[i].ID;
            PW = userDataList.users[i].PW;
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
            userdata = foundUser;
            if (userInfo !=  null)
            {
                userInfo.UpdateCash(true);
            }
        }
    }

    public bool TryLogin(string inputID, string inputPW, out UserData match, out int matchNumber)
    {
        match = null;
        matchNumber = -1;

        if (userDataList == null || userDataList.users == null || userDataList.users.Count == 0)
        {
            return false;
        }

        for (int i = 0; i < userDataList.users.Count; i++)
        {
            if (userDataList.users[i].ID == inputID)
            {
                if (userDataList.users[i].PW == inputPW)
                {
                    match = userDataList.users[i];
                    matchNumber = i;
                    userdata = userDataList.users[i];
                    LoginPopup.SetActive(false);
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

    public void AddUser(string name, string id, string pw)
    {
        UserData newUser = new UserData
        {
            UserName = name,
            Banlance = 0,
            Cash = 0,
            ID = id,
            PW = pw
        };
        userDataList.users.Add(newUser);
        UserDataManager.SaveUsers(userDataList);
        warningSign.SetTextWrarning("가입이 완료되었습니다");
    }
}
