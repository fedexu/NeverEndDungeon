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

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("spawn", 0.1f);
    }

    // Update is called once per frame
    void spawn()
    {
        if (spawned == false)
        {
            rand = Random.Range(0, templates.bottomRooms.Length);
            if (openingDirection == 1)
            {
                // need to spawn a room with BOTTOM door
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                // need to spawn a room with TOP door
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                // need to spawn a room with LEFT door
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                // need to spawn a room with RIGHT door
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("SpawnPoint")){
            Destroy(gameObject);
        }
    }
}
