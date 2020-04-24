using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int maxRoomsNumber = 32;

    private float waitTime = 2f;
    private bool completedDungeon = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // when things got finish to load
        if (waitTime <= 0 && completedDungeon == false)
        {
            //TO DO add ladder to last room to go to the next level

            //TO DO close all the open door
            closeDungeonDoor();

            completedDungeon = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
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
                }
            }
            if (describer.roomType.IndexOf("B") != -1)
            {
                if (describer.bottomRoom == null)
                {
                    // need to spawn a room with TOP door
                    GameObject obj = Instantiate(closedRoomT, room.transform.position, Quaternion.identity);
                    obj.name = closedRoomT.name;
                }
            }
            if (describer.roomType.IndexOf("R") != -1)
            {
                if (describer.rightRoom == null)
                {
                    // need to spawn a room with LEFT door
                    GameObject obj = Instantiate(closedRoomL, room.transform.position, Quaternion.identity);
                    obj.name = closedRoomL.name;
                }
            }
            if (describer.roomType.IndexOf("L") != -1)
            {
                if (describer.leftRoom == null)
                {
                    // need to spawn a room with RIGHT door
                    GameObject obj = Instantiate(closedRoomR, room.transform.position, Quaternion.identity);
                    obj.name = closedRoomR.name;
                }
            }
        }

    }
}
