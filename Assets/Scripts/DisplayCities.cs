using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCities : MonoBehaviour
{
    [SerializeField]
    private CityHandler cityHandler;

    [SerializeField]
    private CityDisplay cityGraphic;

    [SerializeField]
    private TextMeshProUGUI citiesNumberText;

    public void LoadCities()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        citiesNumberText.text = " Cities\n" + cityHandler.SavedCities.Count.ToString();

        for (int i = 0; i < cityHandler.SavedCities.Count; i++)
        {
            Instantiate(cityGraphic, transform as RectTransform).SetDisplay(cityHandler.SavedCities[i].name, cityHandler.SavedCities[i].gold);
        }
    }


}
