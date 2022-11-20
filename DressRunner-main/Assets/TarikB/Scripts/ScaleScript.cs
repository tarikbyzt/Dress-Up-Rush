using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScaleScript : MonoBehaviour
{
    public static ScaleScript Current;
    [SerializeField] private GameObject player;
    [SerializeField] private Material dressMat;
    [SerializeField] private float scaleValue;
    public SkinnedMeshRenderer bodySkinnedMeshRenderer;
    public float scoreX=1;
    private int dressValue = 100;
    public GameObject censored;
    public Animator coinAnimator;
    public GameObject dancer;





    private void Start()
    {
        bodySkinnedMeshRenderer.SetBlendShapeWeight(0, dressValue);
        Current = this;
    }
    private void Awake()
    {
        dressMat.color = Color.white;
        //bodySkinnedMeshRenderer.SetBlendShapeWeight(0, dressValue);
    }

    private void Update()
    {
        if (dressValue >= 110)
        {
            censored.SetActive(true);
            if (dressValue == 120)
            {
                PlayerController.Current.playerAnimator.SetBool("Running", false);
                PlayerController.Current.playerAnimator.SetBool("Defeat", true);
                LevelController.Current.GameOver();
            }
        }
        else
        {
            censored.SetActive(false);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ScoreX")
        {
            scoreX = (100 - bodySkinnedMeshRenderer.GetBlendShapeWeight(0)) / 10;
            Debug.Log(scoreX);
        }
        if (other.tag == "coin")
        {
            coinAnimator.SetTrigger("Coining");
            //coinAnimator.SetBool("CoinAlma", true);
            Destroy(other.gameObject);
            LevelController.Current.ChangeScore(10);

        }

        if (other.tag == "GateGreen")
        {
            player.tag = "Green";
            Debug.Log("yeþilkapý");

            dressMat.color = Color.green;
        }


        if (other.tag == "GateBlue")
        {
            player.tag = "Blue";
            Debug.Log("mavikapý");

            dressMat.color = Color.blue;
        }

        if (other.tag == "GateRed")
        {
            player.tag = "Red";
            Debug.Log("kýrmýzýkapý");

            dressMat.color = Color.red;

        }

        

        //if (other.tag == "coin")
        //{
        //  Destroy(other.gameObject);
        // LevelController.Current.ChangeScore(10);
        //}

        if (other.tag == "Green" || other.tag == "Blue" || other.tag == "Red")
        {



            if (other.tag == player.tag)
            {
                Debug.Log("Büyüdü" + player.tag);
                Destroy(other.gameObject);
                if (dressValue > 0)
                {
                    dressValue -= 10;
                }


                bodySkinnedMeshRenderer.SetBlendShapeWeight(0, dressValue);
                //transform.localScale = new Vector3(transform.lossyScale.x + scaleValue * Time.deltaTime, transform.lossyScale.y + scaleValue * Time.deltaTime, transform.lossyScale.z + scaleValue * Time.deltaTime);
                // transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);


            }




            else
            {
                Debug.Log("Küçüldü");
                Destroy(other.gameObject);
                if (dressValue <= 110)
                {
                    dressValue += 10;
                }

                bodySkinnedMeshRenderer.SetBlendShapeWeight(0, dressValue);
                //transform.localScale = new Vector3(transform.lossyScale.x - scaleValue * Time.deltaTime, transform.lossyScale.y - scaleValue * Time.deltaTime, transform.lossyScale.z - scaleValue * Time.deltaTime);
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            }
        }

        if (other.tag == "finish" && dressValue > 100)
        {


            PlayerController.Current.playerAnimator.SetBool("Running", false);
            PlayerController.Current.playerAnimator.SetBool("Defeat", true);
            LevelController.Current.GameOver();
        }

        if (other.tag == "End" && dressValue <= 100)
        {

            if (dressValue < 100)
            {
                dressValue += 10;
            }
            if (dressValue<=90)
            {
                LevelController.Current.score *= scoreX;
            }
            if (dressValue == 100)
            {

                PlayerController.Current.playerAnimator.SetBool("Running", false);
                PlayerController.Current.playerAnimator.SetBool("Dancing", true);

                
                LevelController.Current.FinishMenu();
                //evelController.Current.gameActive = false;
            }

            bodySkinnedMeshRenderer.SetBlendShapeWeight(0, dressValue);


            Debug.Log(dressValue);
        }


    }


}
