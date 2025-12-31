using UnityEngine;

public enum FACETYPE
{
    NORMAL,
    HOT,
    COLD,
}

public class PlayerController : MonoBehaviour
{
    public float maxX = 8f;

    [SerializeField, Header("プレイヤーの移動速度")]
    private float moveSpeed = 1f;
    [SerializeField, Header("GameController")]
    private GameController gameController;
    [SerializeField,Header("プレイヤーの表情差分")]
    private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameController.isEnd)
        {
            // プレイヤーの移動
            PlayerMove(Input.GetAxis("Horizontal"));

            // 表情を変える
            switch (gameController.GetMode())
            {
                case FACETYPE.NORMAL:
                    spriteRenderer.sprite = sprites[0];
                    break; 

                case FACETYPE.HOT:
                    spriteRenderer.sprite = sprites[1];
                    break;

                case FACETYPE.COLD:
                    spriteRenderer.sprite = sprites[2];
                    break;
            }
        }
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    /// <param name="axis"></param>
    private void PlayerMove(float axis)
    {
        transform.Translate(transform.right * moveSpeed * axis * Time.deltaTime);

        float posX = transform.position.x;

        if (transform.position.x > maxX)
        {
            posX = maxX;
        }
        else if(transform.position.x < -maxX)
        {
            posX = -maxX;
        }

        transform.position = new Vector3(posX, transform.position.y, 0);
    }

    /// <summary>
    /// 衝突判定
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hot"))
        {
            gameController.ChangeMode(true);
        }
        else if(collision.CompareTag("cool"))
        {
            gameController.ChangeMode(false);
        }

        Destroy(collision.gameObject);
    }
}
