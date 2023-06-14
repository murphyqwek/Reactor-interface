using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reactor_Interface.Classes
{
    public class Buffer
    {
        private const int BUFFERSIZE = 2048;

        private class BufferNode
        {
            public BufferNode PrevNode;
            public BufferNode NextNode;
            public string Value;
            public string Page;
            public RichTextBox TextBox;

            public BufferNode(string page, string value, RichTextBox textBox)
            {
                Page = page;
                Value = value;
                TextBox = textBox;
            }
        }

        private BufferNode lastBufferNode = null;
        private BufferNode firstBufferNode = null;

        private int Size = 0;

        public void Add(RichTextBox textBox, string value, string page)
        {
            var FirstNode = new BufferNode(page, value, textBox);
            if(Size == BUFFERSIZE)
            {
                var tempNode = lastBufferNode.NextNode;
                lastBufferNode = tempNode;
                tempNode.PrevNode = null;
                firstBufferNode.NextNode = FirstNode;
                FirstNode.PrevNode = firstBufferNode;
                firstBufferNode = FirstNode;
            }
            else if(Size == 0)
            {
                lastBufferNode = FirstNode;
                firstBufferNode = FirstNode;
                Size++;
            }
            else
            {
                firstBufferNode.NextNode = FirstNode;
                FirstNode.PrevNode = firstBufferNode;
                firstBufferNode = FirstNode;
                Size++;
            }
        }
    
        public (RichTextBox, string, string) Pop()
        {
            if (Size == 0)
                return (null, null, null);

            var TextBox = firstBufferNode.TextBox;
            string value = firstBufferNode.Value;
            string page = firstBufferNode.Page;

            if (Size == 1)
            {
                lastBufferNode = null;
                firstBufferNode = null;
            }
            else
            {
                var tempNode = firstBufferNode.PrevNode;
                tempNode.NextNode = null;
                firstBufferNode = tempNode;
            }

            Size--;

            return (TextBox, value, page);
        }

        public void Clear()
        {
            if (Size == 0)
                return;

            BufferNode tempNode;
            do
            {
                tempNode = firstBufferNode.PrevNode;
                firstBufferNode = null;
                firstBufferNode = tempNode;
            }
            while (tempNode != null);

            lastBufferNode = null;

            Size = 0;
        }

    }
}