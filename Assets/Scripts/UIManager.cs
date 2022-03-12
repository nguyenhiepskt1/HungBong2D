using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text textScore;
    public GameObject gameOverPanel;

    public void GetTextScore(string textscore)
    {
        textScore.text = textscore;
    }

    public void showGameOverPanel(bool panel)
    {
        gameOverPanel.SetActive(panel);
    }
}
