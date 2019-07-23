using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Vector2 direction;
    public float speedMin = 0.10f;
    public float speedMax = 0.15f;
    public bool wayDown = false;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        direction = transform.position;
        direction.y = 5f;
        speed = Random.Range(speedMin, speedMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, direction) > 0.2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, direction, speed);
        }
        else
        {
            direction.y = direction.y * -1;
            speed = Random.Range(speedMin, speedMax);
        }

        if (wayDown && direction.y > transform.position.y)Destroy(this.gameObject);
        GetComponent<SpriteRenderer>().flipY = !(direction.y > transform.position.y);
        wayDown = !(direction.y > transform.position.y);
    }
}
