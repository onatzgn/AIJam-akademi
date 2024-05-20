using Aeterponis;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatWindow : MonoBehaviour
{
    public TMP_InputField inputField;
    public AITest currentAI;

    private void Update()
    {
        if (this.isActiveAndEnabled)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                OSManager.instance.InstantiateUserText(inputField.text);
                currentAI.AutoConversation(inputField.text);
                inputField.text = string.Empty;
            }
        }
    }
}
