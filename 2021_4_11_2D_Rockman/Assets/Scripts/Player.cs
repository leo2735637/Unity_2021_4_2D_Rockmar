
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"),Range(0, 1000)]   
    public float speed = 10.5f;
    [Header("跳躍高度"),Range(0, 3000)]
    public int jump = 100;
    [Range(0, 200)]
    public float hp = 100f;
    [Header("是否在地板上"), Tooltip("地板")]
    public bool floor = false;
    [Header("子彈"), Tooltip("子彈")]
    public GameObject bullet;
    [Header("元件子彈生成點"), Tooltip("子彈生成點")]
    public Transform Bulletgenerate;
    [Range(0, 5000)]
    public int bulletSpeed = 800;
    [Header("開槍音效"), Tooltip("槍聲")]
    public AudioClip Gunshots;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator    ani;

}
