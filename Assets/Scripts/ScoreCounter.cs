using System;
using TMPro;
using UnityEngine;
[Serializable]
public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI _scoreTextMeshPro;

    public int GetScore()
    {
        return Int32.Parse(_scoreTextMeshPro.text);
    }
    
    public void SetScore(int score)
    {
        int nums = GetScore();
        nums += score;
        _scoreTextMeshPro.text = nums.ToString();
    }
}
