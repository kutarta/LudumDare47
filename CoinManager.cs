using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public TextMeshProUGUI CoinText;
    int Score;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void CoinCounter(int CoinValue)
    {
        Score += CoinValue;
        CoinText.text = Score.ToString();
    }



}
