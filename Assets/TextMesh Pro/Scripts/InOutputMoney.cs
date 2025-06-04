using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InOutputMoney : MonoBehaviour
{
    GameManager gameManager;
    UserData userData;

    [Header("InOutButton")]
    public GameObject standard;
    public GameObject InputMoney;
    public GameObject OutputMoney;
    public Button InputMoneyBtn;
    public Button OutputMoneyBtn;
    public Button InputCancle;
    public Button OutputCancle;

    [Header("InOutMoneyBtn")]
    public Button inputTenThousand;
    public Button inputThirtyThousand;
    public Button inputFiftyThousand;
    public TMP_InputField inputField;
    public Button inputFieldBtn;

    public Button outputTenThousand;
    public Button outputThirtyThousand;
    public Button outputFiftyThousand;
    public TMP_InputField outputField;
    public Button outputFieldBtn;

    public GameObject WarningSign;

    private void Start()
    {
        gameManager =FindObjectOfType<GameManager>();
        userData = gameManager.userData;

        InputMoney.SetActive(false);
        OutputMoney.SetActive(false);
        WarningSign.SetActive(false);

        InputMoneyBtn.onClick.AddListener(OnInputMoneyBtn);
        OutputMoneyBtn.onClick.AddListener(OnOutputMoneyBtn);
        InputCancle.onClick.AddListener(OnCancleBtn);
        OutputCancle.onClick.AddListener(OnCancleBtn);

        inputTenThousand.onClick.AddListener(OnInputTen);
        inputThirtyThousand.onClick.AddListener(OnInputThirty);
        inputFiftyThousand.onClick.AddListener(OnInputFifty);
        outputTenThousand.onClick.AddListener(OnOutputTen);
        outputThirtyThousand.onClick.AddListener(OnOutputThirty);
        outputFiftyThousand.onClick.AddListener(OnOutputFifty);
        inputFieldBtn.onClick.AddListener(OnInputField);
        outputFieldBtn.onClick.AddListener(OnOutputField);
    }

    public void OnInputMoneyBtn()
    {
        standard.SetActive(false);
        InputMoney.SetActive(true);
    }

    public void OnOutputMoneyBtn()
    {
        standard.SetActive(false);
        OutputMoney.SetActive(true);
    }

    public void OnCancleBtn()
    {
        InputMoney.SetActive(false);
        OutputMoney.SetActive(false);
        standard.SetActive(true);
    }

    public void OnInputTen()
    {
        if (!gameManager.userData.InputMoney(10000))
        {
            WarningSign.SetActive(true);
        }

    }

    public void OnInputThirty()
    {
        if (!gameManager.userData.InputMoney(30000))
        {
            WarningSign.SetActive(true);
        }
    }

    public void OnInputFifty()
    {
        if (!gameManager.userData.InputMoney(50000))
        {
            WarningSign.SetActive(true);
        }
    }

    public void OnOutputTen()
    {
        if (!gameManager.userData.OutputMoney(10000))
        {
            WarningSign.SetActive(true);
        }
    }

    public void OnOutputThirty()
    {
        if (!gameManager.userData.OutputMoney(30000))
        {
            WarningSign.SetActive(true);
        }
    }

    public void OnOutputFifty()
    {
        if (!gameManager.userData.OutputMoney(50000))
        {
            WarningSign.SetActive(true);
        }
    }

    public void OnInputField()
    {
        string input = inputField.text;
        int inputvalue;

        if(int.TryParse(input, out inputvalue))
        {
            if (!gameManager.userData.InputMoney(inputvalue))
            {
                WarningSign.SetActive(true);
            }
        }
        else
        {
            WarningSign.SetActive(true);
        }
    }

    public void OnOutputField()
    {
        string output = outputField.text;
        int outputvalue;

        if (int.TryParse(output, out outputvalue))
        {
            if (!gameManager.userData.OutputMoney(outputvalue))
            {
                WarningSign.SetActive(true);
            }
        }
        else
        {
            WarningSign.SetActive(true);
        }
    }
}
