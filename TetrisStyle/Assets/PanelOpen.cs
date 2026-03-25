using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    public GameObject panel;
    public bool panelisActive;
    // Start is called before the first frame update
    void Start()
    {
        panelisActive = false;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !panelisActive)
        {
            panel.SetActive(true);
            panelisActive = true;
        }

        else if(Input.GetKeyDown(KeyCode.Space) && panelisActive)
        {
            panel.SetActive(false);
            panelisActive = false;
        }
    }
}
