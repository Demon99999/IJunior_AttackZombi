using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AimCursor : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
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
