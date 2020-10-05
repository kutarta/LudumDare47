using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int CoinValue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CoinManager.Instance.CoinCounter(CoinValue);
            Destroy(gameObject);
        }
    }
}
