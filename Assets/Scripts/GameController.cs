using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public float spawnTime;

    float m_spawnTime;
    int m_socre;
    bool m_isGameOver;

    UIManager m_ui;

    
    void Start()
    {
        spawnTime = 2;
        m_spawnTime = 0;
        m_socre = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.GetTextScore("Score: " + m_socre);
    }
  
    void Update()
    {
        m_spawnTime -= Time.deltaTime;

        if(m_isGameOver)
        {
            spawnTime = 0;
            m_ui.showGameOverPanel(true);
            Time.timeScale = 0;
            return;
        }

        if(m_spawnTime <= 0)
        {
            spawnBall();
            m_spawnTime = spawnTime;
        }

        if(m_socre > 10)
        {
            spawnTime = 1;
        }
        if (m_socre > 50)
        {
            spawnTime = 0.5f;
        }
    }

    public void spawnBall()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-7.9f, 7.9f), 6);

        if(ball)
        {
            Instantiate(ball, spawnPos, Quaternion.identity);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayAgainButton()
    {
        spawnTime = 2;
        m_socre = 0;
        m_ui.GetTextScore("Score: " + m_socre);
        m_ui.showGameOverPanel(false);
        m_isGameOver = false;
        Time.timeScale = 1;
    }

    public void SetScore(int value)
    {
        m_socre = value;
    }

    public int GetScore()
    {
        return m_socre;
    }

    public void TangScore()
    {
        m_socre++;
        m_ui.GetTextScore("Score: " + m_socre);
    }

    public bool IsGameOver()
    {
        return m_isGameOver;
    }

    public void SetStateGameOver(bool state)
    {
        m_isGameOver = state;
    }
}
