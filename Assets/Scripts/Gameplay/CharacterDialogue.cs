using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class CharacterDialogue : MonoBehaviour
{

    [SerializeField] private RectTransform _root;
    [SerializeField] private TextMeshProUGUI _dialogueLable;
    [SerializeField] private float _dialogueStepTime;

    [SerializeField] private string _dialogue;
    [SerializeField] private int _maxLineCharacterCount;



    private IEnumerator DialogueAnimation()
    {
        int length = _dialogue.Length;
        for (int i = 0; i < length; i++)
        {
            yield return new WaitForSeconds(_dialogueStepTime);
            _dialogueLable.text = _dialogue.Substring(0, i + 1);
        }

        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);

    }

    public void SetData(string dialogue)
    {

        gameObject.SetActive(true);

        _dialogue = dialogue;


        if (_dialogue.Length > _maxLineCharacterCount)
        {
            int halfSize = _dialogue.Length / 2;
            string firstHalf = _dialogue.Substring(0, halfSize);
            string substring = _dialogue.Substring(halfSize, _dialogue.Length - halfSize);
            StringBuilder secondHalf = new StringBuilder(substring);
            secondHalf[secondHalf.ToString().IndexOf(' ')] = '\n';
            _dialogue = firstHalf + secondHalf;
        }

        _dialogueLable.text = string.Empty;
        SetPivot();
        StopAllCoroutines();
        StartCoroutine(DialogueAnimation());

    }


    private void SetPivot()
    {
        float normalizePos = (_root.anchoredPosition.x / Screen.width);
        float value = (normalizePos + 0.5f);
        RectTransform pivot = (_root.GetChild(0) as RectTransform);
        pivot.anchorMax = new Vector2(value, pivot.anchorMax.y);
        pivot.anchorMin = new Vector2(value, pivot.anchorMin.y);
        pivot.pivot = new Vector2(value, pivot.pivot.y);
        pivot.anchoredPosition = new Vector2(normalizePos * 90, 25);

    }

}
