using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Google";
        job1._startYear = 2010;
        job1._endYear = 2015;

        Job job2 = new Job();
        job2._jobTitle = "Data Scientist";
        job2._company = "Microsoft";
        job2._startYear = 2015;
        job2._endYear = 2020;

        Resume myResume = new Resume();
        myResume._name = "Michael Virhuez";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.DisplayResume();
    }
}

