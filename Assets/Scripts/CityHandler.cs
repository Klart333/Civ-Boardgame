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

    private List<City> savedCities = new List<City>();

    public void AddCity()
    {
        var city = new City(nameInput.text, int.Parse(goldInput.text) * goldGoldAmount + int.Parse(grassInput.text) * grassGoldAmount + int.Parse(riverInput.text) * riverGoldAmount + int.Parse(grassWithWaterInput.text) * grassWithWaterGoldAmount + int.Parse(sandInput.text) * sandGoldAmount + int.Parse(snowInput.text) * snowGoldAmount + int.Parse(stoneInput.text) * stoneGoldAmount + int.Parse(treeInput.text) * treeGoldAmount);
        savedCities.Add(city);
    }
}

struct City
{
    public string name;
    public int gold;

    public City(string name, int gold)
    {
        this.name = name;
        this.gold = gold;
    }
}
