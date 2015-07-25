using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;
using Delete;
using HtmlAgilityPack;

namespace LibraryTests
{
    using NUnit.Framework;
    class TestVK
    {
        VK vkuser = new VK();

        [Test]
        public void OAuth()
        { 
            //Arrange
            string email = "xx";
            string pass = "xx";

            //act
            vkuser.auth(email, pass);

            //assert 
        }

    }
}
