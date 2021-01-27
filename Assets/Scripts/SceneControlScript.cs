using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class SceneControlScript : MonoBehaviour
{
    public GameObject[] lamp;
    public int current = 0;
    private float timer = 0f;
    private bool forward = true;
    public bool onPause = true;
    private int lightCount = 0;
    private string path = "output.txt";
    private LightLogic[] LL = null;
    private bool done = false;

    private void Start()
    {
        Pause();
        LL = lamp.Select(value => value.GetComponent<LightLogic>()).ToArray();
    }

    private void FixedUpdate()
    {
        if (done)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
            return;
        }
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 1f;
            if (LL[current].Enabled)
            {
                ++lightCount;
                LL[current].extinguish();

                if (forward && current != lamp.Length - 1)
                {
                    current++;
                }
                else if (forward && current == lamp.Length - 1)
                {
                    current--;
                    forward = false;
                }
                else if (!forward && current == 0)
                {
                    current++;
                    forward = true;
                }
                else
                {
                    current--;
                }
            }
            LL[current].ignite();
        }

        if (LL[current].maxIntensity == 0)
        {
            done = true;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public int getCurentTime()
    {
        return lightCount;
    }
    public int getIntensityOf(int index)
    {
        return LL[index].maxIntensity;
    }
    public LightLogic[] getLamps()
    {
        return LL;
    }
    public void setAnswer(int answer)
    {
        File.WriteAllText(path, answer.ToString());
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
