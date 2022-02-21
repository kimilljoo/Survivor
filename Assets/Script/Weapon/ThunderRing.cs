using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderRing : Weapon
{
    [SerializeField] private float maxAttackRange = 7.0f; // 8의 지름을 갖는 CircleCast. 랜덤의 적한테 공격할 것. 
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

            GameObject bullet = Instantiate(Effect);

            bullet.GetComponent<StillBullet>().SetStillBullet(transform.localScale, list[rand], fixedDamage, 1.0f, this);

            yield return new WaitForSeconds(attackspeed);
        }
    }
}
