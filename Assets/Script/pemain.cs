using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pemain : MonoBehaviour
{
    Rigidbody2D rb;
    public float kecepatann;
    public float jumpPower;
    Vector2 currentScale;
    Animator anim;
    bool mendarat;

    public float serangCd;
    public float damage;
    public float range;
    public float colliderDistance;
    public BoxCollider2D boxCollider;
    public LayerMask musuhLayer;

    private float cdTimer = Mathf.Infinity;

    private darahMusuh DarahMusuh;
    private darahBoss DarahBoss;

    private void Awake()
    {
        currentScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        float horizontall = SimpleInput.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontall*kecepatann, rb.velocity.y);
        transform.Translate(horizontall * Time.deltaTime, 0, 0);

        if (horizontall < 0) transform.localScale = new Vector2(-currentScale.x, currentScale.y);
        if (horizontall > 0) transform.localScale = new Vector2(currentScale.x, currentScale.y);

        if (Input.GetKeyDown(KeyCode.Space) && mendarat)
            Lompat();

        anim.SetBool("lari", horizontall != 0);
        anim.SetBool("mendarat", mendarat);

        cdTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.B))
        {

            if (cdTimer >= serangCd)
            {
                cdTimer = 0;
                if (musuhInSight())
                {
                    anim.SetTrigger("menyerang");
                }
                else
                {
                    anim.Play("serang");
                }
                
            }
            if (cdTimer >= serangCd)
            {
                cdTimer = 0;
                if (bossInSight())
                {
                    anim.SetTrigger("menyerang");
                }
                else
                {
                    anim.Play("serang");
                }

            }
        }
    }

    private bool musuhInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, musuhLayer);

        if (hit.collider != null)
        {
            DarahMusuh = hit.transform.GetComponent<darahMusuh>();
        }

        return hit.collider != null;
    }

    private bool bossInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, musuhLayer);

        if (hit.collider != null)
        {
            DarahBoss = hit.transform.GetComponent<darahBoss>();
        }

        return hit.collider != null;
    }

    private void DamageMusuh()
    {
        if (musuhInSight())
        {
            DarahMusuh.Diserang(damage);
        }
        if (bossInSight())
        {
            DarahBoss.Diserang(damage);
        }

        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    public void Lompat()
    {
        if (mendarat == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            anim.SetTrigger("lompat");
            mendarat = false;
        }
        
    }

    public void Serang()
    {
            if (cdTimer >= serangCd)
            {
                cdTimer = 0;
                if (musuhInSight())
                {
                    anim.SetTrigger("menyerang");
                }
                else
                {
                    anim.Play("serang");
                }

            }
            if (cdTimer >= serangCd)
             {
            cdTimer = 0;
            if (bossInSight())
            {
                anim.SetTrigger("menyerang");
            }
            else
            {
                anim.Play("serang");
            }

            }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tanah")
            mendarat = true;
    }
}

