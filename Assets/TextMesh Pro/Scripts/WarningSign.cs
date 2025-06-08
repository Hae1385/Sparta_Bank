using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarningSign : MonoBehaviour
{
    public Button ok;
    public GameObject warningSignpopup;
    public TextMeshProUGUI warningSign;

    void Start()
    {
        this.gameObject.SetActive(false);
        ok.onClick.AddListener(onClickOk);
    }

    public void SetTextWrarning(string warning)
    {
        warningSignpopup.gameObject.SetActive(true);
        warningSign.text = warning;
    }
    
    private void onClickOk()
    {
        this.gameObject.SetActive(false);
    }
}
