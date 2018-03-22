using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
			IShape circle = new Circle();
			IShape rectangle = new Rectangle();
			IShape polyghon = new Polyghon();
			GraphicEditor graphicEditor = new GraphicEditor();
			graphicEditor.DrawShape(circle);
			graphicEditor.DrawShape(polyghon);
			graphicEditor.DrawShape(rectangle);
        }
    }
}
