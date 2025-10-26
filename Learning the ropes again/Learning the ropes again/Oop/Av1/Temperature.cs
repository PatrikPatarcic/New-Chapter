namespace Learning_the_ropes_again.Oop.Av1
{
    public class Temperature
    {
        float celsius;

        public Temperature(float celsius)
        {
            this.celsius = celsius;
        }
        public float Celsius { get => celsius; set => celsius = value; }

        public bool isIce() => celsius < 0;
    }
}
