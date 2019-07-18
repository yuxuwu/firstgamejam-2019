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

    StatsTracker stats = null;

    enum State {Hover, Dragging};
    enum Tea {Puer, Fruit, Tiguanin, Ulun};

    State state = State.Hover;
    Tea tea;

    void Start()
    {
        stats = GameObject.Find("Managers").GetComponent<StatsTracker>();
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
                        m_image.sprite = spoonSprite;
                        break;
                }
            }
            else {
                m_image.sprite = defaultSprite;
            }
        }

        /// Process Mouse Button Down
        if (Input.GetMouseButtonDown(0) && state == State.Hover && collider)
        {
            switch (collider.gameObject.name)
            {
                case "TeaPuer":
                    m_image.sprite = spoonPuerSprite;
                    tea = Tea.Puer;
                    break;
                case "TeaFruit":
                    m_image.sprite = spoonFruitSprite;
                    tea = Tea.Fruit;
                    break;
                case "TeaTiguanin":
                    m_image.sprite = spoonTiguaninSprite;
                    tea = Tea.Tiguanin;
                    break;
                case "TeaUlun":
                    m_image.sprite = spoonUlunSprite;
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
                switch (tea)
                {
                    case Tea.Puer:
                        stats.AddJealousy(10);
                        break;
                    case Tea.Fruit:
                        stats.AddJealousy(20);
                        break;
                    case Tea.Tiguanin:
                        stats.AddAmbition(10);
                        break;
                    case Tea.Ulun:
                        stats.AddPride(10);
                        break;
                    default:
                        break;
                }
            }
            m_image.sprite = defaultSprite;
            state = State.Hover;
        }
    }

}