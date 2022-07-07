using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private static HUD _instance;
    public static HUD Instance => _instance;
    [SerializeField]
    private TextMeshProUGUI _coinValue;
    [SerializeField]
    private int _coinCount;


    private void Awake()
    {
        if (_instance)
            Destroy(gameObject);
        else
            _instance = this;
    }

    public void RemoveCoin(int value)
    {
        _coinCount -= value;
        _coinValue.text = _coinCount.ToString();
    }

}
