using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private Board board;
    public string newLevel;
    public Image musicButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    private SoundManager sound;
    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
        board = FindObjectOfType<Board>();
        pausePanel.SetActive(false);
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                musicButton.sprite = musicOffSprite;
            }
            else
            {
                musicButton.sprite = musicOnSprite;
            }
        }
        else
        {
            musicButton.sprite = musicOnSprite;
        }
    }
    public void Sound()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                PlayerPrefs.SetInt("Sound", 1);
                musicButton.sprite = musicOnSprite;
                sound.adjustVolume();
            }
            else
            {
                PlayerPrefs.SetInt("Sound", 0);
                musicButton.sprite = musicOffSprite;
                sound.adjustVolume();
            }
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            musicButton.sprite = musicOffSprite;
            sound.adjustVolume();
        }
    }

    public void pauseGame()
    {
        GameState holder = board.currentState;
        if (board.currentState != GameState.pause)
        {
            holder = board.currentState;
            board.currentState = GameState.pause;
            pausePanel.SetActive(true);
        }
        else
        {
            board.currentState = GameState.move;
            pausePanel.SetActive(false);
            PlayerPrefs.Save();
        }
    }
    public void Exit() => SceneManager.LoadScene(newLevel);
}