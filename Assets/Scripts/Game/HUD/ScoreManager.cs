using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Settings")]
    [SerializeField] private float timeLeft = 60f;
    [SerializeField] private int pointsPerSecond = 10;

    private int currentScore = 0;
    private bool isGameActive = true;
    private Coroutine timerRoutine;

    void OnEnable()
    {
        CheckState.OnLevelComplete += HandleLevelComplete;
    }

    void OnDisable()
    {
        CheckState.OnLevelComplete -= HandleLevelComplete;
    }

    void Start()
    {
        UpdateTimerUI();
        timerRoutine = StartCoroutine(TimerRoutine());
    }

    private IEnumerator TimerRoutine()
    {
        while (isGameActive && timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);

            if (!isGameActive) yield break;

            timeLeft--;
            UpdateTimerUI();

            if (timeLeft <= 0)
            {
                GameOver();
            }
        }
    }

    private void HandleLevelComplete()
    {
        isGameActive = false;

        if (timerRoutine != null)
        {
            StopCoroutine(timerRoutine);
        }

        CalculateBonusScore();
    }

    private void CalculateBonusScore()
    {
        int bonus = Mathf.FloorToInt(timeLeft) * pointsPerSecond;
        currentScore += bonus;

        scoreText.text = currentScore.ToString();

        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = Mathf.Max(0, timeLeft).ToString("0");
    }

    private void GameOver()
    {
        if (isGameActive)
        {
            isGameActive = false;
            gameOverPanel.SetActive(true);
        }
    }
}