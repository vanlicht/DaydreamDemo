using UnityEngine;
using System.Collections;
using System;

public class tLaserPointer : GvrBasePointer
{
    public GameObject player;
    public float plyaerHeight;
    private Vector3 reticlePos;
    private Vector3 pointerIntersection;

    public override float GetMaxPointerDistance()
    {
        throw new NotImplementedException();
    }

    public override void GetPointerRadius(out float innerRadius, out float outerRadius)
    {
        throw new NotImplementedException();
    }

    public override void OnInputModuleDisabled()
    {
        throw new NotImplementedException();
    }

    public override void OnInputModuleEnabled()
    {
        throw new NotImplementedException();
    }

    public override void OnPointerClickDown()
    {
        throw new NotImplementedException();
    }

    public override void OnPointerClickUp()
    {
        throw new NotImplementedException();
    }

    public override void OnPointerEnter(GameObject targetObject, Vector3 intersectionPosition, Ray intersectionRay, bool isInteractive)
    {
        throw new NotImplementedException();
    }

    public override void OnPointerExit(GameObject targetObject)
    {
        throw new NotImplementedException();
    }

    public override void OnPointerHover(GameObject targetObject, Vector3 intersectionPosition, Ray intersectionRay, bool isInteractive)
    {
        throw new NotImplementedException();
    }

    public void playerTeleport()
    {
        reticlePos = pointerIntersection;
        player.transform.position = new Vector3(reticlePos.x, 1.6f, reticlePos.z);
    }
}
