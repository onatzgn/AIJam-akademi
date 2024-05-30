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

        public void InitText(string message, bool isPlayer,bool b)
        {
            if (isPlayer)
                _textBox.text = userStart + message;
            else
            {
                _textBox.text = aiStart + message;
                currentText = message;
            }
        }


        IEnumerator PlayText()
        {
            foreach (char c in currentText)
            {
                _textBox.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

            ResizeToFitText();
        }


        private void ResizeToFitText()
        {
            _textBox.ForceMeshUpdate();
            Vector2 textSize = _textBox.GetPreferredValues();

            RectTransform rectTransform = _textBox.GetComponent<RectTransform>();
            rectTransform.sizeDelta += new Vector2(0, textSize.y);
        }

    }
}