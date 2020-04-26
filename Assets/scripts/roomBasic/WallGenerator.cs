using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

    public Sprite[] walls;
    public Sprite[] guards;
    public Sprite[] sideGuards;
    public Sprite[] backGuards;

    // 100 for 1% => (1) , 1000 for 0.1% => (1) && 1% => (10) ecc..
    private static int percentagePrecision = 1000;
    private static int wallPercentage = 400;
    private static int guardPercentage = 500;

    // Start is called before the first frame update
    void Start()
    {
        // int clickPercentage = 60;
        // if (Random.Range(0, percentagePrecision) < clickPercentage)
        // {
        //     //do 70% times
        // }

        string component = transform.gameObject.tag;
        switch (component)
        {
            case "Wall_1_A":
                randomSpriteGenerator("wall", walls, wallPercentage);
                randomSpriteGenerator("guard", guards, guardPercentage);
                break;
            case "Wall_2_A":
                randomSpriteGenerator("guard", backGuards, guardPercentage);
                break;
            case "Wall_2_D":
            case "Wall_2_E":
                randomSpriteGenerator("guard", sideGuards, guardPercentage);
                break;
            default:
                Debug.Log(component + " : Not handled component");
                break;
        }
    }

    private void randomSpriteGenerator(string elementToFind, Sprite[] spritesToChoose, int chancePercentage)
    {
        SpriteRenderer spriteRenderer = transform.Find(elementToFind).transform.gameObject.GetComponent<SpriteRenderer>();
        // default the first occurrence of the sprites
        spriteRenderer.sprite = spritesToChoose[0];

        if (Random.Range(0, percentagePrecision) <= chancePercentage)
        {
            spriteRenderer.sprite = spritesToChoose[Random.Range(1, spritesToChoose.Length)];
        }
    }

}
