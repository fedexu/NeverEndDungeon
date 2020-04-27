using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

    public LevelSpriteElements elements;

    // 100 for 1% => (1) , 1000 for 0.1% => (1) && 1% => (10) ecc..
    private static int percentagePrecision = 1000;
    private static int wallPercentage = 200;
    private static int guardPercentage = 500;
    private static int cosmeticPercentage = 100;
    private static int cosmeticCollisionPercentage = 50;
    private static int columnPercentage = 50;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("startDelay", 2f);

    }

    private void startDelay()
    {
        elements = SpriteLevelController.Instance.levelSprites;

        string component = transform.gameObject.tag;
        switch (component)
        {
            case "Wall_1_A":
                addWallCosmetic();
                randomSpriteGenerator("guard", elements.guards, guardPercentage);
                break;
            case "Wall_1_A_noCosmetic":
                randomSpriteGenerator("wall", new Sprite[] { elements.walls[0] }, 0);
                randomSpriteGenerator("guard", elements.guards, guardPercentage);
                break;
            case "Wall_1_B":
            case "Wall_1_C":
                randomSpriteGenerator("wall", new Sprite[] { elements.walls[0] }, 0);
                randomSpriteGenerator("guard", elements.guardsAngleUp, 0);
                break;
            case "Wall_2_A":
                randomSpriteGenerator("guard", elements.backGuards, guardPercentage);
                break;
            case "Wall_2_B":
            case "Wall_2_C":
                randomSpriteGenerator("guard", elements.guardsAngleDown, 0);
                break;
            case "Wall_2_D":
            case "Wall_2_E":
                randomSpriteGenerator("guard", elements.sideGuards, guardPercentage);
                break;
            case "Wall_2_F":
            case "Wall_2_G":
                randomSpriteGenerator("guard", elements.guardsLeft, 0);
                break;
            case "Wall_2_H":
            case "Wall_2_I":
                randomSpriteGenerator("guard", elements.guardsRight, 0);
                break;
            case "Wall_2_L":
                randomSpriteGenerator("arch", elements.arch, 0);
                break;
            default:
                Debug.Log(component + " : Not handled component");
                break;
        }
    }

    private bool randomSpriteGenerator(string elementToFind, Sprite[] spritesToChoose, int chancePercentage)
    {
        SpriteRenderer spriteRenderer = transform.Find(elementToFind).transform.gameObject.GetComponent<SpriteRenderer>();
        // default the first occurrence of the sprites
        spriteRenderer.sprite = spritesToChoose[0];

        if (Random.Range(0, percentagePrecision) <= chancePercentage)
        {
            //do "chancePercentage" times
            spriteRenderer.sprite = spritesToChoose[Random.Range(0, spritesToChoose.Length)];
            return true;
        }
        return false;
    }

    private void addWallCosmetic()
    {
        if (!randomSpriteGenerator("wall", elements.walls, wallPercentage))
        {
            //add cosmetic object only if simple wall is picked
            if (!randomSpriteGenerator("cosmetic", elements.cosmetics, cosmeticPercentage))
            {
                if (!randomSpriteGenerator("cosmeticCollision", elements.cosmeticsCollision, cosmeticCollisionPercentage))
                {
                    if (randomSpriteGenerator("column", elements.column, columnPercentage))
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
