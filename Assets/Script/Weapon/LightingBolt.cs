using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBolt : Weapon
{
    [SerializeField] private float maxAttackRange = 15.0f; // 15의 지름을 갖는 CircleCast로 가까운적이나, 랜덤의 적한테 공격할 것. 
    [SerializeField] private GameObject Effect;

    public override void Attack(float upgradeDamage)
    {
        fixedDamage = upgradeDamage;

        RaycastHit2D[] hits;

        hits = Physics2D.CircleCastAll(transform.position, 15.0f, Vector2.zero);

        if (hits == null) return;  // 캐스트 안잡히면 컷.

        List<Vector3> list = new List<Vector3>();
        list.Clear();

        for (int j = 0; j < hits.Length; j++)
        {
            if (hits[j].collider.gameObject.tag == "Enemy")
                list.Add(hits[j].collider.gameObject.transform.position);
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

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;//각도 구하기

            GameObject bullet = Instantiate(Effect, transform.position, Quaternion.identity, transform);

            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);//구한 각도로 변경
            bullet.GetComponent<Rigidbody2D>().AddForce(dir.normalized * speed);

            //10초 뒤에는 사라질 것
            Destroy(bullet, 10.0f);

            yield return new WaitForSeconds(attackspeed);
        }
    }
}
