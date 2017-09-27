using System;

namespace _19.Thea_The_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPictures = int.Parse(Console.ReadLine());
            var timeForFilter = int.Parse(Console.ReadLine());
            var filterPercentage = int.Parse(Console.ReadLine());
            var uploadTime = int.Parse(Console.ReadLine());
            var filteredTimeInSeconds = (long)numberOfPictures * timeForFilter;
            var picturesToUpload = (long)Math.Ceiling(numberOfPictures * (filterPercentage / 100d));
            var timeNeededForUpload = picturesToUpload * uploadTime;
            var finalTime = timeNeededForUpload + filteredTimeInSeconds;
            var totalTimeNeeded = TimeSpan.FromSeconds(finalTime);
            Console.WriteLine(totalTimeNeeded.ToString(@"d\:hh\:mm\:ss"));
        }
    }
}