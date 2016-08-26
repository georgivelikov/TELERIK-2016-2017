namespace Task_11
{
    using System;

    public class Version : Attribute
    {
        public Version(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; set; }

        public int Minor { get; set; }

        public override string ToString()
        {
            return "[Year:" + this.Major + "." + "Month:" + this.Minor + "]";
        }
    }
}
