
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public GameObject winMessage;

    private int score = 0;
    private int totalCollectibles;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        winMessage.SetActive(false);
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();

        if (score >= totalCollectibles)
        {
            winMessage.SetActive(true);
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}

