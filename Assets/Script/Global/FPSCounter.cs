using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    private TextMeshProUGUI textMesh; 
    // Start is called before the first frame update
    void Start()
    {
    textMesh = GetComponent<TextMeshProUGUI>();
    InvokeRepeating(nameof(CalcularFPS), 0, 1f);
        
    }
    private void CalcularFPS(){
       textMesh.text = (1f / Time.deltaTime).ToString("00")+" FPS";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
