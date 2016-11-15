namespace Template_Method
{
    public class Wolf : Animal
    {
        public override string Introduce()
        {
            return base.Introduce() + "I am also a wolf and I like meat.";
        }
    }
}
