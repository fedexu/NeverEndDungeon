using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

    public Sprite[] walls;
    public Sprite[] guards;
    public Sprite[] sideGuards;
    public Sprite[] backGuards;
    public Sprite[] cosmetics;
    public Sprite[] cosmeticsCollision;
    public Sprite[] column;

    // 100 for 1% => (1) , 1000 for 0.1% => (1) && 1% => (10) ecc..
    private static int percentagePrecision = 1000;
    private static int wallPercentage = 200;
    private static int guardPercentage = 500;
    private static int cosmeticPercentage = 100;
    private static int cosmeticCollisionPercentage = 50;
    private static int columnPercentage = 50;
    private static int torchPercentage = 400;

    // Start is called before the first frame update
    void Start()
    {
        string component = transform.gameObject.tag;
        switch (component)
        {
            case "Wall_1_A":
                addWallCosmetic();
                randomSpriteGenerator("guard", guards, guardPercentage);
                break;
            case "Wall_2_A":
                randomSpriteGenerator("guard", backGuards, guardPercentage);
                break;
            case "Wall_2_D":
            case "Wall_2_E":
                randomSpriteGenerator("guard", sideGuards, guardPercentage);
                break;
            case "torch":
                randomTorch("Torch", torchPercentage);
                break;
            default:
                Debug.Log(component + " : Not handled component");
                break;
        }
    }

    private bool randomTorch(string elementToFind, int chancePercentage){
        GameObject torch = transform.Find(elementToFind).transform.gameObject;

        if (Random.Range(0, percentagePrecision) <= chancePercentage){
            torch.SetActive(false);
            return true;
        }
        return false;
    }

    private bool randomSpriteGenerator(string elementToFind, Sprite[] spritesToChoose, int chancePercentage)
    {
        SpriteRenderer spriteRenderer = transform.Find(elementToFind).transform.gameObject.GetComponent<SpriteRenderer>();
        // default the first occurrence of the sprites
        spriteRenderer.sprite = spritesToChoose[0];

        if (Random.Range(0, percentagePrecision) <= chancePercentage)
        {
            //do "chancePercentage" times
            spriteRenderer.sprite = spritesToChoose[Random.Range(1, spritesToChoose.Length)];
            return true;
        }
        return false;
    }

    private void addWallCosmetic()
    {
        if (!randomSpriteGenerator("wall", walls, wallPercentage))
        {
            //add cosmetic object only if simple wall is picked
            if (!randomSpriteGenerator("cosmetic", cosmetics, cosmeticPercentage))
            {
                if (!randomSpriteGenerator("cosmeticCollision", cosmeticsCollision, cosmeticCollisionPercentage))
                {
                    if (randomSpriteGenerator("column", column, columnPercentage))
                    {
                        transform.Find("column").transform.gameObject.SetActive(true);
                    }
                }
                else
                {
                    transform.Find("cosmeticCollision").transform.gameObject.SetActive(true);
                }
            }
            else
            {
                transform.Find("cosmetic").transform.gameObject.SetActive(true);
            }
        }
    }

}
