using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] private float followSpeed = 5.0f;
    public bool check { private get; set; }
    protected bool durationItem { private get; set; }

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
        Debug.Log($"{collision.gameObject}{target}");
        if (collision == !target)
        {
            return;
        }
        if (check == false)
            StartCoroutine(MoveConverseTarget());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == !target && collision.collider == target.GetComponent<Collider2D>())
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

interface IItemWork
{
    void ItemWork();
}