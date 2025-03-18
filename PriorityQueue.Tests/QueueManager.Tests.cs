using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Windows.Forms;
using PriorityQueue;

namespace PriorityQueue.Tests
{
    public class QueueManagerTests
    {

        private QueueManager _form;



        [SetUp]
        public void Setup()
        {
            _form = new QueueManager();
            _form.Show();
            
        }



        [TearDown]
        public void TearDown()
        {
            _form.Close();
            _form.Dispose();
        }


























    }
}
