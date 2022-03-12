using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float moveSpeed;
    float xDirection;

    public AudioSource audio;
    public AudioClip winSound;

    GameController m_gc;
    
    void Start()
    {
        moveSpeed = 15;
        m_gc = FindObjectOfType<GameController>();
    }

    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");

        float moveStep = moveSpeed * xDirection * Time.deltaTime;

        if((transform.position.x < -5.3 && xDirection < 0) || (transform.position.x > 5.3 && xDirection > 0))
        {
            return;
        }

        transform.position += new Vector3(moveStep, 0, 0);   

        if(m_gc.IsGameOver())
        {
            audio.Pause();
        }
        else
        {
            audio.UnPause();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball") && audio)
        {
            audio.PlayOneShot(winSound);
        }
    }
}
