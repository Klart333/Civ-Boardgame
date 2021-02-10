using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIConstrictInputField : MonoBehaviour
{
    [SerializeField]
    private bool useMax = true;

    private string currentAcceptedText = "";

    private TMP_InputField inputField;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void ConstrictInput()
    {
        string sizeText = inputField.text;
        if (sizeText.Length >= currentAcceptedText.Length)
        {
            string newText = sizeText.Remove(0, currentAcceptedText.Length);

            int result = 0;
            if (int.TryParse(newText, out result))
            {
                if (int.Parse(sizeText) > 12 && useMax)
                {
                    inputField.text = "12";
                    currentAcceptedText = "12";
                }
                else
                {
                    currentAcceptedText = sizeText;
                }
            }
            else
            {
                inputField.text = currentAcceptedText;
            }
        }
        else // Otherwise we are deleting 
        {
            currentAcceptedText = currentAcceptedText.Remove(currentAcceptedText.Length - 1);
        }
        
    }
}
