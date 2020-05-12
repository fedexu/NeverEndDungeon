using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class SpriteLevelController : MonoBehaviour
{

    public static SpriteLevelController Instance { get; private set; }

    public LevelSpriteElements level1Sprite;
    public LevelSpriteElements level2Sprite;
    public LevelSpriteElements level3Sprite;
    public LevelSpriteElements[] levelSprites;

    public bool spriteLoadedFromDb = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        // int levelToLoad = GameController.Instance.currentPlayerLevel;
        // levelSprites = new LevelSpriteElements();
        // Sprite[] sprites;
        // List<Sprite> spriteList;
        // //load Level Sprites
        // sprites = Array.ConvertAll(AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/sprites/environment/level_" + levelToLoad + "_floor.png"), item => item as Sprite);
        // spriteList = new List<Sprite>(sprites);
        // levelSprites.floorLight = spriteList.Take(6).ToArray();
        // levelSprites.floorDark = spriteList.Skip(6).Take(12).ToArray();
        // levelSprites.stairs = spriteList.Skip(18).Take(2).ToArray();

        // sprites = Array.ConvertAll(AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/sprites/environment/level_" + levelToLoad + "_guards.png"), item => item as Sprite);
        // levelSprites.guards = sprites.Take(2).ToArray();
        // levelSprites.backGuards = sprites.Skip(2).Take(2).ToArray();
        // levelSprites.sideGuards = sprites.Skip(4).Take(2).ToArray();
        // levelSprites.guardsAngleUp = sprites.Skip(6).Take(1).ToArray();
        // levelSprites.guardsAngleDown = sprites.Skip(7).Take(1).ToArray();
        // levelSprites.guardsRight = sprites.Skip(8).Take(1).ToArray();
        // levelSprites.guardsLeft = sprites.Skip(9).Take(1).ToArray();
        // levelSprites.arch = sprites.Skip(10).Take(1).ToArray();

        // sprites = Array.ConvertAll(AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/sprites/environment/level_" + levelToLoad + "_walls.png"), item => item as Sprite);
        // levelSprites.walls = sprites;

        // sprites = Array.ConvertAll(AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/sprites/environment/level_" + levelToLoad + "_cosmetic.png"), item => item as Sprite);
        // levelSprites.cosmetics = sprites.Take(6).ToArray();
        // levelSprites.cosmeticsCollision = sprites.Skip(6).Take(3).ToArray();
        // levelSprites.column = sprites.Skip(9).Take(1).ToArray();

        levelSprites = new LevelSpriteElements[10];
        levelSprites[0] = level1Sprite;
        levelSprites[1] = level2Sprite;
        levelSprites[2] = level3Sprite;

        spriteLoadedFromDb = true;
        // Debug.Log("End loading level sprites");
    }

    public static int spriteToLoad(int level){
        if (level <= 4 ){
            return 0;
        }
        
        if (level <= 8 ){
            return 1;
        }
        return 2;
    }

}
