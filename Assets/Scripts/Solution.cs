using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Solution : MonoBehaviour
{
    private SceneControlScript controller;

    void Start()
    {
        controller = gameObject.GetComponent<SceneControlScript>();
        controller.Resume();

    }
}
