using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected GameObject target;       // Ÿ�� (�÷��̾�)

    [SerializeField] private float followSpeed = 5.0f;  // Ÿ���� ���󰡴� �ӵ�

  
    [HideInInspector] public float detectRadius;        // �ڼ� ����
    public bool check { private get; set; }             // �ݴ�� �������� üũ
    
    protected bool durationItem { private get; set; }   // ���ӽð��� �ִ��� üũ

    private CircleCollider2D triggerCollider;           // �ڼ� ���� �ݶ��̴�

    private void Start()
    {
        target = GameObject.Find("Player");
        ChangeRadius(target.GetComponent<MainCharacterScript>().playerInfomation.magnet);
    }

    public void ChangeAllRadius(float Radius) // ���� �����ִ� ��� �������� �ڼ������� �ٲ۴�. �Ű������� �÷��̾��� �ڼ������� �ֱ�
    {
        foreach (var curItem in GameObject.FindObjectsOfType<Item>())
        {
            curItem.ChangeRadius(Radius);
        }
    }

    private void ChangeRadius(float Radius) // ���� �������� �ڼ������� �ٲ۴�.
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

    private IEnumerator FollowTarget() // Ÿ���� ���󰣴�.
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

    private IEnumerator MoveConverseTarget() // Ÿ���� �ݴ�� �����δ�.
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

interface IItemWork // �������� ȿ��ó�� �������̽�
{
    void ItemWork();
}