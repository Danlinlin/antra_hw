public class Ball
{
    public Color Color { get; private set; }
    public float Size { get; private set; }
    private int throwCount;

    public Ball(float size, Color color)
    {
        Size = size;
        Color = color;
        throwCount = 0;
    }

    public void Pop()
    {
        Size = 0;
    }

    public void Throw()
    {
        if (Size > 0) 
        {
            throwCount++;
        }
    }

    public int GetThrowCount()
    {
        return throwCount;
    }
}
