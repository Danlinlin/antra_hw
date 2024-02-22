public class Color
{
    public int Red { get; private set; }
    public int Green { get; private set; }
    public int Blue { get; private set; }
    public int Alpha { get; private set; }

    public Color(int red, int green, int blue, int alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }

    public Color(int red, int green, int blue) : this(red, green, blue, 255) { }

    public void SetRed(int red) { Red = red; }
    public void SetGreen(int green) { Green = green; }
    public void SetBlue(int blue) { Blue = blue; }
    public void SetAlpha(int alpha) { Alpha = alpha; }

    public int GetGrayscaleValue()
    {
        return (Red + Green + Blue) / 3;
    }
}
