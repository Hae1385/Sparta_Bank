using TMPro;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public TextMeshProUGUI UserName;
    public TextMeshProUGUI Banlance;
    public TextMeshProUGUI Cash;
    public string userName;
    public int banlance;
    public int cash;

    private void Start()
    {
        
    }

    private void Update()
    {
        UpdateCash();
    }

    public void UpdateCash()
    {
        UserName.text = userName;
        Banlance.text = string.Format("{0:N0}", banlance);
        Cash.text = string.Format("{0:N0}", cash);
    }
}
