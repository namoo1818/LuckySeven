using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform target = GetParent(collision);
        switch (target.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Player":
                Player player = target.GetComponent<Player>();
                if (player != null)
                {
                    player.curHealth--;
                }
                Destroy(gameObject);
                break;
        }
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
