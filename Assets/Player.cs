using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] GameObject breadcrumbPrefab;

    private Vector3 direction = Vector3.right;

    private Rigidbody rb;

    public List<Vector3> positionList = new List<Vector3>();
    public List<Quaternion> rotationList = new List<Quaternion>();

    private void Awake()
    {
        TryGetComponent(out rb);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
    }

    // Update is called once per frame
    void Update()
    {
        // 移動処理を行う。
        var dir = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) dir.x = -1;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) dir.x = 1;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) dir.z = -1;
        else if (Input.GetKeyDown(KeyCode.UpArrow)) dir.z = 1;
        if (dir != Vector3.zero)
        {
            direction = dir;
            transform.forward = dir;
        }
        transform.position += (Time.deltaTime * speed * direction);

        // ジャンプ処理を行う。
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            isGrounded = false;
        }

        // 接地判定を行う。
        var ray = new Ray(transform.position + Vector3.up * 0.05f, Vector3.down);
        var rayLength = 0.3f;
        isGrounded = Physics.Raycast(ray, rayLength, groundLayer);
    }

    private void FixedUpdate()
    {
        positionList.Add(transform.position);
        rotationList.Add(transform.rotation);
        //Instantiate(breadcrumbPrefab, transform.position, Quaternion.identity);
    }
}
