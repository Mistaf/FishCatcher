using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    float horizontalMovement = 0f;
    [SerializeField] float runSpeed = 10;
    public int score = 0;
    public int highscore = 0;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
    }
    private void FixedUpdate()
    {
        Move(horizontalMovement * Time.fixedDeltaTime);
    }

    public void Move(float move)
    {

   
        Vector2 targetPos = transform.position;
        targetPos.x += move;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, runSpeed);
      
    

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

// Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

    }

    void OnCollisionEnter2D(Collision2D col)
    { 
        if (col.gameObject.name == "LeftWall")Move(0.8f);
        if (col.gameObject.name == "RightWall")Move(-0.8f);
        if (col.transform.tag == "Meany" && col.gameObject.GetComponent<Fish>().wayDown) dead();
        if (col.transform.tag == "Ice") dead();
        if (col.transform.tag == "Nice" && col.gameObject.GetComponent<Fish>().wayDown) hit(col.gameObject);
    }

    void dead()
    {
        if(score>highscore)PlayerPrefs.SetInt("Highscore",score);
        SceneManager.LoadScene("SampleScene");

    }

    void hit(GameObject obj)
    {
        score++;
        Destroy(obj);
    }
}
