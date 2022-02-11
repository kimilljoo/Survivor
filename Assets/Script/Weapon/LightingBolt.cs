using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBolt : Weapon
{
    [SerializeField] private float maxAttackRange = 15.0f; // 15의 지름을 갖는 CircleCast로 가까운적이나, 랜덤의 적한테 공격할 것. 
    [SerializeField] private GameObject Effect;
    public override void Attack()
    {
        RaycastHit2D[] hits;

        hits = Physics2D.CircleCastAll(transform.position, maxAttackRange, Vector2.zero);

        if (hits == null) return;  // 캐스트 안잡히면 컷.

        List<Vector3> list = new List<Vector3>();
        list.Clear();

        for (int j = 0; j < hits.Length; j++)
        {
            if (hits[j].collider.gameObject.tag == "Enemy")
            {
                list.Add(hits[j].collider.gameObject.transform.position);
            }
        }

        if (list.Count == 0) return; // 적이 0마리면 컷.

        StartCoroutine(AttackCoroutine(list));
    }

    public override void LevelUp()
    {
        level++;
    }

    private IEnumerator AttackCoroutine(List<Vector3> list)
    {
        for (int i = 0; i < amount; i++)
        {
            int rand = Random.Range(0, list.Count);

            Vector3 dir = list[rand] - transform.position;

            GameObject bullet = Instantiate(Effect, transform.position, Quaternion.identity, transform);

            bullet.GetComponent<Bullet>().SetBullet(dir, speed, pierceAmount, fixedDamage);

            yield return new WaitForSeconds(attackspeed);
        }
    }
}
