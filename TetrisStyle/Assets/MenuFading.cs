using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFading : MonoBehaviour
{
    public CanvasGroup myCanva;
    public float menuSpeed;
    // Start is called before the first frame update
    void Start()
    {
        myCanva.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (myCanva.alpha < 1f)
        {
            myCanva.alpha += Time.deltaTime * menuSpeed;
        }
        
    }
}
