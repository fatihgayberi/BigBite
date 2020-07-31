using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Canvas finishMenu;
    SharkSwim sharkSwim;

    // Start is called before the first frame update
    void Start()
    {
        //sharkSwim = FindObjectOfType<SharkSwim>();
        finishMenu = finishMenu.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        EnableCanvas();
    }

    void EnableCanvas()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();
        
        if (sharkSwim.getFinishMenu() && finishMenu.isActiveAndEnabled)
        {
            finishMenu.enabled = true;
        }
    }
}
