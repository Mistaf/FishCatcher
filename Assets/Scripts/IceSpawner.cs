using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpawner : MonoBehaviour
{
    public GameObject Ice;
    public float leftScreenX, rightScreenX;
    private float randX;
    private Vector2 whereToSpawn;
    public float spawnRate = 100f;
    private float nextSpawn = 0f;


    // Update is called once per frame
    void Update()
    {
        int score = GameObject.FindGameObjectWithTag("Penguin").GetComponent<Player>().score > 0
            ? GameObject.FindGameObjectWithTag("Penguin").GetComponent<Player>().score
            : 1;
        if (Time.time > nextSpawn&&score>=10)
        {
            nextSpawn = Time.time + spawnRate / score;
            randX = Random.Range(leftScreenX, rightScreenX);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(Ice, whereToSpawn, Quaternion.identity);
        }

    }
}
