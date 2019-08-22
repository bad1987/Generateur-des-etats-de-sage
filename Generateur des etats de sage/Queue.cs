using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur_des_etats_de_sage
{
    class Queue
    {
        private Node head { get; set; }
        private Node queue { get; set; }

        public Queue()
        {
            this.head = null;
            this.queue = null;
        }

        public Node getHead()
        {
            return this.head;
        }

        public void setHead(Node node)
        {
            this.head = node;
        }

        public void enqueue(Node obj)
        {
            Node p = new Node(obj);
            if(this.head == null)
            {
                this.head = p;
                this.queue = p;
            }
            else
            {
                this.queue.setLeftChild(p);
                p.setRightChild(this.queue);
                this.queue = p;
            }
        }

        public Node dequeue()
        {
            if (this.head != null)
            {
                Node p = this.head.getValue();
                this.head = this.head.getLeftChild();
                return p;
                
            }

            return null;
        }
    }
}
