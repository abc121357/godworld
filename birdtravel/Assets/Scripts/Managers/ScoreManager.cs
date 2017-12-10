using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    
    // Use this for initialization
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }
    void Start()
    {

    }
    private void OnGUI()
    {

    }
    // Update is called once per frame
    void Update()
    {
        text.text = "x" + movement.life;
    }
}
