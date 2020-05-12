using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTemplates : MonoBehaviour
{

    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoomT;
    public GameObject closedRoomB;
    public GameObject closedRoomL;
    public GameObject closedRoomR;
    //controller Variables
    public List<GameObject> rooms;
    public GameObject dungeonContainer;
    public int maxRoomsNumber = 32;

    private float waitTime = 4f;
    private bool completedDungeon = false;

    public GameController gameController;
    private GameObject JoypadLayer;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        JoypadLayer = GameObject.FindGameObjectWithTag("JoypadLayer");
        JoypadLayer.transform.gameObject.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // when things got finish to load
        if (rooms.Count >= maxRoomsNumber && completedDungeon == false)
        {
            //TO DO add ladder to last room to go to the next level

            //TO DO close all the open door
            Invoke("closeDungeonDoor", 0.5f);

            completedDungeon = true;

            if (gameController.GetLevelLoader().isLoading())
            {
                gameController.GetLevelLoader().removeLoadingLayer(true);
            }
            // if (SystemInfo.deviceType == DeviceType.Handheld){
            JoypadLayer.transform.gameObject.GetComponent<CanvasGroup>().alpha = 1;
            // }

        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }


    public bool isCompletedCreation()
    {
        return completedDungeon;
    }

    // when spawning is done, this will close the dungeon exits
    private void closeDungeonDoor()
    {
        foreach (GameObject room in rooms)
        {
            RoomDescriber describer = room.gameObject.GetComponent<RoomDescriber>();
            if (describer.roomType.IndexOf("T") != -1)
            {
                if (describer.topRoom == null)
                {
                    // need to spawn a room with BOTTOM door
                    GameObject obj = Instantiate(closedRoomB, room.transform.position, Quaternion.identity);
                    obj.name = closedRoomB.name;
                    obj.transform.SetParent(dungeonContainer.transform);
                }
            }
            if (describer.roomType.IndexOf("B") != -1)
            {
                if (describer.bottomRoom == null)
                {
                    // need to spawn a room with TOP door
                    GameObject obj = Instantiate(closedRoomT, room.transform.position, Quaternion.identity);
                    obj.name = closedRoomT.name;
                    obj.transform.SetParent(dungeonContainer.transform);
                }
            }
            if (describer.roomType.IndexOf("R") != -1)
            {
                if (describer.rightRoom == null)
                {
                    // need to spawn a room with LEFT door
                    GameObject obj = Instantiate(closedRoomL, room.transform.position, Quaternion.identity);
                    obj.name = closedRoomL.name;
                    obj.transform.SetParent(dungeonContainer.transform);
                }
            }
            if (describer.roomType.IndexOf("L") != -1)
            {
                if (describer.leftRoom == null)
                {
                    // need to spawn a room with RIGHT door
                    GameObject obj = Instantiate(closedRoomR, room.transform.position, Quaternion.identity);
                    obj.name = closedRoomR.name;
                    obj.transform.SetParent(dungeonContainer.transform);
                }
            }
        }

    }
}
