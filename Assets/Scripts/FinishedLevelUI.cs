using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishedLevelUI : MonoBehaviour {

    public Image nextLevelImage;
    public Image exitToDesktopImage;
    public Image exitToMenuImage;

    public string nextLevel;

    private int selected;
    
	private void Awake ()
    {
        selected = 0;
        RectTransform nextLevelRect = nextLevelImage.GetComponent<RectTransform>();
        RectTransform exitGameRect = exitToDesktopImage.GetComponent<RectTransform>();
        RectTransform exitToMenuRect = exitToMenuImage.GetComponent<RectTransform>();
        nextLevelRect.localScale = new Vector3(2, 2, 1);
        exitGameRect.localScale = new Vector3(2, 2, 1);
        exitToMenuRect.localScale = new Vector3(2, 2, 1);
    }

    // 0 = next level
    // 1 = exit;

    private void FixedUpdate()
    {
        RectTransform nextLevelRect = nextLevelImage.GetComponent<RectTransform>();
        RectTransform exitGameRect = exitToDesktopImage.GetComponent<RectTransform>();
        RectTransform exitToMenuRect = exitToMenuImage.GetComponent<RectTransform>();
        if (selected == 0)
        {
            if (nextLevelRect.localScale.x < 0.95)
                nextLevelRect.localScale += new Vector3(0.1f, 0.1f, 0);
            else if (nextLevelRect.localScale.x > 1.05)
                nextLevelRect.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
        else
        {
            if (nextLevelRect.localScale.x > 0.5)
                nextLevelRect.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
        if (selected == 1)
        {
            if (exitToMenuRect.localScale.x < 0.95)
                exitToMenuRect.localScale += new Vector3(0.1f, 0.1f, 0);
            else if (exitToMenuRect.localScale.x > 1.05)
                exitToMenuRect.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
        else
        {
            if (exitToMenuRect.localScale.x > 0.5)
                exitToMenuRect.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
        if (selected == 2)
        {
            if (exitGameRect.localScale.x < 0.95)
                exitGameRect.localScale += new Vector3(0.1f, 0.1f, 0);
            else if (exitGameRect.localScale.x > 1.05)
                exitGameRect.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
        else
        {
            if (exitGameRect.localScale.x > 0.5)
                exitGameRect.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            switch(selected)
            {
                case 0:
                    SceneManager.LoadScene(nextLevel);
                    break;
                case 1:
                    SceneManager.LoadScene(0);
                    break;
                case 2:
                    Application.Quit();
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selected--;
            if (selected < 0)
                selected = 2;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selected++;
            if (selected > 2)
                selected = 0;
        }
    }
}
