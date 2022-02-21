using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] private float followSpeed = 5.0f;
<<<<<<< HEAD
<<<<<<< HEAD
    public bool check { private get; set; }
=======
>>>>>>> parent of 11176cfe (22-02-14(2))
=======
    private bool check = false;
>>>>>>> parent of 4bfc6ff1 (22-02-16)

<<<<<<< HEAD
    private void Start()
    {
        target = GameObject.Find("Player");
    }
<<<<<<< HEAD
=======
>>>>>>> parent of bfb91913 (02-14 (1))
    private IEnumerator FollowTarget()
    {
        while (true)
        {
            transform.Translate((target.transform.position - this.transform.position).normalized * Time.deltaTime * followSpeed);
            yield return null;
        }
    }
    private IEnumerator MoveConverseTarget()
    {
        check = true;
        Vector3 converseTarget = new Vector2((this.transform.position.x - target.transform.position.x), (this.transform.position.y - target.transform.position.y)).normalized;
        Vector3 resurtPosition = transform.position + converseTarget;
        float moveTime = 0.3f;
        while (moveTime >= 0.0f)
=======

    private IEnumerator FollowTarget()
    {
        while(true)
>>>>>>> parent of 11176cfe (22-02-14(2))
        {
            transform.Translate(target.transform.position - this.transform.position * Time.deltaTime * followSpeed);
        }
<<<<<<< HEAD
<<<<<<< HEAD
        StartFollowTarget();
=======
>>>>>>> parent of 11176cfe (22-02-14(2))
=======
        yield return StartCoroutine(FollowTarget());
>>>>>>> parent of 4bfc6ff1 (22-02-16)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == !target)
            return;

        IItemWork thisItemWork = this.GetComponent<IItemWork>();
        if (thisItemWork == null)
            return;
        thisItemWork.ItemWork();

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == !target)
            return;

        StartCoroutine(FollowTarget());
    }

}

interface IItemWork
{
    void ItemWork();
}