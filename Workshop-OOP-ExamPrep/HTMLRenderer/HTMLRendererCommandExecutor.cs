﻿using System;
using System.IO;

using HTMLRenderer.Interfaces;
using HTMLRenderer.Models;

namespace HTMLRenderer
{
    public class HTMLRendererCommandExecutor
    {
        static void Main(string[] args)
        {
            using (var sw = new StreamWriter("../../test.out.txt"))
            {
                Console.SetOut(sw);

                IElementFactory htmlFactory = new HTMLElementFactory();
                IElement html = htmlFactory.CreateElement("html");
                html.TextContent = "I am a text content in the HTML tag";
                Console.WriteLine(html);
                IElement h1 = htmlFactory.CreateElement("h1", "Welcome!");
                Console.WriteLine(h1);
                html.AddElement(h1);
                Console.WriteLine(html);
                IElementFactory f = new HTMLElementFactory();
                IElement p = f.CreateElement("p");
                Console.WriteLine(p);
                ITable table = htmlFactory.CreateTable(3, 2);
                table[0, 0] = htmlFactory.CreateElement("b", "First Name");
                table[0, 1] = htmlFactory.CreateElement("b", "Last Name");
                table[1, 0] = htmlFactory.CreateElement(null, "Svetlin");
                table[1, 1] = htmlFactory.CreateElement(null, "Nakov");
                table[2, 0] = htmlFactory.CreateElement(null, "George");
                table[2, 1] = htmlFactory.CreateElement(null, "Georgiev");
                Console.WriteLine(table);
                p.AddElement(table);
                IElement br = htmlFactory.CreateElement("br", null);
                p.AddElement(br);
                p.AddElement(htmlFactory.CreateElement("div", "I am DIV"));
                Console.WriteLine(p);
                html.AddElement(p);
                IElement div = htmlFactory.CreateElement("div",
                  "(c) Nakov & Joro @ <Telerik Software Academy>");
                Console.WriteLine(div);
                html.AddElement(div);
                ITable innerTable = htmlFactory.CreateTable(2, 2);
                innerTable[0, 0] = htmlFactory.CreateElement(null, "cell00");
                innerTable[0, 1] = htmlFactory.CreateElement("p", "cell01");
                innerTable[1, 0] = htmlFactory.CreateElement("br");
                innerTable[1, 1] = htmlFactory.CreateElement("hr", null);
                Console.WriteLine(innerTable);
                ITable outerTable = htmlFactory.CreateTable(2, 3);
                outerTable[0, 0] = htmlFactory.CreateElement(null, "out00");
                outerTable[0, 1] = htmlFactory.CreateElement("p", "out01");
                outerTable[0, 2] = innerTable;
                outerTable[1, 0] = htmlFactory.CreateElement("b", "out10");
                outerTable[1, 1] = innerTable;
                outerTable[1, 2] = innerTable;
                Console.WriteLine(outerTable);
                table[1, 0] = innerTable;
                table[1, 1] = outerTable;
                html.AddElement(outerTable);
                html.AddElement(outerTable);
                html.AddElement(outerTable);
                html.AddElement(htmlFactory.CreateElement("div", "footer"));
                Console.WriteLine(html);

            }
        }
    }
}
