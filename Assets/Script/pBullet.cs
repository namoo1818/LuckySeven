using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pBullet : MonoBehaviour
{
    public float speed;
    public void Fire(Vector3 position, Vector3 direction, float speed)
    {
        transform.position = position;
        StartCoroutine(Move(direction, speed));
    }

    private IEnumerator Move(Vector3 direction, float speed)
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform target = GetParent(collision);
        switch (target.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enemy":
                Debug.Log("적과 충돌");
                Enemy enemy = target.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.HP--;
                }
                Destroy(gameObject);
                break;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    protected Transform GetParent(Collider2D collision)
    {
        Transform target = collision.transform;
        while (target.parent != null)
        {
            target = target.parent;
        }
        return target;
    }
}