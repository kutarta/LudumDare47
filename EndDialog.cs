using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndDialog : MonoBehaviour
{
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public TextMeshProUGUI textDisplay;
    public GameObject continueButton;

    private PlayerMovement PM;
    public bool isCollided = false;

    private void Awake()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isCollided == false)
        {
            PM.rb.velocity = new Vector2(0f, 0f);
            StartCoroutine(Type());
            GetComponent<BoxCollider2D>().enabled = false;
            PM.enabled = false;
            isCollided = true;
        }
    }

    private void Update()
    {
        if (textDisplay.text == "")
        {
            PM.enabled = true;
        }

        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            isCollided = false;
        }
    }
    
}
