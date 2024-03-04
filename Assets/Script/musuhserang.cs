
using UnityEngine;

public class musuhserang : MonoBehaviour
{
    public float serangCd;
    public float damage;
    public float range;
    public float colliderDistance;
    public BoxCollider2D boxCollider;
    public LayerMask playerLayer;

    private float cdTimer = Mathf.Infinity;

    private Animator anim;
    private darah darahPemain;
    private musuhPatrol MusuhPatrol;
    private darahMusuh DarahMusuh;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        MusuhPatrol = GetComponentInParent<musuhPatrol>();
        DarahMusuh = GetComponentInParent<darahMusuh>();
    }

    public void Update()
    {
        cdTimer += Time.deltaTime;

        if (playerInSight())
        {
            
            if (cdTimer >= serangCd)
            {
                cdTimer = 0;
                anim.SetTrigger("menyerang");
            }
        }

        if (MusuhPatrol != null)
            MusuhPatrol.enabled = !playerInSight();

    }

    private bool playerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            darahPemain= hit.transform.GetComponent<darah>();

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
