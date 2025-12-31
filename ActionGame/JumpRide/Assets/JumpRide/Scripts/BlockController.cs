using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField, Header("移動スピード")]
    private float speed = 0.1f;
    [SerializeField, Header("消去する左右のx座標")]
    private float DestroyLine = 12f;
    
    private bool IsMove;    // 移動フラグ
    private Vector3 lastPos;    // 最後に居た地点
    private GameObject player;  // プレイヤー

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理
        IsMove = true;
        DestroyLine = 12;
    }

    // Update is called once per frame
    void Update()
    {
        // 移動フラグが立っていれば移動
        if(IsMove)
        {
            Move();
        }

        if (player != null && player.transform.position.y - lastPos.y > DestroyLine)
        {
            Destroy(gameObject);
        }

    }

    /// <summary>
    /// 移動関数
    /// </summary>
    private void Move()
    {
        // 移動処理
        transform.Translate(transform.right * speed);

        // 画面の端に出て行ったら自身を消去する
        if (transform.position.x < -DestroyLine || transform.position.x > DestroyLine)
        {
            Destroy(gameObject);
        }

    }

    /// <summary>
    /// プレイヤーとの接触を判定
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 触れた相手がプレイヤーか判定
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーが自身よりも上にいたら移動を止める
            if(collision.gameObject.transform.position.y >= transform.position.y + 1f)
            {
                if(IsMove)
                {
                    // スコア加算
                    transform.parent.gameObject.GetComponent<GameController>().AddScore();
                    lastPos = transform.position;
                    player = collision.gameObject;
                }
                IsMove = false;
            }
        }
    }

}
