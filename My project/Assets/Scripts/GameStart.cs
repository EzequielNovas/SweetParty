using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject levelPanel;

    // Use this for initialization
    void Start()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }

    public void PlayGame()
    {
        startPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void Home()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
}