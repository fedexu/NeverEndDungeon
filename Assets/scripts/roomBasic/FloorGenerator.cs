using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public LevelSpriteElements elements;
    // 100 for 1% => (1) , 1000 for 0.1% => (1) && 1% => (10) ecc..
    private static int percentagePrecision = 1000;
    private static int floorLightPercentage = 1000;
    private static int floorDarkPercentage = 1000;
    private static int stairsPercentage = 500;

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
            case "FloorLight":
                randomSpriteGenerator("floor", elements.floorLight, floorLightPercentage);
                break;
            case "FloorDark":
                randomSpriteGenerator("floor", elements.floorDark, floorDarkPercentage);
                break;
            case "Stairs":
                randomSpriteGenerator("stairs", elements.stairs, stairsPercentage);
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

}
