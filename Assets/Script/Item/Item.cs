using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] private float followSpeed = 5.0f;
    public bool Check { private get; set; }

    private void Start()
    {
        target = GameObject.Find("Player");
    }
    private IEnumerator FollowTarget()
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
    private IEnumerator MoveConverseTarget()
    {
        Check = true;
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
        if (collision.gameObject == !target)
            return;
        if (Check == false)
            StartCoroutine(MoveConverseTarget());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == !target && collision.collider == target.GetComponent<Collider2D>())
            return;

        IItemWork thisItemWork = this.GetComponent<IItemWork>();
        if (thisItemWork != null)
            thisItemWork.ItemWork();

        Destroy(this.gameObject);
    }
}

interface IItemWork
{
    void ItemWork();
}