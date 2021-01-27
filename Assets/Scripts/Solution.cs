using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class Solution : MonoBehaviour
{
    private LightLogic[] lamps;
    private SceneControlScript controller;

    void Start()
    {
        controller = gameObject.GetComponent<SceneControlScript>();
        lamps = controller.getLamps();
        controller.Resume();

    }
}
