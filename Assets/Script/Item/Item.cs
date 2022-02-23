using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected GameObject target;       // 타겟 (플레이어)

    [SerializeField] private float followSpeed = 5.0f;  // 타겟을 따라가는 속도

  
    [HideInInspector] public float detectRadius;        // 자석 범위
    public bool check { private get; set; }             // 반대로 움직일지 체크
    
    protected bool durationItem { private get; set; }   // 지속시간이 있는지 체크

    private CircleCollider2D triggerCollider;           // 자석 범위 콜라이더

    private void Start()
    {
        target = GameObject.Find("Player");
        ChangeRadius(target.GetComponent<MainCharacterScript>().playerInfomation.magnet);
    }

    public void ChangeAllRadius(float Radius) // 현재 나와있는 모든 아이템의 자석범위를 바꾼다. 매개변수로 플레이어의 자석범위를 넣기
    {
        foreach (var curItem in GameObject.FindObjectsOfType<Item>())
        {
            curItem.ChangeRadius(Radius);
        }
    }

    private void ChangeRadius(float Radius) // 현재 아이템의 자석범위를 바꾼다.
    {
        foreach(var curTrigger in GetComponents<CircleCollider2D>())
        {
            if (curTrigger.isTrigger == true)
                triggerCollider = curTrigger;
        }
        if (triggerCollider != null)
        {
            detectRadius = Radius;
            triggerCollider.radius = detectRadius;
        }
    }

    private IEnumerator FollowTarget() // 타겟을 따라간다.
    {
        while (true)
        {
            transform.Translate((target.transform.position - this.transform.position).normalized * Time.deltaTime * followSpeed);
            yield return null;
        }
    }
    public void StartFollowTarget()
    {
        StartCoroutine(FollowTarget());
    }

    private IEnumerator MoveConverseTarget() // 타겟의 반대로 움직인다.
    {
        check = true;
        Vector3 converseTarget = new Vector2((this.transform.position.x - target.transform.position.x), (this.transform.position.y - target.transform.position.y)).normalized;
        Vector3 resurtPosition = transform.position + converseTarget;
        float moveTime = 0.3f;
        while (moveTime >= 0.0f)
        {
            transform.position = Vector3.Lerp(transform.position, resurtPosition, 0.01f);
            moveTime -= Time.deltaTime;
            yield return null;
        }
        StartFollowTarget();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != target)
        {
            return;
        }
        if (check == false)
            StartCoroutine(MoveConverseTarget());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != target && collision.collider != target.GetComponent<Collider2D>())
            return;

        IItemWork thisItemWork = this.GetComponent<IItemWork>();
        if (thisItemWork != null)
            thisItemWork.ItemWork();

        if (!durationItem)
        {
            Destroy(this.gameObject);
        }
        else
        {
            foreach (var collider2D in this.gameObject.GetComponents<Collider2D>())
            {
                collider2D.enabled = false;
            }
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

interface IItemWork // 아이템의 효과처리 인터페이스
{
    void ItemWork();
}