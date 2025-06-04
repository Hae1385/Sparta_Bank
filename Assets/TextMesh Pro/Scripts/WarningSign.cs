using UnityEngine;
using UnityEngine.UI;

public class WarningSign : MonoBehaviour
{
    public Button ok;
    void Start()
    {
        this.gameObject.SetActive(false);
        ok.onClick.AddListener(onClickOk);
    }

    private void onClickOk()
    {
        this.gameObject.SetActive(false);
    }
}
