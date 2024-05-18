using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Aeterponis
{
    public class SpawnableText : MonoBehaviour
    {
        public TextMeshProUGUI _textBox;
        string currentText;
        const string aiStart = "C:/RIDDLER>";
        const string userStart = "C:/USER>";
        [SerializeField] private float textSpeed = .125f;

        public void InitText(string message, bool isPlayer)
        {
            if (isPlayer)
                _textBox.text = userStart + message;
            else
            {
                _textBox.text = aiStart;
                currentText = message;
                StartCoroutine(PlayText());
            }
        }

        //private void Awake()
        //{
        //    currentText = "LOREM IPSUM LOREM IPSUM LOREM IPSUM LOREM IPSUM ";
        //    _textBox.text = aiStart;
        //    StartCoroutine(PlayText());
        //}

        IEnumerator PlayText()
        {
            foreach (char c in currentText)
            {
                _textBox.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

    }
}