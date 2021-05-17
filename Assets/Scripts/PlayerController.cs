using UnityEngine;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotationalSpeed = 2;

    [SerializeField] private float moveSpeed = 300;
    
    public delegate void AddTime();

    public static event AddTime poweredUp;

    private float vertical;
    private float horizontal;
    private bool jump;
    private Animator anim;
    private Rigidbody rb;
    
    //hashes, performance thing
    private readonly int speedVFHash = Animator.StringToHash("SpeedVertical");
    private readonly int speedHFHash = Animator.StringToHash("SpeedHorizontal");
    private readonly int jumpHash = Animator.StringToHash("Jump");
   

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
        
           if (jump && !anim.GetCurrentAnimatorStateInfo(0).IsName("BaseLayer.Jump"))
        {
            anim.SetTrigger(jumpHash);
        }
    }

    private void FixedUpdate()
    {
        anim.SetFloat(speedVFHash, vertical);
        anim.SetFloat(speedHFHash, horizontal);

        var tran = transform;
        rb.MovePosition(tran.position + tran.forward * (vertical * moveSpeed * 0.01f * Time.deltaTime));
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0f, horizontal*rotationalSpeed, 0f)));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (poweredUp != null) poweredUp();
            other.gameObject.SetActive(false);
        }
    }
}
