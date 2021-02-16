using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cityNameText;

    [SerializeField]
    private TextMeshProUGUI goldText;

    public void SetDisplay(string cityName, int goldProduction)
    {
        cityNameText.text = cityName;
        goldText.text = goldProduction.ToString();
    }
}
