using System;

namespace BaseProject.Commons.Attributes
{
    public class ExtraDescriptionAttribute : Attribute
    {
        public ExtraDescriptionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            var other = obj as ExtraDescriptionAttribute;
            return other != null && other.Description == Description;
        }

        public override int GetHashCode()
        {
            return Description.GetHashCode();
        }
    }
}