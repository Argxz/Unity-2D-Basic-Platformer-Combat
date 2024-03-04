
using UnityEngine;

public class bossMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed;
    Vector2 currentScale;
    public float jarakKejar;
    Animator anim;

    public string tagTarget;
    public bool touchTarget;
    public float serangCd;
    public float damage;
    public float range;
    public float colliderDistance;
    public BoxCollider2D boxCollider;
    public LayerMask playerLayer;

    private float cdTimer = Mathf.Infinity;

    private darah darahPemain;

    private darahBoss DarahBoss;

    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
        currentScale = transform.localScale;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        DarahBoss = GetComponentInParent<darahBoss>();
    }
    void FixedUpdate()
    {
        cdTimer += Time.deltaTime;
        if (playerInSight()==true)
        {
            if (cdTimer >= serangCd)
            {
                cdTimer = 0;
                
                anim.SetTrigger("menyerang");
                anim.SetBool("gerak", false);
            }

        }
        else if (Vector3.Distance(transform.position, target.position) < jarakKejar)
        {
            transform.position =
            Vector3.MoveTowards(
                transform.position,
                new Vector3(target.position.x, transform.position.y, transform.position.z) + offset,
                speed * Time.deltaTime);
            anim.SetBool("gerak", true);

        }
        else
        {
            anim.SetBool("gerak", false);
        }



        if (transform.position.x > target.position.x)
        {
            transform.localScale = new Vector2(currentScale.x, currentScale.y);

        }
        else
        {
            transform.localScale = new Vector2(-currentScale.x, currentScale.y);
        }

    }
    private bool playerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            darahPemain = hit.transform.GetComponent<darah>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePemain()
    {
        if (playerInSight())
            darahPemain.Diserang(damage);
    }
}