using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // 100 for 1% => (1) , 1000 for 0.1% => (1) && 1% => (10) ecc..
    private static int percentagePrecision = 1000;
    private static int torchPercentage = 400;
    // Start is called before the first frame update
    void Start()
    {
        string component = transform.gameObject.tag;
        switch (component)
        {
            case "torch":
                randomTorch(torchPercentage);
                break;
            default:
                Debug.Log(component + " : Not handled component");
                break;
        }
    }

    private bool randomTorch(int chancePercentage)
    {
        if (Random.Range(0, percentagePrecision) <= chancePercentage)
        {
            transform.gameObject.SetActive(false);
            return true;
        }
        return false;
    }

}
