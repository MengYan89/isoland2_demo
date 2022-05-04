using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public string sceneFrom;

    public string sceneToGO;

    public void TeleportToScene()
    {
        TransitionManager.Instance.Transition(sceneFrom, sceneToGO);
    }
}
