using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
		public GraphicEditor()
		{
		}

        public void DrawShape(IShape shape)
        {
			string output = $"I'm {shape.GetType().Name}";
			Console.WriteLine(output);
        }
    }
}
