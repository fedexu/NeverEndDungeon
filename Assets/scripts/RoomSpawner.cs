using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    // 1 -> need bottom door
    // 2 -> need top door
    // 3 -> need left door
    // 4 -> need right door

    private string[] roomsCharIndexMapping = new string[] { "B", "T", "L", "R" };

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    public bool thisIsClosedRoom = false;
    public float waitTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("spawn", 0.1f);
    }

    // Update is called once per frame
    void spawn()
    {
        if (spawned == false)
        {
            if (templates.rooms.Count > templates.maxRoomsNumber)
            {
                instanceClosedRoom(openingDirection);
                Destroy(gameObject);
            }
            else
            {
                if (openingDirection == 1)
                {
                    // need to spawn a room with BOTTOM door
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                }
                else if (openingDirection == 2)
                {
                    // need to spawn a room with TOP door
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                }
                else if (openingDirection == 3)
                {
                    // need to spawn a room with LEFT door
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                }
                else if (openingDirection == 4)
                {
                    // need to spawn a room with RIGHT door
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                }
                spawned = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {

            if (other.GetComponent<RoomSpawner>() == null)
            {
                //for the entry room spawn point in the center
                Destroy(other);
                Destroy(gameObject);
            }
            else if ((other.GetComponent<RoomSpawner>().spawned == false && spawned == false) || other.GetComponent<RoomSpawner>().thisIsClosedRoom == true)
            {

                instanceClosedRoom(openingDirection);
                thisIsClosedRoom = true;
                Destroy(gameObject);
            }
            spawned = true;
        }
    }

    private void instanceClosedRoom(int direction)
    {
        if (direction == 1)
        {
            // need to spawn a room with BOTTOM door
            Instantiate(templates.closedRoomB, transform.position, Quaternion.identity);
        }
        else if (direction == 2)
        {
            // need to spawn a room with TOP door
            Instantiate(templates.closedRoomT, transform.position, Quaternion.identity);
        }
        else if (direction == 3)
        {
            // need to spawn a room with LEFT door
            Instantiate(templates.closedRoomL, transform.position, Quaternion.identity);
        }
        else if (direction == 4)
        {
            // need to spawn a room with RIGHT door
            Instantiate(templates.closedRoomR, transform.position, Quaternion.identity);
        }
    }


    
}

