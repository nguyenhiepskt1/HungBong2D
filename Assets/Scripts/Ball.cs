using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameController m_gc;

    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if(m_gc.IsGameOver())
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            m_gc.TangScore();         
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeathZone"))
        {
            m_gc.SetStateGameOver(true);
            Destroy(gameObject);
        }
    }

}
