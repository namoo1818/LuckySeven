using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : MonoBehaviour
{
    public BulletType bulletType = BulletType.Bullet;
    
    void Start()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GameObject bullet = ObjectPool.Instance.PopFromPool(BulletType.Bullet.ToString());
            bullet.transform.position = transform.position + transform.right;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            BulletMove bulletMove = bullet.GetComponent<BulletMove>();
            bulletMove.poolItemType = bulletType;
            bulletMove.moveSpeed = 10f;
            if (bulletType == BulletType.Laser)
            {
                bullet.transform.localScale = new Vector3(1, 1, 0);
                break;
            }
        }
    }
}
