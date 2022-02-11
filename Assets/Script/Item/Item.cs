using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] private float followSpeed = 5.0f;

    private IEnumerator FollowTarget()
    {
        while(true)
        {
            transform.Translate(target.transform.position - this.transform.position * Time.deltaTime * followSpeed);
        }
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