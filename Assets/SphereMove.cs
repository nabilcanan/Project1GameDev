using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SphereMove : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    public TMP_Text scoreText;
    public GameObject pauseObject;
    private bool countdown;
    private float timer;
    
    void Start()
    {
        score = 0;
        countdown= false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10 * Time.deltaTime;
        //if (Input.GetKey(KeyCode.UpArrow))
        //transform.position += new Vector3(0, 0, speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0) 
            { 
                Time.timeScale = 1; 
                pauseObject.SetActive(false);
            } else 
            { 
                Time.timeScale = 0;
                pauseObject.SetActive(true);
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                countdown= true;
            }

            if (countdown)
            {
                if(timer < 3)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    UnityEditor.EditorApplication.isPlaying= false;
                }
            }
        }

        float horizMove = Input.GetAxisRaw("Horizontal") * speed; 
        float vertMove = Input.GetAxisRaw("Vertical") * speed; 
        transform.position += new Vector3(horizMove, 0, vertMove);
    }
    private void OnTriggerEnter(Collider other)
    {
        score++;
        scoreText.text = "Score" + score;
        //Debug.Log("Score is now: " + score);
    }
    private void OnTriggerExit(Collider other)
    {
        float newX = Random.Range(-12, 12);
        float newZ = Random.Range(-5, 5);
        other.transform.position = new Vector3(newX, 0, newZ);
    }

    
    
}
