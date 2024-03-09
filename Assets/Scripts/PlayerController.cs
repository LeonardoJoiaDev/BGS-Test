using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField]
    Animator animator;
    [SerializeField]
    Rigidbody2D rb2d;

    bool isNearShop = false;

    public bool IsNearShop { get => isNearShop; set => isNearShop = value; }

    void Start()
    {
        this.transform.position = Vector3.zero;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector2(moveHorizontal * speed * 100, moveVertical * speed * 100);

        if (moveHorizontal != 0f || moveVertical != 0f)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); 
        }
        else if (moveHorizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsNearShop)
        {
            if (IsNearShop)
            {
                PlayerManager.Instance.ShopController.OpenStore();

                PlayerManager.Instance.GetComponent<RectTransform>().position = Vector3.zero;
                PlayerManager.Instance.GetComponent<RectTransform>().localScale = Vector3.one;
            }
            //&& IsNearShop
            //rb2d.isKinematic = true;
            // GetComponent<BoxCollider2D>().enabled = false;
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Store"))
        {
            IsNearShop = true;
        }
        else if(collision.CompareTag("Coins"))
        {
            animator.SetTrigger("Interact");
            PlayerManager.Instance.ChangeBalance(200);
            collision.gameObject.SetActive(false);
        }
        else if(collision.CompareTag("Box"))
        {
            animator.SetTrigger("Interact");
            PlayerManager.Instance.ChangeBalance(500);
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Store"))
        {
            IsNearShop = false;
        }
    }
}
