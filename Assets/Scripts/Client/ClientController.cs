using UnityEngine;

public class ClientController : MonoBehaviour
{
    public Vector3 firstPos { get; private set; }

    Quaternion firstRot;
    [SerializeField] Animator anim;
    float speed = 0.5f;

    float walkSpeed = 0.5f;

    bool outOfArea;

    [HideInInspector]
    public bool hasTaken;

    public Vector3 destination;

    public int money;

    [HideInInspector]
    public bool isClientAvaliable = true;

    private Target _target;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        _target = GetComponent<Target>();
    }

    private void OnEnable()
    {
        _target.enabled = !ClientSpawner.haveTaxiClient;
    }

    private void Start()
    {
        firstPos = transform.position;
        firstRot = transform.rotation;
    }
    

    private void Update()
    {
        _target.enabled = !ClientSpawner.haveTaxiClient;
    }

    private void FixedUpdate()
    {
        if (outOfArea)
        {
            if (firstPos.magnitude - transform.position.magnitude < 0.05f)
            {
                transform.rotation = firstRot;
                anim.SetBool("isWalking", false);
            }

            else
            {
                Walk(firstPos);
            }

        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isClientAvaliable)
        {
            if (other.GetComponentInParent<Rigidbody>().velocity.magnitude < speed && !ClientSpawner.haveTaxiClient && !hasTaken)
            {
                outOfArea = false;
                anim.SetBool("isWalking", true);
                Walk(other.transform.position);

                RaycastHit hit;

                if (Physics.Raycast(transform.position + (Vector3.up / 2), transform.forward, out hit, 5f))
                    if (hit.collider.CompareTag("Player"))
                        hasTaken = true;
            }

            else if (ClientSpawner.haveTaxiClient && !hasTaken)
            {
                Walk(firstPos);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outOfArea = true;
        }
    }

    void Walk(Vector3 destination)
    {
        transform.position = Vector3.Lerp(transform.position, destination, walkSpeed * Time.deltaTime);
        transform.LookAt(destination);
    }

}
