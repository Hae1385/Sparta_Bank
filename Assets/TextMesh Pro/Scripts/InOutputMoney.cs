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
    public GameObject SendMoney;
    public Button InputMoneyBtn;
    public Button OutputMoneyBtn;
    public Button SendMoneyBtn;
    public Button InputCancle;
    public Button OutputCancle;
    public Button SendCancle;

    [Header("InputMoneyBtn")]
    public Button inputTenThousand;
    public Button inputThirtyThousand;
    public Button inputFiftyThousand;
    public TMP_InputField inputField;
    public Button inputFieldBtn;

    [Header("OutputMoneyBtn")]
    public Button outputTenThousand;
    public Button outputThirtyThousand;
    public Button outputFiftyThousand;
    public TMP_InputField outputField;
    public Button outputFieldBtn;
    public Button sendMoney;

    [Header("SendMoneyTMP")]
    public TMP_InputField sendInputID;
    public TMP_InputField sendInputMoney;

    private void Start()
    {
        gameManager =FindObjectOfType<GameManager>();

        userData = gameManager.userdata;

        InputMoney.SetActive(false);
        OutputMoney.SetActive(false);
        SendMoney.SetActive(false);

        InputMoneyBtn.onClick.AddListener(OnInputMoneyBtn);
        OutputMoneyBtn.onClick.AddListener(OnOutputMoneyBtn);
        SendMoneyBtn.onClick.AddListener(OnSendMoenyBtn);
        InputCancle.onClick.AddListener(OnCancleBtn);
        OutputCancle.onClick.AddListener(OnCancleBtn);
        SendCancle.onClick.AddListener(OnCancleBtn);

        inputTenThousand.onClick.AddListener(() => OnInputMoney(10000));
        inputThirtyThousand.onClick.AddListener(() => OnInputMoney(30000));
        inputFiftyThousand.onClick.AddListener(() => OnInputMoney(50000));
        outputTenThousand.onClick.AddListener(() => OnOutputMoney(10000));
        outputThirtyThousand.onClick.AddListener(() => OnOutputMoney(30000));
        outputFiftyThousand.onClick.AddListener(() => OnOutputMoney(50000));
        inputFieldBtn.onClick.AddListener(OnInputField);
        outputFieldBtn.onClick.AddListener(OnOutputField);
        sendMoney.onClick.AddListener(OnSendMoney);
    }

    public void OnInputMoneyBtn()
    {
        if (gameManager.userdata == null)
        {
            return;
        }
        standard.SetActive(false);
        InputMoney.SetActive(true);
    }
    
    public void OnOutputMoneyBtn()
    {
        if (gameManager.userdata == null)
        {
            return;
        }
        standard.SetActive(false);
        OutputMoney.SetActive(true);
    }

    public void OnSendMoenyBtn()
    {
        if (gameManager.userdata == null)
        {
            return;
        }
        standard.SetActive(false);
        SendMoney.SetActive(true);
    }

    public void OnCancleBtn()
    {
        InputMoney.SetActive(false);
        OutputMoney.SetActive(false);
        SendMoney.SetActive(false);
        standard.SetActive(true);
    }

    public void OnInputMoney(int money)
    {
        if (!gameManager.userdata.InputMoney(money))
        {
            gameManager.warningSign.SetTextWrarning("금액이\n부족합니다");
        }
    }

    public void OnOutputMoney(int money)
    {
        if (!gameManager.userdata.OutputMoney(money))
        {
            gameManager.warningSign.SetTextWrarning("금액이\n부족합니다");
        }
    }

    public void OnInputField()
    {
        string input = inputField.text;
        int inputvalue;

        if(int.TryParse(input, out inputvalue))
        {
            if (!gameManager.userdata.InputMoney(inputvalue))
            {
                gameManager.warningSign.SetTextWrarning("금액이\n부족합니다");
            }
        }
        else
        {
            gameManager.warningSign.SetTextWrarning("금액이\n부족합니다");
        }
    }

    public void OnOutputField()
    {
        string output = outputField.text;
        int outputvalue;

        if (int.TryParse(output, out outputvalue))
        {
            if (!gameManager.userdata.OutputMoney(outputvalue))
            {
                gameManager.warningSign.SetTextWrarning("금액이\n부족합니다");
            }
        }
        else
        {
            gameManager.warningSign.SetTextWrarning("금액이\n부족합니다");
        }
    }

    public void OnSendMoney()
    {
        string inputID = sendInputID.text;
        string inputMoney = sendInputMoney.text;
        int inputMoneyValue;
        int.TryParse(inputMoney, out inputMoneyValue);

        UserData foundUser;
        int founded;
        if(FindUser(inputID, inputMoneyValue, out foundUser, out founded))
        {
            gameManager.warningSign.SetTextWrarning("송금\n완료");
        }
        else
        {
            return;
        }
    }

    public bool FindUser(string inputID, int inputMoney, out UserData match, out int matchNumber)
    {
        match = null;
        matchNumber = -1;

        if (gameManager.userDatas == null || gameManager.userDatas.Length == 0)
        {
            return false;
        }
        for (int i = 0; i < gameManager.userDatas.Length; i++)
        {
            if (gameManager.userDatas[i].ID == inputID)
            {
                match = gameManager.userDatas[i];
                matchNumber = i;

                if (inputMoney > gameManager.userdata.Banlance)
                {
                    gameManager.warningSign.SetTextWrarning("금액이\n부족합니다");
                    return false;
                }
                if (inputMoney == 0)
                {
                    gameManager.warningSign.SetTextWrarning("올바른 값을\n입력해주세요");
                    return false;
                }
                gameManager.userdata.Banlance -= inputMoney;
                gameManager.userDatas[i].Banlance += inputMoney;
                return true;
            }
        }
        gameManager.warningSign.SetTextWrarning("대상이\n잘못됐습니다");
        return false;
    }
}
