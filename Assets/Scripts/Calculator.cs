using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textFieldFirstValue;
    [SerializeField] private TextMeshProUGUI textFieldSecondValue;
    [SerializeField] private TextMeshProUGUI textFieldResolt;
    [SerializeField] private TextMeshProUGUI symbolField;
    [SerializeField] private TextMeshProUGUI equalField;
    private float firstValue;
    private float secondValue;
    private float resolt;
    private bool isActiveSymbol;
    private string symbol;

    public void SetNumber(string number)
    {
        if (!isActiveSymbol)
        {
            textFieldFirstValue.text += number;
            firstValue = float.Parse(textFieldFirstValue.text);
        }

        else
        {
            textFieldSecondValue.text += number;
            secondValue = float.Parse(textFieldSecondValue.text);
        }
    }
    public void SetSymbol(string symbol)
    {
        this.symbol = symbol;
        symbolField.text = symbol;

        if (!isActiveSymbol)
            isActiveSymbol = true;

        else
        {
            textFieldFirstValue.text = resolt.ToString();
            firstValue = float.Parse(textFieldFirstValue.text);
            ResetField(textFieldSecondValue);
            ResetField(textFieldResolt);
        }
    }
    public void SetPoint(string point)
    {
        if (!isActiveSymbol)
        {
            if (textFieldFirstValue.text.Contains(','))
                return;
            else
                textFieldFirstValue.text += point;
        }
        else
        {
            if (textFieldSecondValue.text.Contains(','))
                return;
            else
                textFieldSecondValue.text += point;
        }
    }
    public void Calculation()
    {
        equalField.text = "=";
        Operations();
        textFieldResolt.text = resolt.ToString();
        if(textFieldSecondValue.text=="")
            textFieldResolt.text = firstValue.ToString();
    }
    private void Operations()
    {
        switch (symbol)
        {
            case "+":
                resolt = Addition();
                break;
            case "-":
                resolt = Subtraction();
                break;
            case "*":
                resolt = Multiplication();
                break;
            case "/":
                resolt = Division();
                break;
            case "^":
                resolt = PowCalculation();
                break;
        }
        
    }
    private float Addition() => firstValue + secondValue;
    private float Subtraction() => firstValue - secondValue;
    private float Multiplication() => firstValue * secondValue;
    private float Division() => firstValue / secondValue;
    private float PowCalculation() => Mathf.Pow(firstValue, secondValue);

    private void ResetField(TextMeshProUGUI field)
    {
        field.text = "";
    }
    public void ResetAll()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void DeliteLastNumber()
    {
        if (!isActiveSymbol)

        {
            if (textFieldFirstValue.text != "")
                textFieldFirstValue.text = textFieldFirstValue.text.Remove(textFieldFirstValue.text.Length - 1);
            else
                textFieldFirstValue.text = "";
        }    

        else
        {
            if (textFieldSecondValue.text != "")
                textFieldSecondValue.text = textFieldSecondValue.text.Remove(textFieldSecondValue.text.Length - 1);
            else
                textFieldSecondValue.text = "";
        }     
    }

    public void InterestCalculation()
    {
        secondValue = (firstValue * secondValue / 100);
        textFieldSecondValue.text = secondValue.ToString();
    }

    public void PiCalculation()
    {
        if (!isActiveSymbol)
        {
            firstValue = Mathf.PI;
            textFieldFirstValue.text = firstValue.ToString();
        }
        else
        {
            secondValue = Mathf.PI;
            textFieldSecondValue.text = secondValue.ToString();
        }
    }
   
    public void ChangePlusOrMinus()
    {
        if (textFieldResolt.text != "")
        {
            resolt = float.Parse(textFieldResolt.text);
            resolt = -resolt;
            textFieldResolt.text = resolt.ToString();
        }
        else if (textFieldSecondValue.text != "")
        {
            secondValue = -secondValue;
            textFieldSecondValue.text = secondValue.ToString();
        }
        else if (textFieldFirstValue.text != "")
        {
            firstValue = -firstValue;
            textFieldFirstValue.text = firstValue.ToString();
        }
    }
}
