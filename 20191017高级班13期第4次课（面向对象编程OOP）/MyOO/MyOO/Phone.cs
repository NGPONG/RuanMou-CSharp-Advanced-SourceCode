using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO
{
    public class Phone
    { 
        private string Number { get; set; }

        public void Open()
        {

        }

        public void Start(Game game)
        {
            game.Start();
            game.Fighting();
            game.Over();
        }

    }
}
