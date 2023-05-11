using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Bullet : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private bool visible;
    
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if (visible)
            visible = false;
        else
            gameObject.SetActive(false);

    }

    public void ShowBullet(Vector3 from,Vector3 to)
    {
        _lineRenderer.SetPositions(new Vector3[] {from,to});
        visible = true;
        gameObject.SetActive(true);
    }
}
