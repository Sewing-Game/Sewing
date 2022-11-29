using UnityEngine;
using UnityEngine.Events;
public class PixelColor : MonoBehaviour
{
    public Color defaultColor = Color.white;
    public UnityEvent<PixelColor> OnClick = new UnityEvent<PixelColor>();

    private Color _color;
    private SpriteRenderer _renderer;

    /// <summary>
    /// 해당 프러퍼티는 pixel의 color를 변경합니다.
    /// </summary>
    public Color Color
    {
        //get {return _color;}와 같음
        get => _color;
        set
        {
            _color = value;
            _renderer.color = _color;
        }
    }

    //시작하면 처음 실행되며 _renderer와 color를 초기화합니다.
    public void Start()
    {
        //컬러초기화 -> 다른곳에서할거임
        //스프라이트 렌더러가 뭔지도 받아와야함
        _renderer = this.GetComponent<SpriteRenderer>();
        
        Color = defaultColor;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            //Invoke = propagation event
            OnClick.Invoke(this);
        }
    }

}

///
/// GridManager : 화면에 그리드 생성. 팔레트로부터 변경할 컬러를 받아옴(= currentColor)
///  - SpawnGrid()는 호출이 되면 pixelObject의 인스턴스를 생성함과 동시에 colorArray[][]에 오브젝트를 할당하여 연결시킴.
///  - HandleColorClick method를 팔레트 버튼마다 onClick event handler로 설정.
///  - 추가예정 : 페인트 툴
///