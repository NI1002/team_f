using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scorer : MonoBehaviour
{

    private static int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Text uiText = GetComponent<Text>();
        uiText.text = "Score:" + score;

    }

    public void AddScore(int n)
    {
        score += n;
    }
}
