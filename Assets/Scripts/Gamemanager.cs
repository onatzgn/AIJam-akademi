using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text[] randomNumbersTexts;
    public InputField[] inputFields;
    public Button checkButton;
    public Text resultText;
    public Text timerText;

    private int[] randomNumbers;
    private float timer = 50f;

    void Start()
    {
        GenerateRandomNumbers();
        checkButton.onClick.AddListener(CheckOrder);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "sure: " + Mathf.Ceil(timer).ToString();

        if (timer <= 0)
        {
            timer = 0;
            checkButton.interactable = false;
            resultText.text = "zaman doldu tekrar dene";
        }
    }

    void GenerateRandomNumbers()
    {
        randomNumbers = new int[5];
        for (int i = 0; i < randomNumbers.Length; i++)
        {
            randomNumbers[i] = Random.Range(1, 33);
            randomNumbersTexts[i].text = randomNumbers[i].ToString();
        }
    }

    void CheckOrder()
    {
        int[] userOrder = new int[5];
        for (int i = 0; i < inputFields.Length; i++)
        {
            if (int.TryParse(inputFields[i].text, out int value))
            {
                userOrder[i] = value;
            }
            else
            {
                resultText.text = "gecersiz giris lutfen sayi gir";
                return;
            }
        }

        int[] correctOrder = randomNumbers.OrderByDescending(n => n).ToArray();
        if (userOrder.SequenceEqual(correctOrder))
        {
            resultText.text = "Doğru sıraladın sıradaki asamaya geç";
            SceneManager.LoadScene("NextSceneName");
        }
        else
        {
            resultText.text = "yanlış sıraladın tekrar dene";
        }
    }
}