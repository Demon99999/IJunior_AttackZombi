using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AimCursor : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int layerMask;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        layerMask = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            _spriteRenderer.enabled = false;
        }
        else
        {
            transform.position=new Vector3(hit.point.x,transform.position.y,hit.point.z);
            _spriteRenderer.enabled = true;
        }
    }
}
