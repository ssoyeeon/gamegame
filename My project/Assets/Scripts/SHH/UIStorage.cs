using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStorage : MonoBehaviour
{
    public List<TextMeshProUGUI> textMeshProUGUIList;
    public List<Button> buttonList;

    private Dictionary<string, TextMeshProUGUI> textDictionary = new Dictionary<string, TextMeshProUGUI>();
    private Dictionary<string, Button> buttonDictionary = new Dictionary<string, Button>();

    private void Start()
    {
        InIt();
    }

    private void InIt()
    {
        if(textMeshProUGUIList != null)
        {
            foreach (var text in textMeshProUGUIList)
            {
                textDictionary.Add(text.gameObject.name, text);
            }
        }

        if(buttonList != null)
        {
            foreach (var button in buttonList)
            {
                buttonDictionary.Add(button.gameObject.name, button);
            }
        }
    }

    public TextMeshProUGUI GetText(string textName)
    {
        if(textDictionary == null)
        {
            return null;
        }

        if(textDictionary.ContainsKey(textName))
        {
            return textDictionary[textName];
        }
        
        return null;
    }

    public Button GetButton(string textName)
    {
        if (buttonDictionary == null)
        {
            return null;
        }

        if(buttonDictionary.ContainsKey(textName))
        {
            return buttonDictionary[textName];
        }

        return null;
    }
}
