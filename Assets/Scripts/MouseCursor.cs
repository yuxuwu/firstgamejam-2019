using UnityEngine.UI;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    //SpriteRenderer m_spriteRenderer;
    Image m_image;
    [SerializeField] Sprite defaultSprite = null;
    [SerializeField] Sprite spoonSprite = null;
    [SerializeField] Sprite spoonFruitSprite = null;
    [SerializeField] Sprite spoonPuerSprite = null;
    [SerializeField] Sprite spoonTiguaninSprite = null;
    [SerializeField] Sprite spoonUlunSprite = null;

    StatsManager stats = null;

    enum State {Hover, Dragging};
    enum Tea {Puer, Fruit, Tiguanin, Ulun};

    State state = State.Hover;
    Tea tea;

    void Start()
    {
        stats = GameObject.Find("Managers").GetComponent<StatsManager>();
        Cursor.visible = false;
        m_image = GetComponent<Image>();
        m_image.sprite = defaultSprite;
    }

    void Update()
    {
        transform.position = Input.mousePosition;
        Collider2D collider = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero).collider;

        /// Process Hover state
        if (state == State.Hover)
        {
            if (collider)
            {
                switch (collider.gameObject.name)
                {
                    case "TeaPuer":
                    case "TeaFruit":
                    case "TeaTiguanin":
                    case "TeaUlun":
                        SetCursorSpoon(spoonSprite);
                        break;
                }
            }
            else {
                SetCursorDefault();
            }
        }

        /// Process Mouse Button Down
        if (Input.GetMouseButtonDown(0) && state == State.Hover && collider)
        {
            switch (collider.gameObject.name)
            {
                case "TeaPuer":
                    SetCursorSpoon(spoonPuerSprite);
                    tea = Tea.Puer;
                    break;
                case "TeaFruit":
                    SetCursorSpoon(spoonFruitSprite);
                    tea = Tea.Fruit;
                    break;
                case "TeaTiguanin":
                    SetCursorSpoon(spoonTiguaninSprite);
                    tea = Tea.Tiguanin;
                    break;
                case "TeaUlun":
                    SetCursorSpoon(spoonUlunSprite);
                    tea = Tea.Ulun;
                    break;

                default:
                    break;
            }
            state = State.Dragging;
        }

        /// Process Mouse Button Up
        if (Input.GetMouseButtonUp(0) && state == State.Dragging)
        {
            if (collider && collider.gameObject.name == "TeaTeapot")
            {
                Debug.Log("Dropped tea");
                switch (tea)
                {
                    case Tea.Puer:
                        stats.AddJealousy(5);
                        stats.SubAmbition(5);
                        stats.SubPride(5);
                        break;
                    case Tea.Fruit:
                        stats.AddJealousy(5);
                        stats.SubAmbition(5);
                        stats.SubPride(5);
                        break;
                    case Tea.Tiguanin:
                        stats.AddAmbition(5);
                        stats.SubJealousy(5);
                        stats.SubPride(5);
                        break;
                    case Tea.Ulun:
                        stats.AddPride(5);
                        stats.SubJealousy(5);
                        stats.SubAmbition(5);
                        break;
                    default:
                        break;
                }
            }
            SetCursorDefault();
            state = State.Hover;
        }
    }

    private void SetCursorDefault()
    {
        m_image.overrideSprite = defaultSprite;
        transform.localScale = new Vector2(1, 1);
        gameObject.GetComponent<RectTransform>().pivot = (defaultSprite.pivot)/defaultSprite.rect.width;
    }

    private void SetCursorSpoon(Sprite image)
    {
        m_image.overrideSprite = image;
        transform.localScale = new Vector2(5, 5);
        gameObject.GetComponent<RectTransform>().pivot = (image.pivot)/image.rect.width;
    }

}