using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController Instance => _instance;
    private static UiController _instance;

    [SerializeField] private GameObject _screen;
    [SerializeField] private Image _endBackground;

    [SerializeField] private GameObject _pauseBlock;
    [SerializeField] private GameObject _loseBlock;

    [SerializeField] private TMP_Text _loseYouDied;
    [SerializeField] private TMP_Text _loseMessage;
    [SerializeField] private CanvasGroup _loseButtons;

    private void Awake()
    {
        _instance = this;

        SetActiveScreen(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsScreenActive())
        {
            ShowPause();
        }
    }

    public void GoToContinue()
    {
        HidePause();
    }

    public void GoToExit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToRestart()
    {
        SceneManager.LoadScene("Level");
    }

    public void ShowPause()
    {
        Show();
        _pauseBlock.SetActive(true);
        SetTimeScale(false);
    }

    public void HidePause()
    {
        Hide();
        SetTimeScale(true);
    }

    public void ShowWin()
    {
        Show();
        _endBackground.gameObject.SetActive(true);

        StartCoroutine(WinAnimationCoroutine());
    }

    private IEnumerator WinAnimationCoroutine()
    {
        _endBackground.enabled = false;

        SoundConfig.Instance.PlayerWin.PlayOneShot();

        yield return new WaitForSeconds(1.5f);

        _endBackground.enabled = true;
        yield return StartCoroutine(FadeUi(_endBackground.color, 1f, color => _endBackground.color = color));

        SceneManager.LoadScene("Win");
    }

    public void ShowLose(string message)
    {
        Show();
        _loseBlock.SetActive(true);
        _endBackground.gameObject.SetActive(true);

        _loseMessage.text = message;

        StartCoroutine(LoseAnimationCoroutine());
    }

    private IEnumerator LoseAnimationCoroutine()
    {
        _endBackground.enabled = false;
        _loseYouDied.enabled = false;
        _loseMessage.enabled = false;
        _loseButtons.alpha = 0f;
        _loseButtons.interactable = false;

        yield return new WaitForSeconds(1.5f);

        SoundConfig.Instance.PlayerDeath.PlayOneShot();

        _endBackground.enabled = true;
        yield return StartCoroutine(FadeUi(_endBackground.color, 1f, color => _endBackground.color = color));

        _loseYouDied.enabled = true;
        yield return StartCoroutine(FadeUi(_loseYouDied.color, 1f, color => _loseYouDied.color = color));

        _loseMessage.enabled = true;
        yield return StartCoroutine(FadeUi(_loseMessage.color, 1f, color => _loseMessage.color = color));

        yield return StartCoroutine(FadeUi(Color.white, 1f, color => _loseButtons.alpha = color.a));
        _loseButtons.interactable = true;
    }

    private IEnumerator FadeUi(Color startColor, float fadeSpeed, Action<Color> setColorAction)
    {
        var color = startColor;
        color.a = 0f;
        setColorAction?.Invoke(color);

        while (color.a < 1f)
        {
            color.a += Time.deltaTime * fadeSpeed;
            setColorAction?.Invoke(color);
            yield return null;
        }
    }

    private void Show()
    {
        MouseLookLock.AddLock();
        SetActiveScreen(true);
        _loseBlock.SetActive(false);
        _pauseBlock.SetActive(false);
        _endBackground.gameObject.SetActive(false);
    }

    private void Hide()
    {
        MouseLookLock.RemoveLock();
        SetActiveScreen(false);
    }

    private void SetActiveScreen(bool active)
    {
        _screen.SetActive(active);
    }

    private bool IsScreenActive()
    {
        return _screen.active;
    }

    private void SetTimeScale(bool active)
    {
        Time.timeScale = active ? 1f : 0f;
    }
}
