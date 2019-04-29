using System;
using System.Threading;

namespace Textdateiauslesung
{
    class Progressbar
    {
        private int progress = 1;
        public void DisplayProgressInPercentage(long fileSize, int lineLength)
        {
            if(lineLength >= fileSize/100 * progress)
            {
                Console.Clear();
                Console.WriteLine("Loading... " + progress + "%");
                progress++;
            }
        }
    }
}
