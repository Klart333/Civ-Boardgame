using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityHandler : MonoBehaviour
{
    public const int goldGoldAmount = 100;
    public const int grassGoldAmount = 40;
    public const int riverGoldAmount = 75;
    public const int grassWithWaterGoldAmount = 60;
    public const int sandGoldAmount = 5;
    public const int snowGoldAmount = 15;
    public const int stoneGoldAmount = 50;
    public const int treeGoldAmount = 50;

    [SerializeField]
    private TMP_InputField nameInput;

    [SerializeField]
    private TMP_InputField goldInput;

    [SerializeField]
    private TMP_InputField grassInput;

    [SerializeField]
    private TMP_InputField riverInput;

    [SerializeField]
    private TMP_InputField grassWithWaterInput;

    [SerializeField]
    private TMP_InputField sandInput;

    [SerializeField]
    private TMP_InputField snowInput;

    [SerializeField]
    private TMP_InputField stoneInput;

    [SerializeField]
    private TMP_InputField treeInput;

    [HideInInspector]
    public List<City> SavedCities = new List<City>();

    public void AddCity()
    {
        var city = new City(nameInput.text, (string.IsNullOrEmpty(goldInput.text) ? 0 : int.Parse(goldInput.text) * goldGoldAmount) + (string.IsNullOrEmpty(grassInput.text) ? 0 : int.Parse(grassInput.text) * grassGoldAmount) + (string.IsNullOrEmpty(riverInput.text) ? 0 : int.Parse(riverInput.text) * riverGoldAmount) + (string.IsNullOrEmpty(grassWithWaterInput.text) ? 0 : int.Parse(grassWithWaterInput.text) * grassWithWaterGoldAmount) + (string.IsNullOrEmpty(sandInput.text) ? 0 : int.Parse(sandInput.text) * sandGoldAmount) + (string.IsNullOrEmpty(snowInput.text) ? 0 : int.Parse(snowInput.text) * snowGoldAmount) + (string.IsNullOrEmpty(stoneInput.text) ? 0 : int.Parse(stoneInput.text) * stoneGoldAmount) + (string.IsNullOrEmpty(treeInput.text) ? 0 : int.Parse(treeInput.text) * treeGoldAmount));
        SavedCities.Add(city);
    }
}

public struct City
{
    public string name;
    public int gold;

    public City(string name, int gold)
    {
        this.name = name;
        this.gold = gold;
    }
}
