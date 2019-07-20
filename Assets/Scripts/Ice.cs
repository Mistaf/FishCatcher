using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    private Vector2 direction;
    public float speedMin = 0.2f;
    public float speedMax = 0.25f;
    private float speed;
    public AudioSource splash;

    // Start is called before the first frame update
    void Start()
        {
            direction = transform.position;
            direction.y = -5f;
            speed = Random.Range(speedMin, speedMax);
            splash = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, direction) > 0.2f)transform.position = Vector2.MoveTowards(transform.position, direction, speed);
        if(transform.position.y> GameObject.FindGameObjectWithTag("Penguin").transform.position.y)
        {
            splash.Play();
            Destroy(this.gameObject,splash.clip.length*5);
        }
    }

}
