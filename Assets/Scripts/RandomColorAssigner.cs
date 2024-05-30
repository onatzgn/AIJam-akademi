using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorAssigner : MonoBehaviour
    {
        public Color[] colors;

        void Start()
        {
            int randomIndex = Random.Range(0, colors.Length);
            GetComponent<SpriteRenderer>().color = colors[randomIndex];
        }
    }
