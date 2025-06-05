using TMPro;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    GameManager gameManager;

    public TextMeshProUGUI UserName;
    public TextMeshProUGUI Banlance;
    public TextMeshProUGUI Cash;
    [SerializeField] private string userName;
    [SerializeField] private int banlance;
    [SerializeField] private int cash;
    
    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        UpdateCash();
    }

    public void UpdateCash(bool changeCash = false)
    {
        bool change = changeCash;
        if (gameManager.userdata == null)
            return;

        if (userName != gameManager.userdata.UserName || banlance != gameManager.userdata.Banlance || cash != gameManager.userdata.Cash)
        {
            change = true;
        }

        if (change)
        {
            userName = gameManager.userdata.UserName;
            banlance = gameManager.userdata.Banlance;
            cash = gameManager.userdata.Cash;

            UserName.text = userName;
            Banlance.text = string.Format("{0:N0}", banlance);
            Cash.text = string.Format("{0:N0}", cash);
        }
    }
}
