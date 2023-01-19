using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Button m_Button;

    private UnityEngine.UI.Button  Button { get{return m_Button;} }

    private int ButtonCount { get; set; } = 0;

    [SerializeField]
    private TMPro.TMP_Text m_Text;
    private TMPro.TMP_Text Text { get{return m_Text;} }

    [SerializeField]
    private UnityEngine.UI.Button TestButton;
    private UnityEngine.UI.Button tButton { get { return TestButton;} }


    [SerializeField]
    private CompositeDisposable Disposables =new CompositeDisposable();

    public int omikujiCount { get; set; }=0;

    [SerializeField]
    private UnityEngine.UI.Image[] m_omikuji;

    public UnityEngine.UI.Image omikuji { get { return m_omikuji[omikujiCount]; } }


    private bool ChangeOmikugi { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        System.IDisposable ButtonLis = Button.OnClickAsObservable()
      .Subscribe(_ =>
      {
          ButtonCount++;
          omikujiCount++;
          Debug.Log(ButtonCount);
          Debug.Log(omikuji);


      }).AddTo(Disposables);


        System.IDisposable ButtonLiss = Button.UpdateAsObservable()
      .Subscribe(_ =>
      {
          Debug.Log(ButtonCount);
          Debug.Log(omikuji);


      }).AddTo(Disposables);
    }


    private void OnDestroy()
    {
        Disposables.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        if (omikujiCount > 7)
        {
            omikujiCount = 0;
        }
    }
}
