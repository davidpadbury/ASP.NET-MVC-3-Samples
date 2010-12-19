using System.Text;

namespace RazorEmailerExample
{
    public abstract class EmailTemplateBase
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public dynamic Model { get; set; }

        public string Result
        {
            get { return _builder.ToString(); }
        }

        public abstract void Execute();

        public void Write(object @object)
        {
            if (@object == null)
                return;

            _builder.Append(@object);
        }

        public void WriteLiteral(string literal)
        {
            if (literal == null)
                return;

            _builder.Append(literal);
        }
    }
}