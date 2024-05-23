using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimits : MonoBehaviour
{
    [SerializeField] Limits limits;
    private enum Limits{
        limit30 = 30,
        limit60 = 60,
        limit120 = 120,
        limit240 = 240,
        limit1000 = 1000,
    }
    private void Awake() {
        Application.targetFrameRate = (int)limits;
    }
}
