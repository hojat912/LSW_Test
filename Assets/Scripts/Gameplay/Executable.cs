using System;
using UnityEngine;

public class Executable : MonoBehaviour, IExecutable
{
    [SerializeField]
    private KeyCode _openCloseKey = KeyCode.F;

    [SerializeField]
    private GameObject _item;

    private bool _canChange;
    private Action _execute;

    public bool CanExecute => _canChange;

    private void Awake()
    {
        _item.SetActive(false);
    }

    private void Update()
    {
        if (_canChange && Input.GetKeyDown(_openCloseKey))
        {
            Execute();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _item.SetActive(true);
            _canChange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _item.SetActive(false);
            _canChange = false;
        }
    }

    public void Execute()
    {
        _execute?.Invoke();
    }

    public void SetAction(Action execute)
    {
        _execute = execute;

    }
}
