using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;//
    [SerializeField] private Transform _shootPoint;//
    [SerializeField] private AimCursor _cursor;//
    [SerializeField] private int _damage;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var from = _shootPoint.position;
            var target = _cursor.transform.position;
            var to = new Vector3(target.x, from.y, target.z);
            var direction = (to - from).normalized;
            RaycastHit hit;

            if (Physics.Raycast(from, to - from, out hit, 100))
            {
                to = new Vector3(hit.point.x, from.y, hit.point.z);

                if (hit.transform != null)
                {
                    var zombi = hit.transform.GetComponent<Enemy>();//

                    if (zombi != null)
                    {
                        zombi.TakeDamage(_damage);
                    }
                }
            }
            else
            {
                to = from + direction * 100;
            }

            _bullet.ShowBullet(from, to);
        }
    }
}
