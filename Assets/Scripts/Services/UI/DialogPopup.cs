using System;
using TMPro;
using UnityEngine;

public class DialogPopup: MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Action _yes;
    private Action _no;

    private void Awake()
    {
        Hide();
    }

    public void Show(string message, Action yes, Action no)
    {
        gameObject.SetActive(true);
        _text.text = message;
        _yes = yes;
        _no = no;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Yes()
    {
        Hide();
        _yes?.Invoke();
    }

    public void No()
    {
        Hide();
        _no?.Invoke();
    }
}
