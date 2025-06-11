using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DirectionPreview : MonoBehaviour
{
    public Player player;
    public GameObject arrowSR;
    public LineRenderer lineRenderer;
    public List<LineRenderer> lineRendererReflections;
    public float maxArrowScale;

    public int maxBounceCount;
    

    private void Start()
    {
        arrowSR.SetActive(false);
        lineRenderer.enabled = false;
        foreach (var lr in lineRendererReflections)
        {
            lr.enabled = false;
        }
    }

    public void Show()
    {
        arrowSR.SetActive(true);
        transform.DOKill();
        transform.localScale = Vector3.zero;    
    }
    public void Hide()
    {
        arrowSR.SetActive(false);
        lineRenderer.enabled = false;
        foreach (var lr in lineRendererReflections)
        {
            lr.enabled = false;
        }
    }

    public void SetDirection(Vector3 dir)
    {
        dir.y = 0;
        transform.LookAt(transform.position - dir);

        if (dir.magnitude > 1f)
        {
            lineRenderer.enabled = true;
            arrowSR.SetActive(true);
            var scaleMultiplier = (dir.magnitude * .4f);
            scaleMultiplier = Mathf.Min(scaleMultiplier, maxArrowScale);
            transform.localScale = Vector3.one * scaleMultiplier;
        }

        var endPoint = transform.position - Vector3.up * .35f - dir * 50;
        
        var rayStartPoint = transform.position - Vector3.up * .35f;
        var rayDir = -dir;
        var hitDistance = 50f;

        var bounceCount = 0;
        
        while (true)
        {
            if (Physics.Raycast(rayStartPoint, rayDir, out var hit, 100, player.groundLayerMask)
                && bounceCount < maxBounceCount)
            {
                if (bounceCount == 0)
                {
                    endPoint = hit.point;
                }
                
                rayStartPoint = hit.point;
                rayDir = Vector3.Reflect(rayDir, hit.normal);

                lineRendererReflections[bounceCount].enabled = true;
                lineRendererReflections[bounceCount].SetPosition(0, rayStartPoint);
                lineRendererReflections[bounceCount].SetPosition(1, rayStartPoint + rayDir * 50);
                if (bounceCount > 0)
                {
                    lineRendererReflections[bounceCount - 1].SetPosition(1, hit.point);
                }
                
                bounceCount++;
            }
            else
            {
                for (int i = 0; i < lineRendererReflections.Count; i++)
                {
                    if (i >= bounceCount)
                    {
                        lineRendererReflections[i].enabled = false;
                    }
                }
                break;
            }
        }

        lineRenderer.SetPosition(0, transform.position - Vector3.up * .35f);
        lineRenderer.SetPosition(1, endPoint);
    }
}
