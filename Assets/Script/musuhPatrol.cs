
using UnityEngine;

public class musuhPatrol : MonoBehaviour
{
    public Transform leftEdge;
    public Transform rightEdge;

    public Transform musuh;

    public float speed;
    private Vector3 initScale;
    private bool movingLeft;

    public float idleDuration;
    private float idleTimer;

    public Animator anim;


    private void Awake()
    {
        initScale = musuh.localScale;
    }
    private void OnDisable()
    {
        anim.SetBool("gerak", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (musuh.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                UbahArah();
        }
        else
        {
            if (musuh.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                UbahArah();
        }
    }
    private void UbahArah()
    {
        anim.SetBool("gerak", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("gerak", true);

        //Make enemy face direction
        musuh.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //Move in that direction
        musuh.position = new Vector3(musuh.position.x + Time.deltaTime * _direction * speed,
            musuh.position.y, musuh.position.z);
    }
}
