namespace DesignPattern.Observer.Test
{
    public class LittleJumpEvent: CubeEvent
    {
        public override float GetJumpForce()
        {
            return 30f;
        }
    }
}