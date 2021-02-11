using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceHandler : MonoBehaviour
{
    public Sprite[] Sides;

    [SerializeField]
    private GameObject dice;

    [SerializeField]
    private TextMeshProUGUI spinningText;

    [SerializeField]
    private TextMeshProUGUI resultText;

    [SerializeField]
    private Button rollButton;

    private List<SpriteRenderer> die = new List<SpriteRenderer>();

    private int dieResult = 0;

    private Vector2 diceSpawnPosition = new Vector2(0, -3);

    private int maxDice = 7;
    private int diceCount = 0;

    private void Start()
    {
        IncreaseDieAmount();
    }

    public void IncreaseDieAmount()
    {
        if (diceCount >= maxDice)
        {
            return;
        }

        diceCount++;

        if (die.Count % 2 == 0) // Even
        {
            var _dice = Instantiate(dice, diceSpawnPosition, Quaternion.identity);
            die.Add(_dice.GetComponent<SpriteRenderer>());
            diceSpawnPosition.x += _dice.transform.localScale.x * 1.1f;
        }
        else // Odd
        {
            die.Add(Instantiate(dice, new Vector2(-diceSpawnPosition.x, diceSpawnPosition.y), Quaternion.identity).GetComponent<SpriteRenderer>());
        }
        
    }

    public void DecreaseDieAmount()
    {
        if (diceCount <= 0)
        {
            return;
        }

        diceCount--;

        var diceToRemove = die[die.Count - 1];
        diceSpawnPosition.x -= die.Count % 2 != 0 ? diceToRemove.transform.localScale.x * 1.1f : 0;
        Destroy(diceToRemove.gameObject);
        die.Remove(diceToRemove);
    }

    public void RollDice()
    {
        dieResult = 0;

        StartCoroutine(SecondStageEarInfection());
    }

    private IEnumerator SecondStageEarInfection()
    {
        rollButton.interactable = false;
        spinningText.gameObject.SetActive(true);

        yield return RollDiceGraphic();

        spinningText.gameObject.SetActive(false);
        rollButton.interactable = true;

        resultText.text = dieResult.ToString();
    }

    private IEnumerator RollDiceGraphic()
    {
        int dieSpins = 10;

        for (int i = 0; i < dieSpins; i++)
        {
            for (int g = 0; g < die.Count; g++)
            {
                int randomDieSide = Random.Range(0, 6);
                die[g].sprite = Sides[randomDieSide];

                if (i == dieSpins - 1)
                {
                    dieResult += randomDieSide + 1;
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
