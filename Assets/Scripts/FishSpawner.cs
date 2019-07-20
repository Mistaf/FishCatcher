using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{


    public GameObject fish;
    public float leftScreenX, rightScreenX;
    private float randX;
    private Vector2 whereToSpawn;
    public float spawnRate = 2f;
    private float nextSpawn = 0f;


    // Update is called once per frame
    void Update()
    {
        int score = GameObject.FindGameObjectWithTag("Penguin").GetComponent<Player>().score > 0
            ? GameObject.FindGameObjectWithTag("Penguin").GetComponent<Player>().score
            : 1;
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate/ score;
            randX = Random.Range(leftScreenX, rightScreenX);
            whereToSpawn=new Vector2(randX, transform.position.y);
            Instantiate(fish, whereToSpawn, Quaternion.identity);
        }

    }
}
