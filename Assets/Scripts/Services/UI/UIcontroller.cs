using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private GameObject _screen;

    private void Awake()
    {
        SetActiveMenu(false); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Show();
        }
    }

    public void GoToContinue()
    {
        Hide();
    }

    public void GoToExit(){
        SceneManager.LoadScene("Menu");
    }

    public void GoToRestart(){
        SceneManager.LoadScene("Level");
    }

    private void Show()
    {
        MouseLookLock.AddLock();
        SetActiveMenu(true);
    }

    private void Hide()
    {
        MouseLookLock.RemoveLock();
        SetActiveMenu(false);
    }

    private void SetActiveMenu(bool active)
    {
        _screen.SetActive(active);
        Time.timeScale = active ? 0f : 1f;
    }
}
