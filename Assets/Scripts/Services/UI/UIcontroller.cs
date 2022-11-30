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

    [SerializeField] private GameObject _gameplayScreen;
    [SerializeField] private GameObject _screen;
    [SerializeField] private Image _screamerScreen;

    [SerializeField] private Image _endBackground;
    [SerializeField] private Image _cursorImage;

    [SerializeField] private GameObject _pauseBlock;
    [SerializeField] private GameObject _loseBlock;
    [SerializeField] private DialogPopup _dialogPopup;

    [SerializeField] private TMP_Text _loseYouDied;
    [SerializeField] private TMP_Text _loseMessage;
    [SerializeField] private CanvasGroup _loseButtons;

    private void Awake()
    {
        _instance = this;

        SetActiveScreen(false, true);
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

    public void SetCursorHovered(bool hovered)
    {
        _cursorImage.color = hovered ? Color.red : Color.white;
    }

    public void ShowScreamer(Sprite sprite, float duration = 1.5f)
    {
        _screamerScreen.sprite = sprite;
        _screamerScreen.gameObject.SetActive(true);

        StartCoroutine(ScreamerAnimationCoroutine(duration));
    }

    private IEnumerator ScreamerAnimationCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);

        yield return StartCoroutine(FadeHide(_screamerScreen.color, 1f, color => _screamerScreen.color = color));

        _screamerScreen.gameObject.SetActive(false);
    }

    public void ShowDialog(string message, Action yes, Action no)
    {
        Show(true);

        _dialogPopup.Show(message, () => 
            { 
                Hide(true); 
                yes?.Invoke();
            }, () => 
            { 
                Hide(true); 
                no?.Invoke();
            });
    }

    public void ShowPause()
    {
        Show(true);
        _pauseBlock.SetActive(true);
    }

    public void HidePause()
    {
        Hide(true);
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

        StopAllSounds();
        SoundConfig.Instance.PlayerWin.PlayOneShot();

        yield return new WaitForSeconds(1.5f);

        _endBackground.enabled = true;
        yield return StartCoroutine(FadeShow(_endBackground.color, 1f, color => _endBackground.color = color));

        SceneManager.LoadScene("Win");
    }

    public void ShowLose(string message, float delayBeforeDeath)
    {
        Show();
        _loseBlock.SetActive(true);
        _endBackground.gameObject.SetActive(true);

        _loseMessage.text = message;

        StartCoroutine(LoseAnimationCoroutine(delayBeforeDeath));
    }

    private IEnumerator LoseAnimationCoroutine(float delayBeforeDeath)
    {
        _endBackground.enabled = false;
        _loseYouDied.enabled = false;
        _loseMessage.enabled = false;
        _loseButtons.alpha = 0f;
        _loseButtons.interactable = false;

        yield return new WaitForSeconds(delayBeforeDeath);

        StopAllSounds();
        SoundConfig.Instance.PlayerDeath.PlayOneShot();

        _endBackground.enabled = true;
        yield return StartCoroutine(FadeShow(_endBackground.color, 1f, color => _endBackground.color = color));

        _loseYouDied.enabled = true;
        yield return StartCoroutine(FadeShow(_loseYouDied.color, 1f, color => _loseYouDied.color = color));

        _loseMessage.enabled = true;
        yield return StartCoroutine(FadeShow(_loseMessage.color, 1f, color => _loseMessage.color = color));

        yield return StartCoroutine(FadeShow(Color.white, 1f, color => _loseButtons.alpha = color.a));
        _loseButtons.interactable = true;
    }

    private IEnumerator FadeShow(Color startColor, float fadeSpeed, Action<Color> setColorAction)
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

    private IEnumerator FadeHide(Color startColor, float fadeSpeed, Action<Color> setColorAction)
    {
        var color = startColor;
        color.a = 1f;
        setColorAction?.Invoke(color);

        while (color.a > 0f)
        {
            color.a -= Time.deltaTime * fadeSpeed;
            setColorAction?.Invoke(color);
            yield return null;
        }
    }

    private void Show(bool setTimeScale = false)
    {
        MouseLookLock.AddLock();
        SetActiveScreen(true, setTimeScale);
        _loseBlock.SetActive(false);
        _pauseBlock.SetActive(false);
        _endBackground.gameObject.SetActive(false);
    }

    private void Hide(bool setTimeScale = false)
    {
        MouseLookLock.RemoveLock();
        SetActiveScreen(false, setTimeScale);
    }

    private void SetActiveScreen(bool active, bool setTimeScale)
    {
        _screen.SetActive(active);
        _gameplayScreen.SetActive(!active);

        if (setTimeScale)
        {
            Time.timeScale = active ? 0f : 1f;
        }
    }

    private bool IsScreenActive()
    {
        return _screen.active;
    }

    private void StopAllSounds()
    {
        var sources = FindObjectsOfType<AudioSource>();
        foreach (var s in sources)
        {
            s.Stop();
        }
    }
}
