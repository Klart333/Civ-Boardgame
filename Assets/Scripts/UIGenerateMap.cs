using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIGenerateMap : MonoBehaviour
{
    private const int grassIndex = 0;
    private const int grassWithWaterIndex = 1;
    private const int stoneIndex = 2;
    private const int treeIndex = 3;
    private const int snowIndex = 4;
    private const int riverIndex = 5;
    private const int sandIndex = 6;
    private const int goldIndex = 7;

    private const int maxGrassAmount = 20;
    private const int maxGrassWithWaterAmount = 10;
    private const int maxStoneAmount = 20;
    private const int maxTreeAmount = 30;
    private const int maxSnowAmount = 20;
    private const int maxRiverAmount = 20;
    private const int maxSandAmount = 19;
    private const int maxGoldAmount = 5;

    [SerializeField]
    private TMP_InputField mapSizeInput;

    [SerializeField]
    private Image baseBrick;

    [SerializeField]
    private Sprite[] sprites;

    private GridLayoutGroup gridLayoutGroup;

    private List<GameObject> bricks = new List<GameObject>();

    private void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    public void GenerateMap()
    {
        // Deleting map
        {
            if (bricks.Count != 0)
            {
                for (int i = 0; i < bricks.Count; i++)
                {
                    Destroy(bricks[i]);
                }
                bricks.Clear();
            }
        }

        int mapSize = 0;
        int.TryParse(mapSizeInput.text, out mapSize);
        if (mapSize == 0)
        {
            return;
        }

        // Grid layout group settings
        {
            gridLayoutGroup.cellSize = new Vector2((float)Mathf.Abs((transform as RectTransform).rect.width) / (float)mapSize, (float)Mathf.Abs((transform as RectTransform).rect.height) / (float)mapSize);
        }

        int totalBrickAmount = Mathf.RoundToInt(Mathf.Pow(mapSize, 2));
        int[] brickIndexArray = new int[totalBrickAmount];

        // Brick amounts
        int grassAmount = Mathf.FloorToInt(((float)mapSize / 12.0f) * maxGrassAmount);
        int grassWithWaterAmount = Mathf.FloorToInt(((float)mapSize / 12.0f) * maxGrassWithWaterAmount);
        int stoneAmount = Mathf.FloorToInt(((float)mapSize / 12.0f) * maxStoneAmount);
        int treeAmount = Mathf.FloorToInt(((float)mapSize / 12.0f) * maxTreeAmount);
        int snowAmount = Mathf.FloorToInt(((float)mapSize / 12.0f) * maxSnowAmount);
        int riverAmount = Mathf.FloorToInt(((float)mapSize / 12.0f) * maxRiverAmount);
        int sandAmount = Mathf.FloorToInt(((float)mapSize / 12.0f) * maxSandAmount);
        int goldAmount = Mathf.FloorToInt(((float)mapSize / 12.0f) * maxGoldAmount);
        
        

        int brickAmount = grassAmount + grassWithWaterAmount + stoneAmount + treeAmount + snowAmount + riverAmount + sandAmount + goldAmount;
        if (brickAmount < totalBrickAmount) // Incase we floored some bricks away
        {
            grassAmount += totalBrickAmount - brickAmount;
            brickAmount = totalBrickAmount;
        }

        for (int i = 0; i < brickIndexArray.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, brickAmount);

            // Check what brick
            {
                if (randomIndex <= grassAmount) // I don't like it either... ok? dont fix what aint broke
                {
                    brickIndexArray[i] = grassIndex;
                    grassAmount--;
                    brickAmount--;
                }
                else if (randomIndex <= grassAmount + grassWithWaterAmount)
                {
                    brickIndexArray[i] = grassWithWaterIndex;
                    grassWithWaterAmount--;
                    brickAmount--;
                }
                else if (randomIndex <= grassAmount + grassWithWaterAmount + stoneAmount)
                {
                    brickIndexArray[i] = stoneIndex;
                    stoneAmount--;
                    brickAmount--;
                }
                else if (randomIndex <= grassAmount + grassWithWaterAmount + stoneAmount + treeAmount)
                {
                    brickIndexArray[i] = treeIndex;
                    treeAmount--;
                    brickAmount--;
                }
                else if (randomIndex <= grassAmount + grassWithWaterAmount + stoneAmount + treeAmount + snowAmount)
                {
                    brickIndexArray[i] = snowIndex;
                    snowAmount--;
                    brickAmount--;
                }
                else if (randomIndex <= grassAmount + grassWithWaterAmount + stoneAmount + treeAmount + snowAmount + riverAmount)
                {
                    brickIndexArray[i] = riverIndex;
                    riverAmount--;
                    brickAmount--;
                }
                else if (randomIndex <= grassAmount + grassWithWaterAmount + stoneAmount + treeAmount + snowAmount + riverAmount + sandAmount)
                {
                    brickIndexArray[i] = sandIndex;
                    sandAmount--;
                    brickAmount--;
                }
                else if (randomIndex <= grassAmount + grassWithWaterAmount + stoneAmount + treeAmount + snowAmount + riverAmount + sandAmount + goldAmount)
                {
                    brickIndexArray[i] = goldIndex;
                    goldAmount--;
                    brickAmount--;
                }
                else // Shouldn't get here 
                {
                    Debug.LogError("index outside the brick amount");
                    brickIndexArray[i] = goldIndex;
                    goldAmount--;
                    brickAmount--;
                }
            }
            
        }

        StartCoroutine(GenerateMapGraphic(brickIndexArray));
    }

    private IEnumerator GenerateMapGraphic(int[] brickIndexArray)
    {
        for (int i = 0; i < brickIndexArray.Length; i++)
        {
            var brick = Instantiate(baseBrick, transform);
            switch (brickIndexArray[i])
            {
                case grassIndex:
                    brick.sprite = sprites[0];
                    break;
                case grassWithWaterIndex:
                    brick.sprite = sprites[1];
                    break;
                case stoneIndex:
                    brick.sprite = sprites[2];
                    break;
                case treeIndex:
                    brick.sprite = sprites[3];
                    break;
                case snowIndex:
                    brick.sprite = sprites[4];
                    break;
                case riverIndex:
                    brick.sprite = sprites[5];
                    break;
                case sandIndex:
                    brick.sprite = sprites[6];
                    break;
                case goldIndex:
                    brick.sprite = sprites[7];
                    break;
                default:
                    brick.sprite = sprites[0];
                    break;
            }

            bricks.Add(brick.gameObject);
            yield return new WaitForSeconds(0.005f);
        }
    }
}
