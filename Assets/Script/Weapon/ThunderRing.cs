using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderRing : Weapon
{
    [SerializeField] private float maxAttackRange = 7.0f; // 8�� ������ ���� CircleCast. ������ ������ ������ ��. 
    [SerializeField] private GameObject Effect;
    public override void Attack()
    {
        RaycastHit2D[] hits;

        hits = Physics2D.CircleCastAll(transform.position, maxAttackRange, Vector2.zero);

        if (hits == null) return;  // ĳ��Ʈ �������� ��.

        List<Vector3> list = new List<Vector3>();
        list.Clear();

        for (int j = 0; j < hits.Length; j++)
        {
            if (hits[j].collider.gameObject.tag == "Enemy")
            {
                list.Add(new Vector3(hits[j].collider.gameObject.transform.position.x, hits[j].collider.gameObject.transform.position.y,-1));
            }
        }

        if (list.Count == 0) return; // ���� 0������ ��.

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
