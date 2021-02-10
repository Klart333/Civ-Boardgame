using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public Sprite[] Sides;
    public SpriteRenderer Render;
    // Start is called before the first frame update
    void Start()
    {
        Render = GetComponent<SpriteRenderer>();

     
    }

    private void OnMouseDown()
    {
        StartCoroutine("RollDice");
    }

    private IEnumerator RollDice()
    {
         int randomDiceSide = 0;
        int finalSide = 0;

        for (int i = 0; i <= 20; i++)
        {

            randomDiceSide = Random.Range(0, 6);
            Render.sprite = Sides[randomDiceSide];
            yield return new WaitForSeconds(0.1f);
        }
        finalSide = randomDiceSide + 1;
        Debug.Log("Dice has rolled");
    }
}
