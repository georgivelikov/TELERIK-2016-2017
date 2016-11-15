namespace Template_Method
{
    public class Cow : Animal
    {
        public override string Introduce()
        {
            return base.Introduce() + "I am also a cow and I like grass.";
        }
    }
}
