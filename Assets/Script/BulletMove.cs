using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public BulletType poolItemType = BulletType.Bullet;
    public float moveSpeed = 10f;
    public float lifeTime = 3f;
    public float _elapsedTime = 0f;

    void Start()
    {
        if (poolItemType == BulletType.Laser)
        {
            StartCoroutine("Laser");
        }
    }

    void Update()
    {
        switch (poolItemType)
        {
            case BulletType.Bullet:
                transform.position += transform.right * moveSpeed * Time.deltaTime;
                break;
            case BulletType.Missile:
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
                transform.position += Vector3.right * 5f * Time.deltaTime;
                moveSpeed -= 0.1f;
                break;
            default:
                return;
        }

        if (GetTimer() > lifeTime)
        {
            SetTimer();
            ObjectPool.Instance.PushToPool(BulletType.Bullet.ToString(), gameObject);
        }
    }

    IEnumerator Laser()
    {
        Vector3 initialScale = transform.localScale;

        while (true)
        {
            yield return new WaitForSeconds(3);
            transform.localScale = new Vector3(100f, 5f, 0);
            yield return new WaitForSeconds(3);
            transform.localScale = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(3);
            transform.localScale = initialScale;
        }
    }

    float GetTimer()
    {
        return _elapsedTime += Time.deltaTime;
    }

    void SetTimer()
    {
        _elapsedTime = 0f;
    }
}
