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
        const string aiStart = "JESSICA>";
        const string userStart = "USER>";
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