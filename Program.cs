// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tpmod6;

internal class Program
{
    private static void Main(string[] args)
    {
        SayaTubeVideo video1 = new SayaTubeVideo("Tutorial Design By Contract - Prima Mahendra Yazadi"); 
        SayaTubeVideo video2 = new SayaTubeVideo(null); 
        SayaTubeVideo video3 = new SayaTubeVideo("Video Exception Test");

        try
        {
            for (int i = 0; i < 1000000; i++)
            {
                video3.IncreasePlayCount(1000); 
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message); 
        }

        video1.IncreasePlayCount(20);
        video1.PrintVideoDetails();
        video2.PrintVideoDetails();
        video3.PrintVideoDetails();

        Console.ReadKey();


    }
}

namespace tpmod6
{
    internal class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            if (title != null)
            {
                throw new ArgumentNullException(title, "Judul tidak boleh kosong");
            }

            if (title.Length > 100)
            {
                throw new ArgumentException("Judul harus kurang dari 100 karakter", title);
            }

            this.id = new Random().Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int input)
        {
            Contract.Requires(input > 0 && input <= 10000000, "Count must be between 1 and 10,000,000.");

            try
            {
                checked
                {
                    this.playCount += input;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID: {this.id}\nTitle: {this.title}\nPlay Count: {this.playCount}\n");
        }
    }











}