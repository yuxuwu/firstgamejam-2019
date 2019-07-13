using UnityEngine.EventSystems;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    SpriteRenderer m_spriteRenderer;
    [SerializeField] Sprite defaultSprite = null;
    [SerializeField] Sprite spoonSprite;
    [SerializeField] Sprite spoonFruitSprite;
    [SerializeField] Sprite spoonPuerSprite;
    [SerializeField] Sprite spoonTiguaninSprite;
    [SerializeField] Sprite spoonUlunSprite;

    [SerializeField] StatsTracker stats;

    enum State {Hover, Dragging};
    enum Tea {Puer, Fruit, Tiguanin, Ulun};

    State state = State.Hover;
    Tea tea;

    void Start()
    {
        Cursor.visible = false;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_spriteRenderer.sprite = defaultSprite;
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
        Collider2D collider = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero).collider;;

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
                        m_spriteRenderer.sprite = spoonSprite;
                        break;
                }
            }
            else {
                m_spriteRenderer.sprite = defaultSprite;
            }
        }

        /// Process Mouse Button Down
        if (Input.GetMouseButtonDown(0) && state == State.Hover && collider)
        {
            switch (collider.gameObject.name)
            {
                case "TeaPuer":
                    m_spriteRenderer.sprite = spoonPuerSprite;
                    tea = Tea.Puer;
                    break;
                case "TeaFruit":
                    m_spriteRenderer.sprite = spoonFruitSprite;
                    tea = Tea.Fruit;
                    break;
                case "TeaTiguanin":
                    m_spriteRenderer.sprite = spoonTiguaninSprite;
                    tea = Tea.Tiguanin;
                    break;
                case "TeaUlun":
                    m_spriteRenderer.sprite = spoonUlunSprite;
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
            m_spriteRenderer.sprite = defaultSprite;
            state = State.Hover;
        }
    }

}