using UnityEngine.SceneManagement;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public Player Controls;
    public GameObject Loss;
    public GameObject Win;
    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    private AudioSource _audio;
    public State CurrentState { get; private set; }

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("Game Over!");
        Loss.SetActive(true);
        _audio.Stop();
    }

    public void OnPlayerWon()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        Controls.enabled = false;
        Debug.Log("You Won!");
        Win.SetActive(true);
        _audio.Stop();
    }

    public void OnPlayerRestart()
    {
        if (CurrentState != State.Loss) return;
        Loss.SetActive(false);
        ReloadLevel();
        _audio.Play();
    }
    public void OnPlayerNextLevel()
    {
        if (CurrentState != State.Won) return;
        Win.SetActive(false);
        _audio.Play();
        CurrentState = State.Playing;
        Controls.enabled = true;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
