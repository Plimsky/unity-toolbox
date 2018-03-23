namespace DesignPattern.Observer.Test
{
    public class BigJumpEvent : CubeEvent
    {
        public override float GetJumpForce()
        {
            return 60f;
        }
    }
}