using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

    public Image title;
    public Image levelSelect;

    public Image level1;
    public Image level2;

    private int selected;
    private int mode;

    private int maxSelection;

    private void Awake()
    {
        selected = 0;
        mode = 0;
        maxSelection = 0;

        levelSelect.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 1);

        title.GetComponent<CanvasRenderer>().SetAlpha(0);
        levelSelect.GetComponent<CanvasRenderer>().SetAlpha(0);
        level1.GetComponent<CanvasRenderer>().SetAlpha(0);
        level2.GetComponent<CanvasRenderer>().SetAlpha(0);

        title.CrossFadeAlpha(1, 1, false);
        levelSelect.CrossFadeAlpha(1, 1, false);
    }

    private void FixedUpdate ()
    {
        RectTransform levelSelectrt = levelSelect.GetComponent<RectTransform>();
        RectTransform level1rt = level1.GetComponent<RectTransform>();
        RectTransform level2rt = level2.GetComponent<RectTransform>();
        if (mode == 0)
        {
            if (selected == 0)
            {
                if (levelSelectrt.localScale.x < 0.95)
                    levelSelectrt.localScale += new Vector3(0.1f, 0.1f, 0);
                else if (levelSelectrt.localScale.x > 1.05)
                    levelSelectrt.localScale -= new Vector3(0.1f, 0.1f, 0);
            }
            else
            {
                if (levelSelectrt.localScale.x > 0.5)
                    levelSelectrt.localScale -= new Vector3(0.1f, 0.1f, 0);
            }
        }
        if (mode == 1)
        {
            if (selected == 0)
            {
                if (level1rt.localScale.x < 0.95)
                    level1rt.localScale += new Vector3(0.1f, 0.1f, 0);
                else if (level1rt.localScale.x > 1.05)
                    level1rt.localScale -= new Vector3(0.1f, 0.1f, 0);
            }
            else
            {
                if (level1rt.localScale.x > 0.5)
                    level1rt.localScale -= new Vector3(0.1f, 0.1f, 0);
            }
            if (selected == 1)
            {
                if (level2rt.localScale.x < 0.95)
                    level2rt.localScale += new Vector3(0.1f, 0.1f, 0);
                else if (level2rt.localScale.x > 1.05)
                    level2rt.localScale -= new Vector3(0.1f, 0.1f, 0);
            }
            else
            {
                if (level2rt.localScale.x > 0.5)
                    level2rt.localScale -= new Vector3(0.1f, 0.1f, 0);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (mode == 0)
            {
                switch (selected)
                {
                    case 0:
                        level1.CrossFadeAlpha(1, 0.5f, false);
                        level2.CrossFadeAlpha(1, 0.5f, false);

                        title.CrossFadeAlpha(0, 0.5f, false);
                        levelSelect.CrossFadeAlpha(0, 0.5f, false);
                        selected = 0;
                        mode = 1;
                        maxSelection = 1;
                        break;
                }
            }
            else if (mode == 1)
            {
                switch (selected)
                {
                    case 0:
                        SceneManager.LoadScene(1);
                        break;
                    case 1:
                        SceneManager.LoadScene(2);
                        break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selected--;
            if (selected < 0)
                selected = maxSelection;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selected++;
            if (selected > maxSelection)
                selected = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selected--;
            if (selected < 0)
                selected = maxSelection;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selected++;
            if (selected > maxSelection)
                selected = 0;
        }
    }
}
