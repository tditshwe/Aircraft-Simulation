using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using AircraftSimulation.Simulation;

namespace AircraftSimulation
{
    public class ScenarioFileReader
    {
        private readonly StreamReader Reader;
        private AircraftFactory Factory;
        private Tower Tower;
        public int Triggers { get; private set; }
        public WeatherTower WeatherTower { get; private set; }

        public ScenarioFileReader(string filename)
        {
		    Reader = new StreamReader(filename);
	    }

        public void Read()
        {
            string line;
            string[] str;
            int lineCounter = 1;
            Regex rx;
            MatchCollection matches;
            Factory = new AircraftFactory();
            Tower = new WeatherTower();
            WeatherTower = (WeatherTower)Tower;

            while ((line = Reader.ReadLine()) != null)
	        {
                //Skip if line is empty
                if (line == "")
                    continue;

                //Split aircraft description into parameters
                str = line.Split(' ');

                //If this is the first file line
                if (lineCounter == 1)
                {
                    if (str.Length == 1)
                    {
                        //Checks if line is a positive integer
                        rx = new Regex("([0-9]+)");
                        matches = rx.Matches(line);

                        if (matches.Count == 1)
                            Triggers = Convert.ToInt32(str[0]);
                        else
                            throw new LineNotPositiveIntegerException("First line must be a positive integer");
                    }
                    else
                        throw new LineNotPositiveIntegerException("First line must consist of one positive integer");
                }

                //Once we go past the first line we can start validating parameters
                if (lineCounter > 1)
                    ValidateFormat(str);

                if (lineCounter == 1)
                    lineCounter++;
            }
                
            Reader.Close();
        }

        /*
         * Validate the format of a line that describes an aircraft
         */
        private void ValidateFormat(string[] lineParams)
        {   
            //Only allow 5 parameters
            if (lineParams.Length != 5)
                throw new InvalidLineFormatException("Aircraft description must consist of 5 parameters");

            //Validate type
            ValidateParam(lineParams[0], "(Baloon|JetPlane|Helicopter)", "Invalide aircraft type");
            //Validate name
            ValidateParam(lineParams[1], "([A-Za-z0-9]+)", "Invalide aircraft name");
            //Validate Longitude
            ValidateParam(lineParams[2], "([0-9]+)", "Longitude must be a positive integer");
            //Validate Latitude
            ValidateParam(lineParams[3], "([0-9]+)", "Latitude must be a positive integer");
            //Validate Height
            ValidateParam(lineParams[4], "([0-9]+)", "Height must be a positive integer");

            int longitude = Convert.ToInt32(lineParams[2]);
            int latitude = Convert.ToInt32(lineParams[3]);
            int height = Convert.ToInt32(lineParams[4]);

            Flyable flyable = Factory.NewAircraft(lineParams[0], lineParams[1], longitude, latitude, height);
            Tower.Register(flyable);
            flyable.RegisterTower(WeatherTower);
        }

        /*
         * Validate an individual aircraft description parameter
         */
        private void ValidateParam(string par, string pattern, string message)
        {
            Regex rx = new Regex(pattern);
            MatchCollection matches = rx.Matches(par);

            if (matches.Count == 0)
                throw new InvalidLineFormatException(message);
        }

        public void Close()
        {
            Reader.Close();
        }      
    }
}
