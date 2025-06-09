using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AddUser : MonoBehaviour
{
    private UserData userData;
    GameManager gameManager;

    public TMP_InputField inputName;
    public TMP_InputField inputID;
    public TMP_InputField inputPW;
    public Button addUser;
    public Button cancle;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        this.gameObject.SetActive(false);
        addUser.onClick.AddListener(AddUsers);
        cancle.onClick.AddListener(Cancle);
    }

    private void Cancle()
    {
        this.gameObject.SetActive(false);
    }

    private void AddUsers()
    {
        string name = inputName.text;
        string id = inputID.text;
        string pw = inputPW.text;

        //userData = ScriptableObject.CreateInstance<UserData>();
        //userData.UserName = name;
        //userData.Banlance = 0;
        //userData.Cash = 0;
        //userData.ID = id;
        //userData.PW = pw;

        //string assetPath = $"Assets/TextMesh Pro/Resources/Data/UserData/{id}.asset";
        //AssetDatabase.CreateAsset(userData, assetPath);
        //AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();

        gameManager.AddUser(name, id, pw);
        Debug.Log(Application.persistentDataPath);
    }
    //userData = ScriptableObject.CreateInstance<UserData>()
}
