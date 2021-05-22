using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldExample : MonoBehaviour
{
    [SerializeField] private List<string> lines;
    [SerializeField] private Text CurrentLineText;
    public event System.Action AddCoin;
    private int lastLine = -1;
    private string currentLine;

    private void Start()
    {
        NewLine();
    }

    private void NewLine()
    {
        var rnd = Random.Range(0, lines.Count);
        if(rnd == lastLine)
        {
            rnd = (rnd + 1) % lines.Count;
        }
        lastLine = rnd;
        currentLine = lines[lastLine];
        CurrentLineText.text = currentLine;
    }

    public void Example(Text input)
    {
        if(input.text == currentLine)
        {
            NewLine();
            // TODO: посмотреть как обнулить строку после редактирования.
            input.text = "";
            if (AddCoin != null) AddCoin(); 
        }
    }
}
