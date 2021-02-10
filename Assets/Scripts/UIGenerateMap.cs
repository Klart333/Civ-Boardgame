using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGenerateMap : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField mapSizeInput;

    public void GenerateMap()
    {
        int mapSize = int.Parse(mapSizeInput.text);
    }
}
