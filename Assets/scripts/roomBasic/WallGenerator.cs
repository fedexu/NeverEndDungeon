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
                wallsRandomGenerator();
                break;
            // case 4:
            //     guardsRandomGenerator();
            //     break;
            // case 3:
            //     sideGuardsRandomGenerator();
            //     break;
            // case 2:
            //     backGuardsRandomGenerator();
            //     break;
            default:
                Debug.Log(component + " : Not handled component");
                break;
        }
    }

    private void wallsRandomGenerator()
    {
        SpriteRenderer spriteRenderer = transform.Find("wall").transform.gameObject.GetComponent<SpriteRenderer>();
        // default the first occurrence of the sprites
        spriteRenderer.sprite = walls[0];

        if (Random.Range(0, percentagePrecision) <= wallPercentage)
        {
            spriteRenderer.sprite = walls[Random.Range(1, walls.Length)];
        }

    }

    private void guardsRandomGenerator()
    {

    }

    private void sideGuardsRandomGenerator()
    {

    }

    private void backGuardsRandomGenerator()
    {

    }

}
