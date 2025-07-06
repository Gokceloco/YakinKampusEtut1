using DG.Tweening;
using TMPro;
using UnityEngine;

public class FXManager1 : MonoBehaviour
{
    public TextMeshPro scoreTMP;
    public void PopScoreOnObject(int score, Vector3 pos)
    {
        var newText = Instantiate(scoreTMP);
        newText.transform.position = pos;
        newText.text = score.ToString();
        newText.transform.DOMoveY(4, .5f).OnComplete(()=>newText.gameObject.SetActive(false));
        if (score < 0)
        {
            newText.color = Color.red;
        }
    }
}
