using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;


public class ActionButto : MonoBehaviour
{
    [SerializeField]
    private TMP_Text End;
    [SerializeField]
    private GameObject OffSetButton;

    private UnityEngine.UI.Image image;
    [SerializeField]
    private int count = 1;

    [SerializeField]
    private UnityEngine.UI.Button m_Button;
    private UnityEngine.UI.Button Button { get { return m_Button; } }

    private System.IDisposable EnableButtonListener { get; set; }
    private CompositeDisposable Disposables { get; set; } = new CompositeDisposable();
    private int ast = 1;

    [SerializeField]
    private UnityEngine.UI.Image m_Omikuji;
    public UnityEngine.UI.Image OmikujiImage { get { return m_Omikuji; } }
    private Sprite sprite;

    [SerializeField]
    private int number = 1;
    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("Image").GetComponent<Image>();
        StartCoroutine("RoopStart");
        End.enabled = false;

        Button.OnClickAsObservable()
            .Subscribe(_ =>
            {
                number++;
                ast++;
            }).AddTo(Disposables);

    }
    // Update is called once per frame

    private void OnDestroy()
    {
        EnableButtonListener?.Dispose();
        Disposables.Dispose();
    }

    IEnumerator RoopStart()
    {


        while (ast == 1)
        {
            yield return new WaitForSeconds(0.2f);

            if (count < 7)
                count++;
            else
                count = 1;

            image.sprite = Resources.Load<Sprite>("Image/photo" + count.ToString());
            Debug.Log(count);
        }
    }

    private void OnApplicationQuit()
    {
        if (ast == 2)
        {
            End.enabled = true;
            switch (count)
            {
                case 1:
                    End.text = "結果は大吉です!!ラッキー!";
                    break;

                case 2:
                    End.text = "結果は中吉です!!";
                    break;
                case 3:
                    End.text = "結果は小吉です!";
                    break;
                case 4:
                    End.text = "結果は末吉です!!";
                    break;
                case 5:
                    End.text = "結果は吉です!!";
                    break;
                case 6:
                    End.text = "結果は凶です(´・ω・｀)";
                    break;
                case 7:
                    End.text = "結果は大凶です(´;ω;｀)";
                    break;
            }
            OffSetButton.SetActive(false);
        }
    }



    void Update()
    {

        OnApplicationQuit();

    }

}
