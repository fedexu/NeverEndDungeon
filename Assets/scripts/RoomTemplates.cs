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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
