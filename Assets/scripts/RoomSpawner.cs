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
    public RoomDescriber describer;
    public bool spawned = false;
    private float waitTime = 4f;
    private RoomTemplates templates;
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        describer = transform.parent.gameObject.GetComponent<RoomDescriber>();
        Invoke("spawn", 0.1f);
        describer.roomType = transform.root.name;
    }

    // Update is called once per frame
    void spawn()
    {
        if (spawned == false)
        {
            if (templates.rooms.Count > templates.maxRoomsNumber)
            {
                Destroy(gameObject);
            }
            else
            {
                if (openingDirection == 1)
                {
                    // need to spawn a room with BOTTOM door
                    assignRoom(templates.bottomRooms, ref describer.topRoom);
                    describer.topRoom.gameObject.GetComponent<RoomDescriber>().bottomRoom = transform.root.gameObject;
                }
                else if (openingDirection == 2)
                {
                    // need to spawn a room with TOP door
                    assignRoom(templates.topRooms, ref describer.bottomRoom);
                    describer.bottomRoom.gameObject.GetComponent<RoomDescriber>().topRoom = transform.root.gameObject;
                }
                else if (openingDirection == 3)
                {
                    // need to spawn a room with LEFT door
                    assignRoom(templates.leftRooms, ref describer.rightRoom);
                    describer.rightRoom.gameObject.GetComponent<RoomDescriber>().leftRoom = transform.root.gameObject;
                }
                else if (openingDirection == 4)
                {
                    // need to spawn a room with RIGHT door
                    assignRoom(templates.rightRooms, ref describer.leftRoom);
                    describer.leftRoom.gameObject.GetComponent<RoomDescriber>().rightRoom = transform.root.gameObject;
                }
                spawned = true;
            }
        }

    }

    private void assignRoom(GameObject[] rooms, ref GameObject describerRoom)
    {
        rand = Random.Range(0, rooms.Length);
        describerRoom = Instantiate(rooms[rand], transform.position, Quaternion.identity);
        describerRoom.name = rooms[rand].name;
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
            // if i (spawn point ) will be created on top on another, I've find an already created room (probably)
            spawned = true;
        }
    }

}

