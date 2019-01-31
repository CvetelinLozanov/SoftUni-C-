using OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRadioDatabase.Core
{
    public class Engine
    {
        private List<Song> songs;

        public Engine()
        {
            songs = new List<Song>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] inputArgs = Console.ReadLine()
                        .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    if (inputArgs.Length != 3)
                    {
                        throw new InvalidSongException();
                    }
                    string artistName = inputArgs[0];
                    string songName = inputArgs[1];
                    string[] length = inputArgs[2]
                        .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    bool isMinutes = int.TryParse(length[0], out int minutes);
                    bool isSeconds = int.TryParse(length[1], out int seconds);

                    if (!isMinutes)
                    {
                        throw new InvalidSongLengthException();
                    }
                    if (!isSeconds)
                    {
                        throw new InvalidSongLengthException();
                    }

                    Song song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine($"Song added");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Print();
        }

        private void Print()
        {
            Console.WriteLine($"Songs added: {songs.Count}");

            int totalSeconds = songs.Sum(x => x.Seconds + (x.Minutes * 60));

            TimeSpan playListTime = TimeSpan.FromSeconds(totalSeconds);

            Console.WriteLine($"Playlist length: {playListTime.Hours}h {playListTime.Minutes}m {playListTime.Seconds}s");
        }
    }
}
